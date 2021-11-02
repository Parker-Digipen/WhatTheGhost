
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [Tooltip("The amount deviated from center")]
    public float size = 1;
    [Tooltip("The speed")]
    public float speed = 1;

    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;

    private float startingXScale;
    private float startingY;
    private float startingX;
    private int dirrection = 0;

    private SpriteRenderer mySR;
    private PlayerMovementControler myPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startingXScale = transform.localScale.x;
        startingY = transform.localPosition.y;
        startingX = transform.localPosition.x;
        mySR = GetComponent<SpriteRenderer>();
        myPlayer = FindObjectOfType<PlayerMovementControler>();
    }

    // Update is called once per frame
    void Update()
    {
        //get movement direction
        thingDo();

        // Bob
        if (dirrection != 0)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, startingY + Mathf.Sin(Time.time * speed) * size);
        }
        else if (Input.GetKey(upKey) || Input.GetKey(downKey))
        {
            transform.localPosition = new Vector2(transform.localPosition.x, startingY + Mathf.Sin(Time.time * speed) * size);
        }

        //typing animation
        if(myPlayer.typing)
        {
            transform.localPosition = new Vector2(startingX + Mathf.Cos(Time.time * speed) * size * 0.25f, startingY + Mathf.Sin(Time.time * speed) * size * 0.25f);
        }

        //reset after typing animation
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            transform.localPosition = new Vector2(startingX, startingY);
        }
    }
    private int thingDo()
    {
        //flips character sprite
        if (!mySR.flipX && Input.GetKeyDown(rightKey))
        {
            mySR.flipX = true;
        }
        else if (mySR.flipX && Input.GetKeyDown(leftKey))
        {
            mySR.flipX = false;
        }

        // Get dirrection
        if (Input.GetKeyDown(leftKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKeyDown(rightKey))
        {
            dirrection = 1;
        }
        else if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
        {
            dirrection = 1;
        }
        else if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            dirrection = 0;
        }
        return dirrection;
    }
}
