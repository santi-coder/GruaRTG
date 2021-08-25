using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcopleContenedores : MonoBehaviour
   
{
    public Rigidbody rbAcopleCont;
    void Start()
    {
        rbAcopleCont = gameObject.GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        FixedJoint fj = other.gameObject.GetComponent<FixedJoint>();
        fj.connectedBody = rbAcopleCont;
        Debug.Log("sanntuuu");
    }

}
