using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSense : MonoBehaviour
{
    public GameObject MC;
    public Rigidbody2D Rb;
    public float timer;
    public GameObject Test;
    // Start is called before the first frame update
    void Start()
    {
        Rb = MC.GetComponent<Rigidbody2D>();
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
            Destroy(Test);
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
        }
    }
}
