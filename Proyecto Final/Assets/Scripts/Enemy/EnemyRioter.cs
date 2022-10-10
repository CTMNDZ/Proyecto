using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   public class EnemyRioter : EnemyStalker
{

    protected override void Move()
    {
        LookPlayer();
        // Rotate Around permite "orbitar" al rededor de una posición.
        transform.RotateAround(PlayerTransform.position, Vector3.up, 3f * Time.deltaTime);
    }

}