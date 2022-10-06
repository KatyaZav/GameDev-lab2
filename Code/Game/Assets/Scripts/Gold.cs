using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour, ICollectable
{
    [SerializeField] GameObject disapearEffectPrefab;

    public void Pick()
    {
        Debug.Log("Pick gold");
        Destroy(gameObject);
    }

    public void Disapear()
    {
        var explosion = Instantiate(disapearEffectPrefab);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    }
}
