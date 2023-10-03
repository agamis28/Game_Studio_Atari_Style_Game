using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class NPCDemo : MonoBehaviour
{
    public GameObject player;
    private Vector2 playerPosition;
    private Vector2 thisPosition;

    private Vector2 vectorBetween;
    private Vector2 normilizedVectorBetween;

    public float speed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Wandering();

        // Raycast, Detect Player
    }

    public void Wandering()
    {
        // Grabbing players current position
        playerPosition = (Vector2)player.transform.position;

        // NPCs position to vector2
        thisPosition = (Vector2)transform.position;

        // Finding the direction and magnitude between NPC and target player
        vectorBetween = playerPosition - thisPosition;

        // Normalize vector and multiply by a standardized magnitude
        normilizedVectorBetween = vectorBetween.normalized;

        // Change position of NPC to players position
        transform.Translate(normilizedVectorBetween * Time.deltaTime * speed);

        Debug.DrawRay(transform.position, normilizedVectorBetween);
    }
}
