using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerArt : MonoBehaviour
{
    [Header("** References **")]
    public SpriteRenderer renderer;

    [Header("** Stats **")]
    public Vector2 inputs;

    [Header("** Sprites **")]
    public Sprite up;
    public Sprite upRight;
    public Sprite upLeft;
    public Sprite right;
    public Sprite left;
    public Sprite down;
    public Sprite downRight;
    public Sprite downLeft;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Input"));

        if(inputs.x == 1 && inputs.y == 1)
        {
            //up right
        }
    }
}
