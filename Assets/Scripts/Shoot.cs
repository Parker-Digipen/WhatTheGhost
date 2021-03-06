using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int Amount = 4;
    public bool DestroyOnCollide = true;
    public GameObject Fire;
    public Transform target;
    private Rigidbody2D rigidBody;
    public float angleChangingSpeed;
    public float movementSpeed;
    public string tom = "EnemyTwo";
    GameObject[] targets;
    float[] distances;
    float closest = 500000;
    int closestIndex;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //make sure there is health component
        Health h = collision.otherCollider.GetComponent<Health>();
        if (h != null)
        {
            h.ChangeHealth(-Amount);
        }
        if (DestroyOnCollide)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //make sure there is health component
        Health h = collision.otherCollider.GetComponent<Health>();
        if (h != null)
        {
            h.ChangeHealth(-Amount);
        }
        Death Grim = GetComponent<Death>();
        if (Grim != null)
        {
            Grim.OnDeath.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tom)) {
            //make sure there is health component
            Health h = collision.GetComponent<Health>();
            if (h != null)
            {
                h.ChangeHealth(-Amount);
            }
            if (DestroyOnCollide)
            {
                Death Grim = GetComponent<Death>();
                if (Grim != null)
                {
                    Grim.OnDeath.Invoke();
                }
                FindObjectOfType<MainCamera>().TriggerShake(0.1f, 0.1f);
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        targets = GameObject.FindGameObjectsWithTag(tom);
        distances = new float[targets.Length];
    }

    public void Shootie(Vector3 offset)
    {
        //create the object with a position offset and affected by the rotation of the spawner
        offset = new Vector3 (1, 1, 1);
        Vector3 spawnPos = transform.position + transform.rotation * offset;
        GameObject clone = Instantiate(Fire, spawnPos, transform.rotation);
        //set the speed of the clone
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        cloneRb.velocity = transform.up * 1;
    }
    private void Update()
    {
        for (int i = 0; i <= targets.Length - 1; i++)
        {
            try{
            distances[i] = Vector3.Distance(transform.position, targets[i].transform.position);
            } catch(MissingReferenceException) {
                //I just want the error message gone
            }
        }
        for (int i = 0; i <= targets.Length - 1; i++)
        {
            if (distances[i] < closest)
            {
                closest = distances[i];
                closestIndex = i;
            }
        }
        target = targets[closestIndex].transform;
        
        if(target != null) {
            Vector2 direction = (Vector2)target.position - rigidBody.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
            rigidBody.velocity = transform.up * movementSpeed;
        }
    }
}
