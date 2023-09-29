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
	private SpriteRenderer playerRenderer;
	public LayerMask nothingLayer;
	public LayerMask ducksLayer;

    [Header ("** Stats **")]
	public int livesCount = 3;
	public float respawnDelay = 5f;
	public int extraLives = 0;
	public int maxLives = 5;
	public float blinkSpeed = 1f;
	public bool playerIsInvinsible = false;
	public float invinsibilityTimer;
	public float invinsibleTime = 5f;

	[Header("** Player Lives **")]
	public GameObject playerLife1;
    public GameObject playerLife2;
    public GameObject playerLife3;
	public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
	{
		playerTransform = transform;
		playerRenderer = GetComponent<SpriteRenderer>();
		playerMovement = GetComponent<PlayerMovementPhysics>();
		playerCollider = GetComponent<CapsuleCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		invinsibilityTimer += Time.deltaTime;

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

		// Will make player blink while invisible and turn off invinsibility (turn on collider) when past time
		PlayerInvinsibleBlink();

	}

	void PlayerRespawn()
	{
        // Respawn in respawn position, if player still has lives
        // ** PLAYER IS RESPAWNED **
        if (livesCount > 0)
		{
            // Turn on the invinsibility period
            playerIsInvinsible = true;
            // Reset the timer for the invinsiblity
            invinsibilityTimer = 0;
			// Enable movement
            playerMovement.enabled = true;
            // Move player back to respawn point
            playerTransform.position = respawnPoint;
		}
	}

	void PlayerInvinsibleBlink()
	{
        // ** PLAYER IS INVINSIBLE **
        if (invinsibilityTimer > invinsibleTime && playerIsInvinsible)
		{
			playerIsInvinsible = false;
			playerCollider.excludeLayers = nothingLayer;
            playerRenderer.color = Color.white;
        }

        if (playerIsInvinsible)
		{
            playerRenderer.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time * blinkSpeed, 1));
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Check if the collision was with an NPC
		// ** PLAYER IS DEAD **
		if (collision.gameObject.tag == "Enemy")
		{
			// Move player out of screen, to death position
			playerTransform.position = deathPoint;
			Debug.Log("Hit a duck");

            // Disable collider to not collide again
            playerCollider.excludeLayers = ducksLayer;

			// Disable playermovement
			playerMovement.enabled = false;

            // Lower Lives
            livesCount -= 1;

            // Delay respawn
            Invoke("PlayerRespawn", respawnDelay);
		}

	}
}
