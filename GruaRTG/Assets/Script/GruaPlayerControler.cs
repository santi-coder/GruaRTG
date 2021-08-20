using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaPlayerControler : MonoBehaviour
{
    public WheelCollider[] WCs;
    public GameObject[] Ruedas;
    public GameObject[] TrenMotriz;
    public float torqueMotor = 200.0f;
    public float angMaximo = 90.0f;
    public GameObject conjuntoUno;
    public float fuerzaFrenado = 300.0f;
    public Rigidbody rgVelocidad;
    public float velocidad;
    
    void Start()
    {
        rgVelocidad = this.gameObject.GetComponent<Rigidbody>();            
    }

    void Update()
    {
        velocidad = rgVelocidad.velocity.magnitude * 3600 / 1000;
        
        float a = Input.GetAxis("Horizontal");
        AvanceRetroceso(a);
        

        float b = Input.GetAxis("Vertical");
        GirarRuedas(b);

        bool frenar = Input.GetKey(KeyCode.Space);
        Frenado(frenar);
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
                WCs[i].GetWorldPose(out posicion, out angRotacion);

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
            TrenMotriz[i].transform.rotation = Quaternion.AngleAxis((Input.GetAxis("Vertical") * angMaximo), Vector3.up);

        }
    }

    void Frenado(bool f)
    {
        if (f == true || velocidad >= 3.7f)
        {
            for (int i = 0; i < WCs.Length; i++)
            {
                WCs[i].brakeTorque = fuerzaFrenado;
            }
        }
        else 
        {
            for (int i = 0; i < WCs.Length; i++)
            {
                WCs[i].brakeTorque = 0.0f;
            }    
        }   
    }

}
