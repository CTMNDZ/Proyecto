using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CARGANDO ESCENA");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickPlay()
    {
        Debug.Log("SE PRESIONO EL BOTON PLAY");
        
        SceneManager.LoadScene(1);
    }

     public void OnClickCredits()
    {
        Debug.Log("SE PRESIONO EL BOTON PLAY");
        
        SceneManager.LoadScene(2);
    }

    public void OnClickMenu()
    {
        Debug.Log("SE PRESIONO EL BOTON PLAY");
        
        SceneManager.LoadScene(0);
    }


    public void OnResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
