using System;
using System.Collections;
using System.Collections.Generic;
using RDG;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        var impulse = other.impulse;

        if (impulse.magnitude > 0.5f)
        {
            Debug.Log($"Impulse magnitude: {impulse.magnitude}");
            var ray = new Ray(transform.position, transform.position + impulse);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
            //StartCoroutine(VibrateRoutine(impulse.magnitude));
            
            //Vibration.Vibrate(50, 20, true);

        }
    }

    IEnumerator VibrateRoutine(float impulseForce)
    {
        var startTime = Time.time;
        var delay = 0.2f;//Mathf.Pow(impulseForce, 0.2f) - 0.8f;
        while (startTime + delay > Time.time)
        {
            yield return null;
            //Handheld.Vibrate();
        }
    }
    
}
