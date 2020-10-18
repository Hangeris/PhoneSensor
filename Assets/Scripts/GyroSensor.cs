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
            
            // GyroRotation();
            //
            Shake();
        }
    }

    public void BTN_CalibrateGyroGravity()
    {
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
        

        
        //roomT.Rotate(gyroX, gyroY, 0);
            
            
        //roomT.rotation = new Quaternion(0, 0, -gyro.attitude.z, gyro.attitude.w);
            
            
        // Vector3 previousEulerAngles = roomT.eulerAngles;
        // Vector3 gyroInput = -Input.gyro.rotationRateUnbiased; //Not sure about the minus symbol (untested)
        //
        // Vector3 targetEulerAngles = previousEulerAngles + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
        // targetEulerAngles.z = 0.0f;
        //
        // roomT.eulerAngles = targetEulerAngles;
            
            
            
        // Vector3 gyroEuler = Input.gyro.attitude.eulerAngles;
        // roomT.eulerAngles = new Vector3(-1.0f * gyroEuler.x, -1.0f * gyroEuler.y, gyroEuler.z);
        //
        // Vector3 upVec = roomT.transform.InverseTransformDirection(-1f * Vector3.forward);
        //
        // Debug.DrawLine(transform.position, upVec, Color.magenta, 0.5f);
        
        
        
        // var gyroQuaternion = correctionQuaternion * GyroToUnity(gyro.attitude);
        // Debug.Log(gyroQuaternion);
        //
        //
        // Debug.DrawRay(transform.position, transform.position + gyroQuaternion.eulerAngles.normalized, Color.blue, 0.5f);
      
        
        
        // var gyroQuaternion = GyroToUnity(gyro.attitude);
        // // rotate coordinate system 90 degrees. Correction Quaternion has to come first
        // var correctedQuaternion = correctionQuaternion * gyroQuaternion;
        // var sliderRotatedQuaternion = Quaternion.Euler(Vector3.right * slider.value) * correctedQuaternion;
        // sliderRotatedQuaternion = sliderRotatedQuaternion * calibratedQuaternion;
        // roomT.rotation = sliderRotatedQuaternion;
    }



    
    // void GyroRotation()
    // {
    //     
    //     // var currentGyroCalibratedRot = gyroCalibratedGravity.eulerAngles;
    //     // var currentGyroRot = gyro.attitude.eulerAngles;
    //
    //     var grav = gyro.gravity;
    //
    //     Debug.Log($"gyro.gravity: {grav}");
    //     
    //     
    //     //Debug.Log($"currentGyroCalibratedPos: {currentGyroCalibratedRot}");
    //     var difference = gyroCalibratedGravity - grav;
    //     Debug.Log($"difference: {difference.magnitude}");
    //     //roomT.localRotation = gyro.attitude * rot;
    //
    //     if (difference.magnitude > 0.5f)
    //     {
    //         roomT.Rotate(difference.normalized * Time.deltaTime * roomRotateSpeed);
    //     }
    //     
    //     Ray ray2 = new Ray(transform.position, difference);
    //     Debug.DrawLine(ray2.origin, ray2.origin + difference, Color.blue, 0.5f);
    //     
    //     // Ray ray1 = new Ray(transform.position, att.normalized);
    //     // Debug.DrawRay(ray1.origin, ray1.direction, Color.black, 0.5f);
    //     //
    //     // Ray ray3 = new Ray(transform.position, rotRate.normalized);
    //     // Debug.DrawRay(ray3.origin, ray3.direction, Color.magenta, 0.5f);
    //     //
    //     // Ray ray4 = new Ray(transform.position, rotRateUnbaias.normalized);
    //     // Debug.DrawRay(ray4.origin, ray4.direction, Color.red, 0.5f);
    //
    //
    // }
    //

    
    
}
