using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update    
    private PlayerData playerData;

    [SerializeField]
    [Range(0, 2)]
    private float Cooldown;

    [SerializeField]
    Transform[] Teleporters;

    [SerializeField] MunitionManager munitionManager;

    private float TimeTouchEnemy = 0;

    private bool Touch = true;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        TimeTouchEnemy = 0;
        playerData.Points = 0;
        HudManager.SetHPBar(playerData.HP);
        
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerData.Damage(other.gameObject.GetComponent<Enemy>().DamagePoints);
        }
        
        if (other.gameObject.CompareTag("Powerups"))
        {
            Destroy(other.gameObject);
            //sumar vida
            playerData.Healing(other.gameObject.GetComponent<Life>().HealPoints);
            HudManager.SetHPBar(playerData.HP);

            //SUMAS SCORE
        }

        if (other.gameObject.CompareTag("Points"))
        {
            Destroy(other.gameObject);
            GameManager.Score++;
            Debug.Log(GameManager.Score);
            if (GameManager.Score >= 5)
            {
                Debug.Log("YOU WIN!");
            }
        }
        
         if (other.gameObject.CompareTag("Munition"))
        {
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<Munition>().DamagePoints);
            HudManager.SetHPBar(playerData.HP);
            Destroy(other.gameObject);
            if (playerData.HP <= 0)
            {
                Debug.Log("GAME OVER");
            }

            if (!munitionManager.MunitionDirectory.ContainsKey(other.gameObject.name))
            {
                munitionManager.MunitionDirectory.Add(other.gameObject.name, other.gameObject);
                Debug.Log(munitionManager.MunitionDirectory[other.gameObject.name]);
            }

            GameManager.Score--;
            Debug.Log(GameManager.Score);
        }
    }

    private void OnCollisionStay(Collision collision) 
    {
        if(TimeTouchEnemy >= Cooldown && Touch)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Touch = false;
                playerData.Kill(collision.gameObject.GetComponent<Enemy>().DamagePoints);
            }
            
        } else if (TimeTouchEnemy >= Cooldown && Touch == false)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Touch = true;
                playerData.Kill(collision.gameObject.GetComponent<Enemy>().DamagePoints);
                Debug.Log("GAME OVER");
            }
        }
        
    }

     private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            munitionManager.MunitionList.Add(other.gameObject);
        }
    }
}
