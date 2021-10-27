using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Tooltip("This array store the points that the AI should move through when pacing")]
    public Vector3[] Points = { Vector3.zero, new Vector3(5, 0, 0) };

    public float PaceSpeed = 10;
    public int CurrentPoint = 0;
    public float ChaseSpeed = 20;
    [Tooltip("This value is how close to a point it should allow to count as close enough")]
    public float CloseEnough = 0.1f;
    [Tooltip("How close should the target be before chasing it.")]
    public float ChaseDist = 5;
    [Tooltip("drag in the game object you want chased, will only pace without")]
    public GameObject Target;
    Vector3 position;
    Vector2 direction;

    Rigidbody2D myRb;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target != null)
        {
            //check distance to target to see whether you pace or chase
            direction = Target.transform.position - transform.position;
            position = Target.transform.position - transform.position;
            if (direction.sqrMagnitude <= ChaseDist * ChaseDist)
            {
                Chase(direction);
            }
            else
            {
                Pace();
            }
        }
        else
        {
            Pace();
        }
    }

    void Pace()
    {
        //check if near the CurrentPoint
        Vector3 direction = Points[CurrentPoint] - transform.position;

        if (direction.magnitude <= CloseEnough * CloseEnough)
        {
            //if near move to next
            ++CurrentPoint;
            if (CurrentPoint >= Points.Length)
            {
                Vector2 accelerationzero = direction.normalized * 0;
                myRb.velocity = accelerationzero;
                CurrentPoint = 0;
            }
            direction = Points[CurrentPoint] - transform.position;
        }

        //Set the speed towards the next point
        Vector2 acceleration = direction.normalized * PaceSpeed * Time.fixedDeltaTime;
        myRb.velocity += acceleration;
    }

    void Chase(Vector2 direction)
    {
        Vector2 acceleration = direction.normalized * ChaseSpeed * Time.fixedDeltaTime;
                myRb.velocity = acceleration;
    }
}
