using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingerController : EnemyBase
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
        

        //set its movement direction to where the player is when it is spawned
        dir = player.Position() - rb.position;

        dir.Normalize();

        rb.velocity= dir * speed;

        //used to keep track of how long the object has been in existence
        maxLifeTime = 5f;
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

}
