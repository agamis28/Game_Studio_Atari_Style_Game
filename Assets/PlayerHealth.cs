using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header ("** Positions **")]
    private Transform playerTransform;
    public Vector2 respawnPoint;
    public Vector2 deathPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerDied()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Move player out of screen.
        // Delay
        // Lower Lives & Respawn Player Function
    }
}
