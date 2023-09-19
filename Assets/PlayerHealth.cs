using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[Header("** Positions **")]
	public Transform playerTransform;
	public Vector2 respawnPoint;
	public Vector2 deathPoint = new Vector2(-15, -15);

	[Header ("** References **")]
	public GameObject extraLifePrefab;
	private PlayerMovementPhysics playerMovement;
	private CapsuleCollider2D playerCollider;

	[Header ("** Stats **")]
	public int livesCount = 3;
	public float respawnDelay = 5f;
	public int extraLives = 0;
	public int maxLives = 5;

	[Header("** Player Lives **")]
	public GameObject playerLife1;
    public GameObject playerLife2;
    public GameObject playerLife3;
	public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
	{
		playerTransform = transform;
		playerMovement = GetComponent<PlayerMovementPhysics>();
		playerCollider = GetComponent<CapsuleCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		switch (livesCount)
		{
			case 3:
				playerLife3.SetActive(true);
                playerLife2.SetActive(true);
                playerLife1.SetActive(true);
                break;
			case 2:
				playerLife3.SetActive(false);
                playerLife2.SetActive(true);
                playerLife1.SetActive(true);
                break;
			case 1:
				playerLife3.SetActive (false);
                playerLife2.SetActive(false);
                playerLife1.SetActive(true);
                break;
			case 0:
                playerLife3.SetActive(false);
                playerLife2.SetActive(false);
                playerLife1.SetActive(false);
                deathScreen.SetActive(true);
				playerMovement.enabled = false;
				break;
		}

	}

	void PlayerDied()
	{
		// Respawn in respawn position, if player still has lives
		if (livesCount > 0)
		{
			playerTransform.position = respawnPoint;
			playerCollider.enabled = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Check if the collision was with an NPC
		if (collision.gameObject.tag == "Enemy")
		{
			// Move player out of screen, to death position
			playerTransform.position = deathPoint;
			Debug.Log("Hit a duck");

            // Lower Lives
            livesCount -= 1;

            // Disable collider to not collide again
            playerCollider.enabled = false;

            // Delay respawn
            Invoke("PlayerDied", respawnDelay);
		}

	}
}
