using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        var movement = new Vector2(x, 0);

        Debug.Log(movement);
        _rb.AddForce(movement * speed);
        //transform.Translate(movement * speed * Time.fixedDeltaTime);
    }
}
