using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
[SerializeField]
    [Range(1f, 10f)]
    private float speed = 3f;
    private float rotSpeed;
    private float cameraAxisX = 0f;
    [SerializeField] Animator playerAnimator;

    private Vector3 playerDirection;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
            if (!IsAnimation("Run")) playerAnimator.SetTrigger("Run");
        }

        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
            if (!IsAnimation("Run")) playerAnimator.SetTrigger("Run");
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(Vector3.left);
            if (!IsAnimation("Run")) playerAnimator.SetTrigger("Run");
        }

        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(Vector3.right);
            if (!IsAnimation("Run")) playerAnimator.SetTrigger("Run");
        }
        if (playerDirection == Vector3.zero)
        {
            if (!IsAnimation("Idle")) playerAnimator.SetTrigger("Idle");
        }
    }

    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    private void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RotatePlayer()
    {
 
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2.5f * Time.deltaTime);
    }
}

