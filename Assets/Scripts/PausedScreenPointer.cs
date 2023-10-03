using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PausedScreenPointer : MonoBehaviour
{
    [Header("** Pointer **")]
    public float yInput;
    private float pointerY;
    public RectTransform pointer;

    [Header("** Buttons **")]
    public Text button1;
    public Text button2;
    public Text button3;
    private int buttonDefault = 50;
    private int buttonIncreased = 60;
    private Color colorSelected = Color.grey;
    private Color colorDefault = Color.black;

    [Header("** Buttons States **")]
    private bool justPressed;

    [Header("** Scene Manager **")]
    public SceneManagers sceneManager;

    [Header("** Game Controller **")]
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindAnyObjectByType<SceneManagers>();
        gameController = GameObject.FindAnyObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        pointer = gameObject.GetComponent<RectTransform>();
        pointerY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

        yInput = Input.GetAxisRaw("Vertical");
        justPressed = Input.anyKeyDown;

        // If pressing up and pointer is not at the top, move pointer
        if (yInput == 1 && pointerY < 0f && justPressed)
        {
            pointer.Translate(0, 125f, 0);
        }

        // If pressing down and pointer is not at the bottom, move pointer
        if (yInput == -1 && pointerY > -250f && justPressed)
        {
            pointer.Translate(0, -125f, 0);
        }

        ExpandButton();

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Submit"))
        {
            PressedEnter();
        }
    }

    public void ExpandButton()
    {
        // If first button
        if (pointerY == 0)
        {
            // Expand and resize buttons
            button1.fontSize = buttonIncreased;
            button1.color = colorSelected;
            button2.fontSize = buttonDefault;
            button2.color = colorDefault;
            button3.fontSize = buttonDefault;
            button3.color = colorDefault;
        }

        // If second button
        if (pointerY == -125)
        {
            // Expand and resize buttons
            button1.fontSize = buttonDefault;
            button1.color = colorDefault;
            button2.fontSize = buttonIncreased;
            button2.color = colorSelected;
            button3.fontSize = buttonDefault;
            button3.color = colorDefault;
        }

        // If third button
        if (pointerY == -250)
        {
            // Expand and resize buttons
            button1.fontSize = buttonDefault;
            button1.color = colorDefault;
            button2.fontSize = buttonDefault;
            button2.color = colorDefault;
            button3.fontSize = buttonIncreased;
            button3.color = colorSelected;
        }
    }

    public void PressedEnter()
    {
        // If first button
        if (pointerY == 0)
        {
            // Resume Game
            gameController.gameIsPaused = false;
        }

        // If second button
        if (pointerY == -125)
        {
            // Enter Tutorial Scene
            sceneManager.LoadTutorial();
        }

        // If third button
        if (pointerY == -250)
        {
            // Quit Game
            sceneManager.QuitGame();
        }
    }
}
