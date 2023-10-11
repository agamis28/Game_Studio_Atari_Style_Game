using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("** References **")]
    [SerializeField] private SceneManagers sceneManagers;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject howTo;
    [SerializeField] private GameObject objective;

    [Header("** Selectable Buttons **")]
    [SerializeField] private GameObject objectiveBtn;
    [SerializeField] private GameObject howToBtn;

    // Update is called once per frame
    void Update()
    {
        // If ESC is pressed go to corresponding page
        if (Input.GetButtonDown("Cancel"))
        {
            // Go back to main menu
            if (tutorial.activeInHierarchy == true)
            {
                sceneManagers.LoadMainMenu();
            }
            // Go back to tutorial
            if(howTo.activeInHierarchy == true || objective.activeInHierarchy == true)
            {
                tutorial.SetActive(true);
                howTo.SetActive(false);
                objective.SetActive(false);
            }
        }
    }

    public void SelectHowToBtn()
    {
        howTo.SetActive(true);
        tutorial.SetActive(false);
    }

    public void SelectObjectiveBtn()
    {
        objective.SetActive(true);
        tutorial.SetActive(false);
    }
}
