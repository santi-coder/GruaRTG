using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIndumentaria : MonoBehaviour
{
    [Header("Opciones Raycast")]
    LayerMask mask;
    float distancia = 5.0f;

    [Header("Opciones GameObject")]
    private GameObject personajeInicial;
    private Transform trPersonajeInicial;
    private GameObject operadorGrua;
    private Transform trOperadorGrua; 
    
 

    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetected");
        
        personajeInicial = GameObject.Find("PersonajeInicio");
        trPersonajeInicial = personajeInicial.GetComponent<Transform>();

        operadorGrua = GameObject.Find("PersonajeGrua");
        trOperadorGrua = operadorGrua.GetComponent<Transform>();
    }

   
    void Update()
    {
       
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Debug.Log("estoy por fuera");
            
            if (hit.collider.tag == "Pantalones" && Input.GetKey(KeyCode.E))
            {
                trPersonajeInicial.GetChild(2).gameObject.SetActive(false);
                trOperadorGrua.GetChild(5).gameObject.SetActive(true);
                hit.collider.gameObject.SetActive(false);
            }

            if (hit.collider.tag == "Chaleco" && Input.GetKey(KeyCode.E))
            {
                trPersonajeInicial.GetChild(0).gameObject.SetActive(false);
                trPersonajeInicial.GetChild(1).gameObject.SetActive(false);
                trPersonajeInicial.GetChild(4).gameObject.SetActive(false);
                trOperadorGrua.GetChild(0).gameObject.SetActive(true);
                trOperadorGrua.GetChild(3).gameObject.SetActive(true);
                trOperadorGrua.GetChild(4).gameObject.SetActive(true);
                trOperadorGrua.GetChild(6).gameObject.SetActive(true);
                trOperadorGrua.GetChild(7).gameObject.SetActive(true);
                hit.collider.gameObject.SetActive(false);
            }

            if (hit.collider.tag == "Botas" && Input.GetKey(KeyCode.E))
            {
                trPersonajeInicial.GetChild(3).gameObject.SetActive(false);
                trOperadorGrua.GetChild(1).gameObject.SetActive(true);
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
