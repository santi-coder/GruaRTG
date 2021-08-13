using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioScenaDos : MonoBehaviour
{

    public Image fundido;
    public GameObject goPlayerList;
    public SelectIndumentaria scriptGoPlayer;
    public GameObject textoSalida; 

    void Start()
    {
        fundido.CrossFadeAlpha(0, 1.0f, false);
        scriptGoPlayer = goPlayerList.GetComponent<SelectIndumentaria>();
        textoSalida.SetActive(false);
    }

    
    void Update()
    {
        if (scriptGoPlayer.Comprobacion.Count == 3)
        {
            textoSalida.SetActive(true);           
        }    
    }

   



    void OnTriggerEnter()
    {
        if (scriptGoPlayer.Comprobacion.Count == 3)
        {
            StartCoroutine(CambioDeScena());
        }
    }

    IEnumerator CambioDeScena()
    {
        scriptGoPlayer.Comprobacion.Remove(2);
        textoSalida.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        fundido.CrossFadeAlpha(1, 1.0f, false);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("SubirGrua");
    }
}
