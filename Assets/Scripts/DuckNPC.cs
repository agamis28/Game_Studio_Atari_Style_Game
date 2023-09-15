using UnityEngine;

public class DuckNPC : MonoBehaviour
{
    [Header("** References **")]
    public GameObject player;
    public Rigidbody2D rigid;

    [Header("** Positions **")]
    private Vector2 playerPosition;
    private Vector2 thisPosition;

    [Header("** Vectors **")]
    private Vector2 vectorBetween;
    private Vector2 normilizedVectorBetween;

    public float speed = .5f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        // Chase Player
        Chasing();
    }

    public void Chasing()
    {
        // Grabbing players current position
        playerPosition = (Vector2)player.transform.position;

        // NPCs position to vector2
        thisPosition = (Vector2)transform.position;

        // Finding the direction and magnitude between NPC and target player
        vectorBetween = playerPosition - thisPosition;

        // Normalize vector and multiply by a standardized magnitude
        normilizedVectorBetween = vectorBetween.normalized;

        // Add a force in the direction between DuckNPC and Player
        rigid.AddForce(normilizedVectorBetween * speed);

        // Change position of NPC to players position
        //transform.Translate(normilizedVectorBetween * Time.deltaTime * speed);

        Debug.DrawRay(transform.position, normilizedVectorBetween);
    }
}
