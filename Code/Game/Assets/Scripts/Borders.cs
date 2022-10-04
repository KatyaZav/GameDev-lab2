using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    private enum direction
    {
        left = -1,
        right = 1
    };

    [SerializeField] direction _direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((int)_direction, 0));  
    }
}
