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
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = LastKey(left, right);
        direction.y = LastKey(down, up);
        direction.Normalize();
        myRB.velocity = direction*speed;
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
