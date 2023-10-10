using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooCollison : MonoBehaviour
{
	public PlayerShooting playerShooting;
	public SpriteRenderer spriteRenderer;
	public Sprite bulletSplat;

    [Header("** Audio **")]
    [SerializeField] private AudioSource src;
    [SerializeField] private AudioClip bulletSplatSound;
    [SerializeField] private GameObject NPCSounds;
	private GameObject deathSound;

    private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Destroy enemies that touch it.
		if(collision.gameObject.layer == LayerMask.NameToLayer("Ducks"))
		{
			// Instantiate a NPC sound
			deathSound = Instantiate(NPCSounds, transform.position, Quaternion.identity);
            // Play NPC death sound
            deathSound.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            playerShooting.pointCount += 1;
		}

		// Change bullet art
		spriteRenderer.sprite = bulletSplat;

		// Play splat sound effect
		src.clip = bulletSplatSound;
		src.Play();

		GetComponent<CapsuleCollider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		// Self Destruct
		Destroy(gameObject, 0.2f);
	}
}
