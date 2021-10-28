//------------------------------------------------------------------------------
//
// File Name:	CharacterAnimation.cs
// Author(s):	Gavin Cooper (gavin.cooper@digipen.edu)
// Project:	    Fun
// Course:	    WANIC VGP2
//
// Copyright � 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [Tooltip("The radi")]
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
        thingDo(leftKey, rightKey);
        thingDo(downKey, upKey);
        if(myPlayer.typing)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, startingY + Mathf.Sin(Time.time * speed) * size * 0.25f);
        }

    }
    private int thingDo(KeyCode negative, KeyCode positive)
    {
        //flips character sprite
        if (!mySR.flipX && Input.GetKeyDown(positive))
        {
            mySR.flipX = true;
        }
        else if (mySR.flipX && Input.GetKeyDown(negative))
        {
            mySR.flipX = false;
        }

        // Get dirrection
        if (Input.GetKeyDown(negative) || Input.GetKeyDown(upKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKey(negative) && !Input.GetKey(positive))
        {
            dirrection = -1;
        }
        else if (Input.GetKeyDown(positive) || Input.GetKeyDown(downKey))
        {
            dirrection = 1;
        }
        else if (Input.GetKey(positive) && !Input.GetKey(negative))
        {
            dirrection = 1;
        }
        else if (!Input.GetKey(negative) && !Input.GetKey(positive))
        {
            dirrection = 0;
        }

        if (dirrection == 1)
        {
            transform.localScale = new Vector2(startingXScale, transform.localScale.y);
        }
        else if (dirrection == -1)
        {
            transform.localScale = new Vector2(startingXScale, transform.localScale.y);
        }

        // Bob
        if (dirrection != 0)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, startingY + Mathf.Sin(Time.time * speed) * size);
        }
        else if (Input.GetKeyDown(upKey) || Input.GetKeyDown(downKey))
        {
            transform.localPosition = new Vector2(transform.localPosition.x, startingY + Mathf.Sin(Time.time * speed) * size);
        }
        return dirrection;
    }
}
