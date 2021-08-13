using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioScenaInicial : MonoBehaviour
{

    public Image fundido; 


    void Start()
    {
        fundido.CrossFadeAlpha(0, 1.0f, false);            
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        StartCoroutine(CambioDeScena());
    }

    IEnumerator CambioDeScena()
    {
        fundido.CrossFadeAlpha(1, 1.0f, false);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("ColocarIndumentaria");
    }
}
