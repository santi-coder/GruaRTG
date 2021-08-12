using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevantarBarreras : MonoBehaviour
{

    public GameObject texto1;
    public GameObject texto2;

    public GameObject salaControl;
    public Transform trSalaControl;

    void Start()
    {
        texto1.SetActive(false);
        texto2.SetActive(false);

        salaControl = GameObject.Find("TorreDeControl");
        trSalaControl = salaControl.GetComponent<Transform>().GetChild(0).transform;

    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        texto1.SetActive(true);
        StartCoroutine(MecanicaInicio());
            
    }

    IEnumerator MecanicaInicio()
    {
        yield return new WaitForSeconds(3.5f);
        texto1.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        texto2.SetActive(true);
        trSalaControl.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(9.0f);
        texto2.SetActive(false);
        trSalaControl.GetComponent<MeshRenderer>().material.color = Color.gray;
        yield return new WaitForSeconds(1.0f);
        
    }
}
