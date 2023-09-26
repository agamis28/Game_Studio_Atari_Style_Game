using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenPointer : MonoBehaviour
{
	public float yInput;
	public float buttonGap = 125f;
	public float pointerY;
	public RectTransform pointer;
	public bool justPressed;
	public bool pressedEnter;

	public Text button1;
	public Text button2;
	public Text button3;
	public int buttonDefault = 50;
	public int buttonIncreased = 60;
	public Color colorSelected = Color.green;
    public Color colorDefault = Color.black;


    // Start is called before the first frame update
    void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		pointer = gameObject.GetComponent<RectTransform>();
		pointerY = gameObject.GetComponent<RectTransform>().anchoredPosition.y;

		yInput = Input.GetAxisRaw("Vertical");
		justPressed = Input.anyKeyDown;

		// If pressing up and pointer is not at the top, move pointer
		if(yInput == 1 && pointerY < 0f && justPressed)
		{
			pointer.Translate(0, 125f, 0);
		}

		// If pressing down and pointer is not at the bottom, move pointer
		if (yInput == -1 && pointerY > -250f && justPressed) 
		{
			pointer.Translate(0, -125f, 0);
		}

		ExpandButton();

		CheckEnter();
	}

	public void ExpandButton()
	{
		if(pointerY == 0)
		{
            button1.fontSize = buttonIncreased;
			button1.color = colorSelected;
            button2.fontSize = buttonDefault;
			button2.color = colorDefault;
            button3.fontSize = buttonDefault;
            button3.color = colorDefault;
        }

        if (pointerY == -125)
		{
            button1.fontSize = buttonDefault;
            button1.color = colorDefault;
            button2.fontSize = buttonIncreased;
            button2.color = colorSelected;
            button3.fontSize = buttonDefault;
            button3.color = colorDefault;
        }

        if (pointerY == -250)
		{
            button1.fontSize = buttonDefault;
            button1.color = colorDefault;
            button2.fontSize = buttonDefault;
            button2.color = colorDefault;
            button3.fontSize = buttonIncreased;
            button3.color = colorSelected;
        }


    }

	public void CheckEnter()
	{
		if (Input.GetButtonDown("Jump"))
		{
			pressedEnter = true;
		}
	}
}
