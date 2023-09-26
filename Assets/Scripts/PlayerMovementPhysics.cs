using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPhysics : MonoBehaviour
{
	[Header("** References **")]
	private Rigidbody2D rigid;

	[Header("** Inputs **")]
	public Vector2 inputs;
	public Vector2 lastDirection;

	[Header("** Stats **")]
	public float moveForce = 5f;
	public float moveTorque = 2f;

	// Start is called before the first frame update
	void Start()
	{
		// Get this players rigidbody
		rigid = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// Grab keyboard inputs and store them in Vector 2 inputs
		inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rigid.AddRelativeForce(new Vector2(0, inputs.y) * moveForce);
        rigid.AddTorque(-inputs.x * moveTorque);
        // Add a force to player
        //rigid.velocity = inputs * moveForce;

        //RotateInDirection();
    }

	private void RotateInDirection()
	{
		if(inputs != Vector2.zero)
		{
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, inputs);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, moveTorque * Time.deltaTime);

            rigid.MoveRotation(rotation);
        }
	}
}
