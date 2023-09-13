using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entered Collider");
        if (collision.gameObject.name == "Duck")
        {
            Debug.Log("Hit a duck");
            Destroy(gameObject);
        }
    }
}
