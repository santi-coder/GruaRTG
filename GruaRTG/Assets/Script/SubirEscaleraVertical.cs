using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirEscaleraVertical : MonoBehaviour
{
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        PlayerControler scriptOther = other.GetComponent<PlayerControler>();
        scriptOther.walkSpeed = 0;
        scriptOther.gravity = 0;
        //scriptOther.move = new Vector3(0, 3.0f,0);
        

        if (Input.GetKey(KeyCode.W))
        {
            /*Transform transformPersonaje = other.GetComponent<Transform>();
            transformPersonaje.Translate(Vector3.up * 10 * Time.deltaTime);
            Debug.Log("entre"); */
 
            GameObject plataforma;
            Transform plataformaTransform;

            plataforma = GameObject.Find("Plataforma");
            plataformaTransform = plataforma.GetComponent<Transform>();
            plataformaTransform.Translate(Vector3.up *1 *Time.deltaTime);
            
        }
        
    }
}
