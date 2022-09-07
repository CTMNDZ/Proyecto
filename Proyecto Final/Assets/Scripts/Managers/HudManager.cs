using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    private static HudManager instance;
    public static HudManager Instance { get => instance; }

    [SerializeField] private Slider hpBar;
    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
     public static void SetHPBar(int newValue)
    {
        instance.hpBar.value = newValue;
    }

    
}
