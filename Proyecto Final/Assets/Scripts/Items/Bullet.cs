using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  [SerializeField]
    [Range(2, 10)]
    private int damagePoints = 2;
    public int DamagePoints { get { return damagePoints; } }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            {
                GameManager.Score++;
                Debug.Log(GameManager.Score);
                Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
                Destroy(other.gameObject);
            }
    }
}
