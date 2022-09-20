using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    protected EnemyData enemyData;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    public void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.TransformDirection(Vector3.forward), out hit,enemyData.RangeAttack))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("ATACAR AL JUGADOR");
            }
        }
    }
    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * enemyData.speed * Time.deltaTime);
    }

    public void DrawRaycast()
    {
        Gizmos.color = Color.blue;
        Vector3 directionRay = transform.TransformDirection(Vector3.forward) * enemyData.RangeAttack;
        Gizmos.DrawRay(transform.position + Vector3.up, directionRay);
    }
}
