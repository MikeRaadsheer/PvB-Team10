using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class MobileMovement : MonoBehaviour
{
    // Singleton Instance
    public static MobileMovement Instance;

    private Gyroscope _gyro;
    private Vector3 _acceleration;

    public TextMeshProUGUI gyroTxt;
    public TextMeshProUGUI accelerationTxt;

    private void Awake()
    {
        // Singleton
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    void Start()
    {
        _gyro = Input.gyro;
        _gyro.enabled = true;
        gyroTxt.text= "testing";
    }

    void Update()
    {
        _acceleration = Input.acceleration;
        _acceleration = Quaternion.Euler(90f, 0f, 0f) * _acceleration;
        
        gyroTxt.text = 
            "x: " + Math.Floor(_gyro.attitude.x * 100) + 
            "\ny: " + Math.Floor(_gyro.attitude.y * 100) + 
            "\nz: " + Math.Floor(_gyro.attitude.z * 100);

        accelerationTxt.text =
            "x: " + Math.Floor(_acceleration.x * 100) +
            "\ny: " + Math.Floor(_acceleration.y * 100) +
            "\nz: " + Math.Floor(_acceleration.z * 100);
    }

    //public class Singleton
    //{
    //    private static Singleton instance = null;
    //    private Singleton() { }

    //    public static Singleton Instance
    //    {
    //        get 
    //        { 
    //            if(instance == null)
    //            {
    //                instance = new Singleton();
    //            }
    //            return instance; 
    //        }
    //    }
    //}
}
