using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaPlayerControler : MonoBehaviour
{
    public WheelCollider[] WCs;
    public GameObject[] Ruedas;
    public GameObject[] TrenMotriz;
    public float torqueMotor = 100.0f;
    public float angMaximo = 90.0f;
    public GameObject conjuntoUno;
    
    void Start()
    {
                
    }

    void Update()
    {
        float a = Input.GetAxis("Vertical");
        AvanceRetroceso(a);

        
        float b = Input.GetAxis("Horizontal");
        GirarRuedas(b);

        
        
    }

    void AvanceRetroceso(float a) 
    {
        a = Mathf.Clamp(a, -1, 1);
        float torqueRuedas = a * torqueMotor;

        for (int i = 0; i < WCs.Length; i++)
        {
            WCs[i].motorTorque = torqueRuedas;

            Quaternion angRotacion;
            Vector3 posicion; 
            WCs[i].GetWorldPose(out posicion ,out angRotacion);

            Ruedas[i].transform.position = posicion;
            Ruedas[i].transform.rotation = angRotacion;
        }
    }

    void GirarRuedas(float ang)
    {
        ang = Mathf.Clamp(ang, -1, 1) * angMaximo;

        for (int i = 0; i < WCs.Length; i++)
        {
            WCs[i].steerAngle = ang;
            TrenMotriz[i].transform.rotation = Quaternion.AngleAxis((Input.GetAxis("Horizontal") * angMaximo), Vector3.up);

        }
    }

}
