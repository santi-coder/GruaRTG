using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaPlayerControler : MonoBehaviour
{
    public WheelCollider wc;
    public float torqueMotor = 0;

    void Start()
    {
        wc = GetComponent<WheelCollider>();    
    }

    void Update()
    {
        wc.motorTorque = torqueMotor;    
    }
}
