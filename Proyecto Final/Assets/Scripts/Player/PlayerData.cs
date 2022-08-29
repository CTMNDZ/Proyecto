using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    [Range(1,3)]
    private int live = 3;
    public int HP { get { return live; } }

    public int Points = 0;

    public void Start()
    {
        Points = 0;
    }
    
    
    public void Damage(int value)
    {
        live -= value;
    }
    public void Shrink()
    {
        transform.localScale = new Vector3(1,1,1);
    }

    public void Kill (int value)
    {
        live -= 3;
    }
    public void Healing(int value)
    {
        Points += value;
    }
    public void Score(int value)
    {
        live += value;
    }
}
