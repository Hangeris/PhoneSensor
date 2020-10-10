using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroSensor : MonoBehaviour
{
    [SerializeField] float roomRotateSpeed = 10f;
    [SerializeField] Transform roomT;

    bool gyroEnabled;
    Gyroscope gyro;
    GameObject gyroControl;
    Quaternion rot;

    Vector3 gyroCalibratedGravity;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        gyroEnabled = EnableGyro();
        BTN_CalibrateGyroGravity();
    }

    void Update()
    {
        if (gyroEnabled)
        {
            GyroRotation();
       
            Shake();
        }
        

    }

    public void BTN_CalibrateGyroGravity()
    {
        gyroCalibratedGravity = gyro.gravity;
    }
    
    public void BTN_ResetRoomRotation()
    {
        roomT.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    

    
    
    void GyroRotation()
    {
        
        // var currentGyroCalibratedRot = gyroCalibratedGravity.eulerAngles;
        // var currentGyroRot = gyro.attitude.eulerAngles;

        var grav = gyro.gravity;

        Debug.Log($"gyro.gravity: {grav}");
        
        
        //Debug.Log($"currentGyroCalibratedPos: {currentGyroCalibratedRot}");
        var difference = gyroCalibratedGravity - grav;
        Debug.Log($"difference: {difference.magnitude}");
        //roomT.localRotation = gyro.attitude * rot;

        if (difference.magnitude > 0.5f)
        {
            roomT.Rotate(difference.normalized * Time.deltaTime * roomRotateSpeed);
        }
        
        Ray ray2 = new Ray(transform.position, difference);
        Debug.DrawLine(ray2.origin, ray2.origin + difference, Color.blue, 0.5f);
        
        // Ray ray1 = new Ray(transform.position, att.normalized);
        // Debug.DrawRay(ray1.origin, ray1.direction, Color.black, 0.5f);
        //
        // Ray ray3 = new Ray(transform.position, rotRate.normalized);
        // Debug.DrawRay(ray3.origin, ray3.direction, Color.magenta, 0.5f);
        //
        // Ray ray4 = new Ray(transform.position, rotRateUnbaias.normalized);
        // Debug.DrawRay(ray4.origin, ray4.direction, Color.red, 0.5f);


    }

    void Shake()
    {
        var shakeAmount = gyro.userAcceleration.magnitude;
        Debug.Log($"shakeAmount: {shakeAmount}");
    }

    bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
 
            return true;
        }
        return false;
    }
    
    
    
}
