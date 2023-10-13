using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	[Header("** Positions **")]
	private Transform playerTransform;
	private Vector3 respawnPoint;
	private Vector3 deathPoint = new Vector3(-15, -15, 0);

	[Header ("** References **")]
	//public GameObject extraLifePrefab;
	private PlayerMovementPhysics playerMovement;
	[SerializeField] private SpriteRenderer playerRenderer;

	[Header ("** Stats **")]
	[SerializeField] private int livesCount = 3;
	private float respawnDelay = 2f;
	//private int extraLives = 0;
	//private int maxLives = 5;

	[Header("** Collision **")]
    [SerializeField] private LayerMask nothingLayer;
    [SerializeField] private LayerMask ducksLayer;
    private CapsuleCollider2D playerCollider;

    [Header("** Player Invinsibility **")]
	private float blinkSpeed = 1f;
	public bool playerIsInvinsible = false;
	private float invinsibilityTimer;
	private float invinsibleTime = 5f;

	[Header("** Player Lives **")]
	[SerializeField] private GameObject playerLife1;
    [SerializeField] private GameObject playerLife2;
    [SerializeField] private GameObject playerLife3;
    [SerializeField] private GameObject deathScreen;

    [Header("** Audio **")]
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip gooseDyingSound;

    [Header("** Scene Manager **")]
    [SerializeField] private SceneManagers sceneManagers;

	// Start is called before the first frame update
	void Start()
	{
		playerTransform = transform;
		//playerRenderer = GetComponent<SpriteRenderer>();
		playerMovement = GetComponent<PlayerMovementPhysics>();
		playerCollider = GetComponent<CapsuleCollider2D>();
        sceneManagers = GameObject.FindAnyObjectByType<SceneManagers>();

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
				playerMovement.enabled = false;
				Invoke("DeathScreen", .5f);
                break;
		}

		// Will make player blink while invisible and turn off invinsibility (turn on collider) when past time
		PlayerInvinsibleBlink();

	}

	void PlayerRespawn()
	{
		Debug.Log("respawn function");
        // Lower Lives
        livesCount -= 1;
        // Respawn in respawn position, if player still has lives
        // ** PLAYER IS RESPAWNED **
        if (livesCount > 0)
		{
			Debug.Log("invinsiblity on and change position back");
            // Reset the timer for the invinsiblity
            invinsibilityTimer = 0;
            // Turn on the invinsibility period
            playerIsInvinsible = true;
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

	void DeathScreen()
	{
        sceneManagers.LoadDeathScreen();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Check if the collision was with an NPC
		// ** PLAYER IS DEAD **
		if (collision.gameObject.tag == "Enemy")
		{
            // Disable collider to not collide again
            playerCollider.excludeLayers = ducksLayer;

            // Move player out of screen, to death position
            playerTransform.position = deathPoint;
			Debug.Log("Hit a duck");

			// Play death sound
			src.clip = gooseDyingSound;
			src.Play();

			// Disable playermovement
			playerMovement.enabled = false;

			// Delay respawn
			Invoke("PlayerRespawn", respawnDelay);
			Debug.Log("End of collison function");
		}

	}
}
