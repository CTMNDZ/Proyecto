using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    public float speed = 2f;

    public float liveTime = 3f;

    void Start()
    {
        Invoke("DestroyDelay", liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
