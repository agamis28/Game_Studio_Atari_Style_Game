using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerArt : MonoBehaviour
{
	[Header("** References **")]
	private SpriteRenderer spriteRenderer;

	[Header("** Input **")]
	private Vector2 inputs;
	private bool isShooting;

	[Header("** Sprites **")]
	[SerializeField] private Sprite idle;
	[SerializeField] private Sprite[] swimming;
	[SerializeField] private Sprite[] shooting;

	[Header("** Swimming Animation Settings **")]
	private int swimCurrentFrame = 0;
	private float swimFrameTime = .5f;
	private float swimAnimationTimer = 0;

	[Header("** Shooting Animation Settings **")]
	private int shootCurrentFrame = 0;
	private float shootFrameTime = .1f;
	private float shootAnimationTimer = 0;

	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		// Setting timers
		swimAnimationTimer += Time.deltaTime;
		shootAnimationTimer += Time.deltaTime;

		// Grabbing inputs
		inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		isShooting = Input.GetButton("Jump");

		/*

		// When moving forwards change sprite
		if (inputs.y > 0.1f || inputs.y < -0.1f)
		{
			spriteRenderer.sprite = swimming[swimCurrentFrame];
		}

		// Update the current frame after frameTime
		if (swimAnimationTimer > swimFrameTime)
		{
			// Increment current frame
			swimCurrentFrame++;

			// Reset timer
			swimAnimationTimer = 0;
		}

		// Loop back to 0 if reached idle length
		if (swimCurrentFrame >= swimming.Length)
		{
			swimCurrentFrame = 0;
		}

		*/

		// If shooting play shooting animation
		if (isShooting)
		{
			spriteRenderer.sprite = shooting[shootCurrentFrame];

			// Update the current frame after frameTime
			if (shootAnimationTimer > shootFrameTime)
			{
				// Increment current frame
				shootCurrentFrame++;

				// Reset timer
				shootAnimationTimer = 0;
			}

			// Loop back to 0 if reached idle length
			if (shootCurrentFrame >= shooting.Length)
			{
				shootCurrentFrame = 0;
			}
		}
		else if (inputs.y > 0.1f || inputs.y < -0.1f)
		{
		
			spriteRenderer.sprite = swimming[swimCurrentFrame];
		
			// Update the current frame after frameTime
			if (swimAnimationTimer > swimFrameTime)
			{
				// Increment current frame
				swimCurrentFrame++;

				// Reset timer
				swimAnimationTimer = 0;
			}

			// Loop back to 0 if reached idle length
			if (swimCurrentFrame >= swimming.Length)
			{
				swimCurrentFrame = 0;
			}
		}
		else
		{
			spriteRenderer.sprite = idle;
		}

	}



}
