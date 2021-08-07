using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirEscaleraVertical : MonoBehaviour
{
    
     private GameObject plataforma;
     private Transform plataformaTransform;
            
    
    void Start()
    {
        plataforma = GameObject.Find("Plataforma");
        plataformaTransform = plataforma.GetComponent<Transform>();   
    }

    
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        PlayerControler scriptOther = other.GetComponent<PlayerControler>();
        scriptOther.walkSpeed = 0;
        scriptOther.gravity = 0;
        

        if (Input.GetKey(KeyCode.W))
        {
            scriptOther.animator.SetBool("Escalera", true);
            plataformaTransform.Translate(Vector3.up * 0.5f *Time.deltaTime);
            Debug.Log(plataformaTransform.position.y);
            
            if (plataformaTransform.position.y > 5.0f)
            {
                scriptOther.walkSpeed = 2.5f;
                scriptOther.gravity = 20.0f;       
            }
            
        }
        
    }
}
