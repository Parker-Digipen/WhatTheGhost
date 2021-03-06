using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleSense : MonoBehaviour
{
    public GameObject MC;
    public GameObject secondMC;
    public Rigidbody2D Rb;
    public float attackDelay;
    public float timer;
    public GameObject Test;
    public bool trashsystem = true;
    public GameObject RedOverlay;
    public float timer2 = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Rb = MC.GetComponent<Rigidbody2D>();
        MC = GameObject.FindGameObjectWithTag("EnemyTwo");
        secondMC = GameObject.FindGameObjectWithTag("Kirito");
        RedOverlay = GameObject.FindGameObjectWithTag("Loser");
        MC.GetComponent<Animator>().enabled = false;
        timer = attackDelay;
    }
    

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timer <= 0)
        {
            //if the object collided with is player
            if (collision.gameObject.tag == "Kirito")
            {
                //slow way down
                Rb.angularDrag += 10000;
                Rb.drag += 10000;
                
                //activates animation and stops movment
                //MC.GetComponent<EnemyMove>().enabled = false;
                //MC.GetComponent<Animator>().enabled = true;
                
                //deal damage
                //changed from secondMC to collision to fix no damage issue
                collision.GetComponent<Health>().CurrentHealth -= 5;
            }
            //?
            if (timer2 <= 0)
            {
                //?
                RedOverlay.GetComponent<SpriteRenderer>().enabled = false;
                timer2 = 0.5f;
            }
            //if player killed
            if (secondMC.GetComponent<Health>().CurrentHealth <= 0)
            {
                //switch to end scene
                SceneManager.LoadScene("Death Screen");
            }
            //resets attack timer
            timer = attackDelay;
        }
    }
    public void loser()
    {
        while(timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }
    }
}
