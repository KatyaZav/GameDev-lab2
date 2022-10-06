using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            Debug.Log("Deleted " + collision.gameObject.ToString());
            ICollectable obj = collision.gameObject.GetComponent<ICollectable>();
            obj.Disapear();
        }
        catch(System.Exception e)
        {
            Debug.LogWarning("Fall something non ICollectible! " + e + " " + collision.gameObject.ToString());
            Destroy(collision.gameObject);
        }
    }
}
