using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaControlCamara : MonoBehaviour
{

    public float velHorizontal = 2.0f;
    public float velVertical = 2.0f;
    public float limitVerticalMax = 10.0f;
    public float limitVerticalMin = -60.0f;
    public float limitHorizontalMax = -50.0f;
    public float limitHorizontalMin = -130.0f;
    float horizontalMouse; 
    float verticalMouse;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        horizontalMouse += velHorizontal * Input.GetAxis("Mouse X");
        verticalMouse += velVertical *  Input.GetAxis("Mouse Y");

        verticalMouse = Mathf.Clamp(verticalMouse, limitVerticalMin, limitVerticalMax);
        horizontalMouse = Mathf.Clamp(horizontalMouse, limitHorizontalMin, limitHorizontalMax);

        transform.localEulerAngles = new Vector3(-verticalMouse, horizontalMouse, 0.0f);
    }
}
