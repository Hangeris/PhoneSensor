using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroSensor : MonoBehaviour
{
    [SerializeField] float roomRotateSpeed = 10f;
    [SerializeField] Transform roomT;

    [SerializeField] Slider slider;
    
    bool gyroEnabled;
    Gyroscope gyro;
    GameObject gyroControl;
    Quaternion rot;

    Quaternion correctionQuaternion;
    Quaternion calibratedQuaternion;

    [SerializeField] Rigidbody rb;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        gyroEnabled = EnableGyro();
        BTN_CalibrateGyroGravity();
        
        correctionQuaternion = Quaternion.Euler(90f, 0f, 0f);
    }

    void Update()
    {
        if (gyroEnabled)
        {
            GyroModifyCamera();
            
            Shake();
        }
    }

    public void BTN_CalibrateGyroGravity()
    {
        if (gyro == null)
            return;
        
        calibratedQuaternion = correctionQuaternion * GyroToUnity(gyro.attitude);
    }
    
    public void BTN_ResetRoomRotation()
    {
        roomT.transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    
    static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
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
    

    
    void Shake()
    {
        var shakeAmount = gyro.userAcceleration.magnitude;
        if (shakeAmount > 2)
            Debug.Log($"shakeAmount: {shakeAmount}");
    }
    
    void GyroModifyCamera()
    {
        var gyroX = -gyro.rotationRateUnbiased.x;
        var gyroY = -gyro.rotationRateUnbiased.y;

        var gyroVelocity = new Vector3(gyroX, gyroY, 0);
        if (gyroVelocity.magnitude >= .5f)
        {
            rb.AddTorque(gyroVelocity * 10, ForceMode.VelocityChange);
            Debug.DrawLine(roomT.position, roomT.position + gyroVelocity, Color.magenta, 0.5f);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
    
}
