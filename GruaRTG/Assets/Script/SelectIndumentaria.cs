using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIndumentaria : MonoBehaviour
{
    [Header("Opciones Raycast")]
    LayerMask mask;
    float distancia = 2.5f;

    [Header("Opciones GameObject")]
    private GameObject personajeInicial;
    private Transform trPersonajeInicial;
    private GameObject operadorGrua;
    private Transform trOperadorGrua;

    [Header("Opciones de UI")]
    public GameObject texto;
    GameObject ultimoReconocido = null;
    //public Texture2D puntero;

    public List<int> Comprobacion = new List<int>();
    
 

    void Start()
    {
        mask = LayerMask.GetMask("RaycastDetected");
        
        personajeInicial = GameObject.Find("PersonajeInicio");
        trPersonajeInicial = personajeInicial.GetComponent<Transform>();

        operadorGrua = GameObject.Find("PersonajeGrua");
        trOperadorGrua = operadorGrua.GetComponent<Transform>();

        texto.SetActive(false);
    }

   
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia, mask))
        {
            Deselected();
            SelectedObjects(hit.transform);

            if (hit.collider.tag == "Pantalones" && Input.GetKey(KeyCode.E))
            {
                trPersonajeInicial.GetChild(2).gameObject.SetActive(false);
                trOperadorGrua.GetChild(5).gameObject.SetActive(true);
                hit.collider.gameObject.SetActive(false);
                Comprobacion.Add(1);
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
                Comprobacion.Add(2);
            }

            if (hit.collider.tag == "Botas" && Input.GetKey(KeyCode.E))
            {
                trPersonajeInicial.GetChild(3).gameObject.SetActive(false);
                trOperadorGrua.GetChild(1).gameObject.SetActive(true);
                hit.collider.gameObject.SetActive(false);
                Comprobacion.Add(3);
            }
        } 
        else
        {
            Deselected();
        }
    }

    void SelectedObjects(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.green;
        ultimoReconocido = transform.gameObject;
    }

    void Deselected()
    {
        if (ultimoReconocido != null)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

    void OnGUI()
    {
        //Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        //GUI.DrawTexture(rect, puntero);
        
        if (ultimoReconocido != null)
        {
            texto.SetActive(true);
        }
        else
        {
            texto.SetActive(false);
        }

    }
}
