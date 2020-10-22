using System;
using System.Collections;
using System.Collections.Generic;
using RDG;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    Controller controller;
    Vector3 startPos;
    Color randomColor;

    void Awake()
    {
        Init();
    }

    void Update()
    {
        HandleBallOutOfRoom();
    }

    void OnCollisionEnter(Collision other)
    {
        var impulse = other.impulse;

        if (impulse.magnitude > 1)
        {
            Debug.Log($"Impulse magnitude: {impulse.magnitude}");
            var ray = new Ray(transform.position, transform.position + impulse);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);
            
            controller.BallCollisionEnter(randomColor);
        }
    }
    
    void Init()
    {
        // Register the ball
        controller = FindObjectOfType<Controller>();
        controller.Register(this);
        
        // Get respawn position
        startPos = transform.position;
        
        // Generate random color
        randomColor = Random.ColorHSV(0, 1, 1, 1);
        meshRenderer.material.color = randomColor;
    }
    
    void HandleBallOutOfRoom()
    {
        if (transform.position.y < -30)
        {
            transform.position = startPos;
        }
    }

    
}
