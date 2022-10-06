using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float MaxSpeed;
    [SerializeField] float movementDirection;

    public float TimeBetweenGold { get; private set; }
    [SerializeField] float speed;
    Rigidbody2D _rb;


    [Range(1, 100)] [SerializeField] int ChanceChangeDirection;

    [Range(1, 100)] [SerializeField] int ChanceChangeSpeed;

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
            _rb.AddForce((new Vector2(movementDirection, 0)) * speed * 2);

            if (Random.Range(1, 100) < ChanceChangeDirection)
            {
                movementDirection *= -1;

                if (Random.Range(0, 100) < 30)
                {
                    speed = Random.Range(0, MaxSpeed);
                }
                else if (Random.Range(0, 100) < 5)
                {
                    speed = MaxSpeed;
                }
            }

            if (Random.Range(0, 100) < ChanceChangeSpeed)
            {
                speed = Random.Range(0, MaxSpeed);
            }
        }
    }

    /*private IEnumerator GenerateGold()
    {

    }*/
}
