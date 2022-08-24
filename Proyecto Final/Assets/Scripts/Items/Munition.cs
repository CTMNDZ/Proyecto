using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    [SerializeField]
    [Range(2, 10)]
    private int damagePoints = 1;
    public int DamagePoints { get { return damagePoints; } }
}
