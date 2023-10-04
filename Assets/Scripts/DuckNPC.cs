using UnityEngine;

public class DuckNPC : MonoBehaviour
{
    [Header("** References **")]
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rigid;

    [Header("** Screen Dimentions **")]
    private float screenWidth = 12;
    private float screenHeight = 9;

    [Header("** Position **")]
    private Vector2 thisPosition;

    [Header("** Wandering **")]
    private float speed = 80f;
    private float wanderRadius = 3f;
    private float detectRadius = 0.05f; // Radius that it can detect the target point
    private bool isWandering = true;
    private bool targetReached = true;
    private Vector2 originPoint;
    private Vector2 targetPoint;
    private Vector2 wanderVector;

    [Header("** Chasing **")]
    private float chaseSpeed = 100f;
    private float chaseRadius = 4f;
    private Vector2 playerPosition;
    private Vector2 vectorBetween;
    private Vector2 normalizedVectorBetween;

    [Header("** Debug Lines **")]
    [SerializeField]
    private bool showDebugLines = false;

    // Start is called before the first frame update
    void Start()
    {
        // Find a random origin point within the screen range
        originPoint = new Vector2(Random.Range(-screenWidth/2, screenWidth / 2), Random.Range(-screenHeight/2, screenHeight/2));
        // Get reference to rigidbody
        rigid = GetComponent<Rigidbody2D>();
        // Find player object
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

        // Show debug lines if its true
        VisualiseDebugLines();
    }

    // Chase the player when it is in its 'chaseRadius'
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
            rigid.AddForce(normalizedVectorBetween * Time.deltaTime * chaseSpeed);

            // -- NON PHYSICS -- Change position of NPC to players position
            //transform.Translate(normilizedVectorBetween * Time.deltaTime * speed);
        }
        else
        {
            // Turn wandering back on when out of range
            isWandering = true;
        }
    }

    // Make NPC wander around the 'wanderRadius'
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

        // Get the vector between the NPC and its random target point
        wanderVector = targetPoint - (Vector2)transform.position;

        // Normalizing the wanderVector, making the movement per second, and setting speed
        rigid.AddForce(wanderVector.normalized * Time.deltaTime * speed);
    }

    // Shows any movement lines with debugs
    public void VisualiseDebugLines()
    {
        // If option 'showDebugLines' is on draw all lines
        if (showDebugLines)
        {
            // ** Chasing **

            Debug.DrawRay(transform.position, normalizedVectorBetween, Color.red);

            // ** Wandering **

            // Drawing the distance between the orgin point
            Debug.DrawLine(originPoint, targetPoint, Color.blue);
            // Drawing the path while wandering
            Debug.DrawLine(thisPosition, targetPoint, Color.green);
        }
    }
}
