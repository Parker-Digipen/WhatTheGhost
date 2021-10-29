using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float FireSpeed;
    public GameObject Fire;
    public Transform target;
    private Rigidbody2D rigidBody;
    public float angleChangingSpeed;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rigidBody.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rigidBody.angularVelocity = -angleChangingSpeed * rotateAmount;
        rigidBody.velocity = transform.up * movementSpeed;
    }

    public void Shootie(Vector3 offset)
    {
        //create the object with a position offset and affected by the rotation of the spawner
        offset = new Vector3 (1, 1, 1);
        Vector3 spawnPos = transform.position + transform.rotation * offset;
        GameObject clone = Instantiate(Fire, spawnPos, transform.rotation);
        //set the speed of the clone
        Rigidbody2D cloneRb = clone.GetComponent<Rigidbody2D>();
        cloneRb.velocity = transform.up * FireSpeed;
    }
}
