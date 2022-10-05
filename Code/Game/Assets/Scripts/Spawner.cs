using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float MaxSpeed;
    [SerializeField] float movementDirection;

    [SerializeField] float speed;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speed = MaxSpeed;

        StartCoroutine(Moving());
    }

    private IEnumerator Moving()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();

            //transform.Translate((new Vector2(movementDirection, 0)) * MaxSpeed * Time.fixedDeltaTime);
            _rb.AddForce((new Vector2(movementDirection, 0)) * MaxSpeed*2);

            if (Random.Range(1, 100) < 4)
            {
                movementDirection *= -1;
            }
           
            if (Random.Range(0, 100) < 10)
            {
                speed = Random.Range(0, MaxSpeed);
            }
        }
    }
}
