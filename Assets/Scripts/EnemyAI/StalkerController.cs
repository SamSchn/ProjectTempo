using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerController : EnemyBase
{
    Transform playerPos;
    public float speed;
    public float rotateSpeed;
    public float maxLifeTime;
    private float timer;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        timer = 0;

        //align the tracker to initially point towards the player
        direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }



    private void FixedUpdate()
    {
        if (timer < maxLifeTime)
        {
            Vector2 trackingDirection = Tracking();
            Vector2 avoidanceDirection = Avoidance();

            if (avoidanceDirection != Vector2.zero)
                direction = (Avoidance() + trackingDirection).normalized;
            else
                direction = trackingDirection;

            //move the Tracker
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;
        }
        if (timer > maxLifeTime + 10)
            Destroy(this.gameObject);
        timer += 1.0F * Time.deltaTime;

    }

    //calculates the direction the Tracker should move to get closer to the player
    private Vector2 Tracking()
    {
        //return the normalized result
        return ((Vector2)playerPos.position - rb.position).normalized;
    }

    //calculates the direction the Tracker should move to avoid colliding with other objects
    private Vector2 Avoidance()
    {
        Vector2 direction = Vector2.zero;

        Collider2D[] neighbors;

        //find all other colliders within a radius of this tracker
        neighbors = Physics2D.OverlapCircleAll(rb.position, 0.5f);

        //add together all the vectors pointing from this object to its neighbors
        foreach (Collider2D neighbor in neighbors)
            if (neighbor.gameObject.tag == "Stalker")
                direction += (Vector2)(rb.position - neighbor.gameObject.GetComponent<Rigidbody2D>().position);

        //take the average of all these vectors givin the direction it should move
        if (neighbors.Length > 0)
            direction /= neighbors.Length;

        //return the normalized result
        return direction.normalized;
    }

}
