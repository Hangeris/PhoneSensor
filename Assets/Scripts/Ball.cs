using System;
using System.Collections;
using System.Collections.Generic;
using RDG;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    Controller controller;
    Vector3 startPos;

    void Awake()
    {
        startPos = transform.position;
        
        controller = FindObjectOfType<Controller>();
        controller.Register(this);
    }

    void Update()
    {
        HandleBallOutOfRoom();

    }

    void OnCollisionEnter(Collision other)
    {
        var impulse = other.impulse;

        if (impulse.magnitude > 2)
        {
            Debug.Log($"Impulse magnitude: {impulse.magnitude}");
            var ray = new Ray(transform.position, transform.position + impulse);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
            
            controller.BallHit();
        }
    }
    
    void HandleBallOutOfRoom()
    {
        if (transform.position.y < -30)
        {
            transform.position = startPos;
        }
    }

    
}
