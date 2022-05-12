using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellerController : EnemyBase
{
    public float speed;
    private float maxLifeTime;
    private float timer;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        rb = GetComponent<Rigidbody2D>();


        //set its movement direction to where a random point on the screen
        dir = GetPoint() - rb.position;

        dir.Normalize();

        rb.velocity = dir * speed;

        //used to keep track of how long the object has been in existence
        maxLifeTime = 10f;
        timer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //destroy the object once it's had enougph time to travel off screen
        if (timer > maxLifeTime)
            Destroy(this.gameObject);
        timer += 1.0F * Time.deltaTime;
    }

    Vector2 GetPoint()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //pick random point inside the camer screen
        return new Vector2(Random.Range(0f, (float)screenBounds.x), Random.Range(0f, (float)screenBounds.y));
    }


}
