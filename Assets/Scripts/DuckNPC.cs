using UnityEngine;

public class DuckNPC : MonoBehaviour
{
    [Header("** References **")]
    public GameObject player;
    public Rigidbody2D rigid;

    [Header("** Positions **")]
    private Vector2 playerPosition;
    private Vector2 thisPosition;
    private Vector2 originPoint;
    private Vector2 targetPoint;

    [Header("** Vectors **")]
    private Vector2 vectorBetween;
    private Vector2 normalizedVectorBetween;

    [Header("** Stats **")]
    public float speed = 75f;
    public float chaseSpeed = 90f;
    public float wanderRadius = 3f;
    private float detectRadius = 0.05f;
    public float chaseRadius = 4f;

    [Header("** Wandering **")]
    public bool isWandering = true;
    private Vector2 wanderVector;
    public bool targetReached = true;

    // Start is called before the first frame update
    void Start()
    {
        // Find a origin point within the screen range
        originPoint = new Vector2(Random.Range(-6f, 6f), Random.Range(-4.5f,4.5f));
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Update players position and this NPC's position
        playerPosition = player.transform.position;
        thisPosition = transform.position;

        // Check if wandering is true then wander
        if (isWandering)
        {
            Wandering();
        }

        // Chase Player
        Chasing();

        
    }

    public void Chasing()
    {
        // if the distance betweem the player and NPC is less than chaseRadius start chasing
        if (Mathf.Abs(playerPosition.x - thisPosition.x) < chaseRadius && Mathf.Abs(playerPosition.y - thisPosition.y) < chaseRadius)
        {
            // Turn off wandering
            isWandering = false;

            // Grabbing players current position
            playerPosition = (Vector2)player.transform.position;

            // NPCs position to vector2
            thisPosition = (Vector2)transform.position;

            // Finding the direction and magnitude between NPC and target player
            vectorBetween = playerPosition - thisPosition;

            // Normalize vector and multiply by a standardized magnitude
            normalizedVectorBetween = vectorBetween.normalized;

            // Add a force in the direction between DuckNPC and Player
            rigid.AddForce(normalizedVectorBetween * Time.deltaTime * speed);

            // -- NON PHYSICS -- Change position of NPC to players position
            //transform.Translate(normilizedVectorBetween * Time.deltaTime * speed);
        }
        else
        {
            // Turn wandering back on when out of range
            isWandering = true;
        }

        Debug.DrawRay(transform.position, normalizedVectorBetween);
    }

    public void Wandering()
    {
        // Checking if target is reached and caching it in bool
        if (thisPosition.x <= targetPoint.x + detectRadius &&
            thisPosition.x >= targetPoint.x - detectRadius &&
            thisPosition.y <= targetPoint.y + detectRadius &&
            thisPosition.y >= targetPoint.y - detectRadius)
        // --TO DO -- Simplify ^^
        {
            targetReached = true;
        }

        // When target is reached making a new target
        if (targetReached)
        {
            targetPoint = originPoint + Random.insideUnitCircle * wanderRadius;
            targetReached = false;
        }

        // Drawing the distance between the orgin point
        Debug.DrawLine(originPoint, targetPoint, Color.red);

        // Get the vector between the NPC and its random target point
        wanderVector = targetPoint - (Vector2)transform.position;

        // Normalizing the wanderVector, making the movement per second, and setting speed
        rigid.AddForce(wanderVector.normalized * Time.deltaTime * speed);
    }
}
