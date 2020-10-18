using System;
using System.Collections;
using System.Collections.Generic;
using RDG;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Controller controller;

    void Start()
    {
        controller = FindObjectOfType<Controller>();
    }
    
    void OnCollisionEnter(Collision other)
    {
        var impulse = other.impulse;

        if (impulse.magnitude > 0.5f)
        {
            Debug.Log($"Impulse magnitude: {impulse.magnitude}");
            var ray = new Ray(transform.position, transform.position + impulse);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
            
            controller.BallHit();
        }
    }

    
}
