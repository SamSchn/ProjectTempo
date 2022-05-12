using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected PlayerController player;
    protected Rigidbody2D rb;
    public int health;
    public int points;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this object was hit by something
        Hit(collision);
    }

    public void Hit(Collision2D collision)
    {
        //check if it was hit by a bullet
        if (collision.gameObject.tag == "Bullet")   //determine what hit it
            health -= 10;
        if (collision.gameObject.tag == "Explosion")  //each thing that hits it doesn different amount of damage
            health -= 30;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //add the points to the player
            PlayerManager._instance.GetComponent<PlayerData>().SetNumCurr(PlayerManager._instance.GetComponent<PlayerData>().GetNumCurr() + points);
        }

        
    }
}
