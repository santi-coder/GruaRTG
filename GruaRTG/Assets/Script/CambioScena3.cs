using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioScena3 : MonoBehaviour
{

    public Image fundido;


    void Start()
    {
        fundido.CrossFadeAlpha(0, 1.0f, false);
    }

    void OnTriggerEnter()
    {
        StartCoroutine(CambioDeScena());
    }

    IEnumerator CambioDeScena()
    {
        yield return new WaitForSeconds(1.5f);
        fundido.CrossFadeAlpha(1, 1.0f, false);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("OperarGrua");
    }  
}

