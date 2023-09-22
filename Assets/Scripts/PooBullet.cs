using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PooBullet : MonoBehaviour
{
	[Header("** References **")]
	public Rigidbody2D rigid;
	public PlayerMovementPhysics playerMovement;

	[Header("** Stats **")]
	public Vector2 playerDirection;
	public float impulseForce = 5f;

	// Start is called before the first frame update
	void Start()
	{
        rigid = GetComponent<Rigidbody2D>();
		playerMovement = GameObject.FindFirstObjectByType<PlayerMovementPhysics>();
		// Grab player direction
		playerDirection = playerMovement.lastDirection;
    }

    // Update is called once per frame
    void Update()
	{


    }

    // Update is called once per frame
    void FixedUpdate()
	{
		rigid.AddRelativeForce(playerDirection * impulseForce, ForceMode2D.Impulse);
	}
}
