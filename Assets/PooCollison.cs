using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooCollison : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy enemies that touch it.
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ducks"))
        {
            Destroy(collision.gameObject);
        }

        // Self Destruct
        Destroy(gameObject);
    }
}
