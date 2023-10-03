using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("** Inputs **")]
    public float inputx;
    public float inputy;

    public Vector2 inputs;

    [Header("Stats")]
    public float speed = 2.5f;

    // Update is called once per frame
    void Update()
    {
        // Get input values from keyboard
        inputx = Input.GetAxis("Horizontal");
        inputy = Input.GetAxis("Vertical");

        // Input vector
        inputs = new Vector2(inputx, inputy);

        // Standardizing magnitude
        float mag = Mathf.Min(inputs.magnitude, 1f);

        // Make player move with normalized input vector, move per second, setting a speed, standardizing magnitude
        transform.Translate(inputs.normalized * Time.deltaTime * speed * mag);

    }
}
