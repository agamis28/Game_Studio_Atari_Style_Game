using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("** Pause **")]
    public bool gameIsPaused;
    public int pausedSpeed = 0;
    public GameObject pausedScreen;

    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            gameIsPaused = true;
            pausedScreen.SetActive(true);
        }
        if (!gameIsPaused)
        {
            pausedScreen.SetActive(false);
        }
    }
}
