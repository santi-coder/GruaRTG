using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcopleContenedores : MonoBehaviour
   
{
    public Rigidbody rbAcopleCont;
    public bool soltarCont = false;
    public FixedJoint fj;
    public Rigidbody rbBrazoIzq;
    public Rigidbody rbBrazoDer;
    public float fuerzaUnas = 100.0f;

    void Start()
    {
        rbAcopleCont = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            rbBrazoIzq.AddForce(0, 0, -fuerzaUnas);
            rbBrazoDer.AddForce(0, 0, fuerzaUnas);
        }
        if (Input.GetKey(KeyCode.K))
        {
            rbBrazoIzq.AddForce(0, 0, fuerzaUnas);
            rbBrazoDer.AddForce(0, 0, -fuerzaUnas);
        }
    }

    void OnTriggerStay(Collider other)
    {
        fj = other.gameObject.GetComponent<FixedJoint>();
        
        if (Input.GetKey(KeyCode.E))
        {
            fj.connectedBody = rbAcopleCont;            
        }
        if (Input.GetKey(KeyCode.R))
        {
            fj.connectedBody = null;
        }
    }

}
