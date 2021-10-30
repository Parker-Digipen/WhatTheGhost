using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControler : MonoBehaviour
{
    [Tooltip("Camera will follow this object")]
    public GameObject Target;
    [Tooltip("Set between 0 and 1 for best results")]
    public float LerpVal = 0.05f;
    float ShakeTime = 3;
    float ShakeAmount = 3;
    private KeyCode left = KeyCode.A;
    private KeyCode right = KeyCode.D;
    private KeyCode up = KeyCode.W;
    private KeyCode down = KeyCode.S;
    private Vector2 direction = Vector3.zero;
    public float speed;
    public ParticleSystem linger;
    Rigidbody2D myRB;
    MainCamera shook;
    public GameObject pew;
    public GameObject poof;
    private KeyCode[] hate = { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z };
    private char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    List<int> usedValues = new List<int>();
    public bool typing = false;


    void Start()
    {
        //gets rigid body attached to sprite
        myRB = GetComponent<Rigidbody2D>();
        shook = FindObjectOfType<MainCamera>();
        linger.Stop();
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

        //stops all player movement when typing
        if (typing) 
        {
            myRB.velocity = Vector2.zero;
            UserTyping();
        }

        //Text Input
        if (!typing && Input.GetKeyDown(KeyCode.LeftShift))
        {
            typing = true;
            linger.Play();
        }
        else if (typing && Input.GetKeyDown(KeyCode.LeftShift))
        {
            typing = false;
            linger.Stop();
        }
        //switch to typing mode
    }

    private void UserTyping()
    {
        for (int i = 0; i <= hate.Length - 1; i++)
        {
            //did they press a key
            if (Input.GetKeyDown(hate[i]))
            {
                //
                if (GameManager.Typed.Length < GameManager.Word.Length) {
                    //checks if character is in that spot of the word
                    if (GameManager.Word[GameManager.Typed.Length] == alphabet[i]) {
                        GameManager.Typed += alphabet[i];
                    }
                    //if not, shake and remove character from end
                    else
                    {
                        shook.TriggerShake(0.1f, 0.25f);
                        //trims the end of typed
                        if (GameManager.Typed.Length > 0) {
                            GameManager.Typed = GameManager.Typed.TrimEnd(GameManager.Typed[GameManager.Typed.Length - 1]);
                        }
                    }
                }
            }
            //space/return pressed
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                //is the word finished (correctly)
                if (GameManager.Typed.Length == GameManager.Word.Length)
                {
                    //clears the typed string
                    GameManager.Typed = "";
                    //sets next word
                    GameManager.Word = GameManager.possible[UniqueRandomInt(0, GameManager.possible.Length)];
                    //checks if enemies left
                    //if yes, shoot
                    if(GameManager.EnemyCount > 0) 
                    {
                        GameObject clone = Instantiate(pew, transform.position, transform.rotation);
                    }
                    //if no, pulse
                    else 
                    {
                        GameObject pulse = Instantiate(poof, transform.position, transform.rotation);
                    }

                }
                //if not then shake screen (but don't remove characters)
                else
                {
                    shook.TriggerShake(0.1f, 0.1f);
                }
            }
        }
        //clears text if backspace, or escape is pressed
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Typed = "";
        }

    }
    private int LastKey(KeyCode negative, KeyCode positive)
    {
        //gets last key pressed for player movement
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
    //gets non-repeating random value
    public int UniqueRandomInt(int min, int max)
    {
        //clears used values once we've used all of the values in the range
        if (usedValues.Count >= max) {
            usedValues.Clear();
        }
        int val;
        //repeats until no repeat values
        do
        {
            val = Random.Range(min, max);
        } while(usedValues.Contains(val));
        //adds value to used values list
        usedValues.Add(val);
        return val;
    }

    public void loser()
    {
        if (ShakeTime > 0)
        {
            ShakeTime -= Time.deltaTime;
            Vector3 randDir = Random.insideUnitCircle * ShakeAmount;
            transform.position += randDir;

        }
        else
        {
            ShakeAmount = 0;
        }
    }
    public void TriggerShake(float time, float amount)
    {
        if (ShakeTime < time)
        {
            ShakeTime = time;
        }
        if (ShakeAmount < amount)
        {
            ShakeAmount = amount;
        }
    }
}
