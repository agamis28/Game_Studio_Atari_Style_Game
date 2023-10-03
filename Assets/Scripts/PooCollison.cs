using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooCollison : MonoBehaviour
{
	public PlayerShooting playerShooting;
	public SpriteRenderer spriteRenderer;
	public Sprite bulletSplat;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Destroy enemies that touch it.
		if(collision.gameObject.layer == LayerMask.NameToLayer("Ducks"))
		{
			Destroy(collision.gameObject);
			playerShooting.pointCount += 1;
		}

		spriteRenderer.sprite = bulletSplat;
		GetComponent<CapsuleCollider2D>().enabled = false;
		GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		// Self Destruct
		Destroy(gameObject, 0.2f);
	}
}
