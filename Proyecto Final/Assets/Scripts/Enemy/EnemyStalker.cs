using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStalker : Enemies
{
    // Start is called before the first frame update
   [SerializeField] Transform playerTransform;

    private float speed = 2f;

    public Transform PlayerTransform { get => playerTransform; }

    protected override void Move()
    {
        //base.Move();
        LookPlayer();

        Vector3 direction = (playerTransform.position - transform.position);

        if (direction.magnitude > 0.1f)
        {

           transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    protected void LookPlayer()
    {
        // Método para rotar "inmediatamente" hacia un trasform.
        //transform.LookAt(playerTransform);
        // Forma para rotar "gradualmente" hacia un trasform.
        Quaternion newRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5f * Time.deltaTime);
    }
}
