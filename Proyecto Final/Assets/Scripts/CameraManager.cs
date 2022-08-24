using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] cameras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         if (Input.GetKeyDown(KeyCode.J))
        {
            cameras[0].SetActive(true);
            cameras[1].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);
        }
        
    }
}