using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("** Pause **")]
    public bool gameIsPaused;
    public int pausedSpeed = 0;
    [SerializeField] private GameObject pausedScreen;

    private GameObject[] npcs;
    private GameObject player;
    [SerializeField] private GameObject spawnManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        npcs = GameObject.FindGameObjectsWithTag("Enemy");

        if (Input.GetButton("Cancel"))
        {
            gameIsPaused = true;
            pausedScreen.SetActive(true);
        }

        if (gameIsPaused)
        {
            player.GetComponent<PlayerMovementPhysics>().enabled = false;
            player.GetComponentInChildren<PlayerShooting>().enabled = false;
            spawnManager.SetActive(false);
            foreach (var npc in npcs)
            {
                npc.GetComponent<DuckNPC>().enabled = false;
            }
        }
        if (!gameIsPaused)
        {
            player.GetComponent<PlayerMovementPhysics>().enabled = true;
            player.GetComponentInChildren<PlayerShooting>().enabled = true;
            spawnManager.SetActive(true);
            foreach (var npc in npcs)
            {
                npc.GetComponent<DuckNPC>().enabled = true;
            }
            pausedScreen.SetActive(false);
        }
    }
}
