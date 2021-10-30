using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleSense : MonoBehaviour
{
    public GameObject MC;
    public GameObject secondMC;
    public Rigidbody2D Rb;
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
        timer += 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0 && Rb.angularDrag >= 9999)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            //dodamagehere
            secondMC.GetComponent<Health>().CurrentHealth -= 5;
            RedOverlay.GetComponent<SpriteRenderer>().enabled = true;
            secondMC.SendMessage("loser");
            if (timer2 <= 0)
            {
                RedOverlay.GetComponent<SpriteRenderer>().enabled = false;
                timer2 = 0.5f;
            }
            timer = 5;
            if (secondMC.GetComponent<Health>().CurrentHealth <= 0)
                    {
                SceneManager.LoadScene("Death Screen");
                    }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kirito")
        {
            Rb.angularDrag += 10000;
            Rb.drag += 10000;
            timer = 5;
            MC.GetComponent<EnemyMove>().enabled = false;
            MC.GetComponent<Animator>().enabled = true;
        }
    }
    public void loser()
    {
        while(timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }
    }
    //call this function to make a screen shake
}
