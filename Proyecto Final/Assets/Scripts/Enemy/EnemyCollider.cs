using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameManager.Score++;
            Debug.Log(GameManager.Score);
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
