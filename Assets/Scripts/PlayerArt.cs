using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PlayerArt : MonoBehaviour
{
    [Header("** References **")]
    public SpriteRenderer rend;

    [Header("** Stats **")]
    public Vector2 inputs;
    public bool flipSprite = false;

    [Header("** Sprites **")]
    public Sprite up;
    public Sprite upDiagonal;
    public Sprite horizontal;
    public Sprite right;
    public Sprite down;
    public Sprite downDiagonal;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        CheckChangeSprite();
    }

    public void CheckChangeSprite()
    {
        if (inputs.x == 0 && inputs.y == 1)
        {
            // Up
            rend.sprite = up;
            rend.flipX = false;
        }

        if (inputs.x == 1 && inputs.y == 1)
        {
            // Up right
            rend.sprite = upDiagonal;
            rend.flipX = false;
        }

        if (inputs.x == -1 && inputs.y == 1)
        {
            // Up left
            rend.sprite = upDiagonal;
            rend.flipX = true;
        }

        if (inputs.x == 0 && inputs.y == -1)
        {
            // Down
            rend.sprite = down;
            rend.flipX = false;
        }

        if (inputs.x == 1 && inputs.y == -1)
        {
            // Down right
            rend.sprite = downDiagonal;
            rend.flipX = false;
        }

        if (inputs.x == -1 && inputs.y == -1)
        {
            // Down left
            rend.sprite = downDiagonal;
            rend.flipX = true;
        }

        if (inputs.x == 1 && inputs.y == 0)
        {
            // Right
            rend.sprite = right;
            rend.flipX = false;
        }

        if (inputs.x == -1 && inputs.y == 0)
        {
            // Left
            rend.sprite = right;
            rend.flipX = true;
        }
    }

}
