using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private float maxLifeTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        maxLifeTime = 3.5f;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destrot the bullet when it hits an enemy
        if (collision.gameObject.layer == 10)//10 is enemy layer
            Destroy(this.gameObject);
      
    }

}
