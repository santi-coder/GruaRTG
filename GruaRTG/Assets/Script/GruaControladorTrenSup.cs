using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruaControladorTrenSup : MonoBehaviour
{

    private Rigidbody rb;
    public float empujeCarro = 340.0f;
    public GameObject acopleCont;
    public Rigidbody rbAcopleCont;
    public float fuerzaVertical = 1000.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rbAcopleCont = acopleCont.GetComponent<Rigidbody>();

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            rb.AddForce(-empujeCarro, 0, 0);
        }
        if (Input.GetKey(KeyCode.M))
        {
            rb.AddForce(empujeCarro, 0, 0);
        }
        if (Input.GetKey(KeyCode.V))
        {
            rbAcopleCont.AddForce(0, fuerzaVertical, 0);
        }
        if (Input.GetKey(KeyCode.B))
        {
            rbAcopleCont.AddForce(0, -fuerzaVertical, 0);
        }
    }
}