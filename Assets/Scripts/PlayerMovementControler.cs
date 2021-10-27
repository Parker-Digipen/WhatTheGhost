using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour
{
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private Vector2 direction = Vector3.zero;
    public float speed;
    Rigidbody2D myRB;
    // Start is called before the first frame update
    private KeyCode[] hate = { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };
    private string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private string typed = "";
    private bool typing = false;

    void Start()
    {
        //gets rigid body attached to sprite
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player Movement
        if (!typing)
        {
            direction.x = LastKey(left, right);
            direction.y = LastKey(down, up);
            direction.Normalize();
            myRB.velocity = direction * speed;
        }

        //Text Input
        if(!typing && Input.GetKeyDown(KeyCode.CapsLock))
        {
            typing = true;
        } 
        else if(typing && Input.GetKeyDown(KeyCode.CapsLock))
        {
            typing = false;
        }

        if(typing)
            UserTyping();

    }

    private void UserTyping()
    {
        for (int i = 0; i <= hate.Length - 1; i++)
        {
            if (Input.GetKeyDown(hate[i]))
            {
                typed += alphabet[i];
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
        {
            typed = "";
        }
        GameManager.Word = typed;
    }
    private int LastKey(KeyCode negative, KeyCode positive)
    {
        int dir = 0;
        if (Input.GetKeyDown(negative))
        {
            dir = -1;
        }
        else if (Input.GetKey(negative) && !Input.GetKey(positive))
        {
            dir = -1;
        }
        else if (Input.GetKeyDown(positive))
        {
            dir = 1;
        }
        else if (Input.GetKey(positive) && !Input.GetKey(negative))
        {
            dir = 1;
        }
        else if (!Input.GetKey(negative) && !Input.GetKey(positive))
        {
            dir = 0;
        }

        return dir;
    }
}
