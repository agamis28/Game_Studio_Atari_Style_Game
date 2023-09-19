using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
