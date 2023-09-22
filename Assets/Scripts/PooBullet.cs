using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PooBullet : MonoBehaviour
{
	[Header("** References **")]
	public Rigidbody2D rigid;

	[Header("** Stats **")]
	public Vector2 playerDirection;
	public float impulseForce = 5f;

	// Start is called before the first frame update
	void Start()
	{
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{

    }

    // Update is called once per frame
    void FixedUpdate()
	{
		rigid.AddForce(transform.up * impulseForce, ForceMode2D.Impulse);
	}
}
