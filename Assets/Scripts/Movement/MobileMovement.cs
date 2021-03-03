using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class MobileMovement : MonoBehaviour
{
    private Gyroscope _gyro;
    public TextMeshProUGUI gyroTxt;

    void Start()
    {
        _gyro = Input.gyro;
        _gyro.enabled = true;
        gyroTxt.text= "testing";
    }

    void Update()
    {
        gyroTxt.text = 
            "x: " + Math.Floor(_gyro.attitude.x * 100) + 
            "\ny: " + Math.Floor(_gyro.attitude.y * 100) + 
            "\nz: " + Math.Floor(_gyro.attitude.z * 100);
    }
}
