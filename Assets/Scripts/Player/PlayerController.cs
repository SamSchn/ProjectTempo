using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private PlayerData player;
    private Camera cam;
    public Vector2 mousePos;
    public float maxSpeed;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject explosionPrefab;
    public float invincibilityDuration;
    public float invDeltaFrame;
    private bool invincible;
    Vector2 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerData>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        firePoint = GameObject.Find("FirePoint").GetComponent<Transform>();
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if we have changed scenes then reset the camera referece
        if(cam == null)
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        //check if we are in the actual game
        if(SceneManager.GetActiveScene().name == "LevelOne")
        {
            if (Input.GetMouseButtonDown(0))
                FireTeleport();
            if (Input.GetMouseButtonDown(2))
                FireExplosion();
            if (Input.GetMouseButton(1))
                FireBoost();
        }
     
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    
    }

    private void FixedUpdate()
    {
        lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        MaxVelocity();
    }

    public Vector2 Position()
    {
        return rb.position;
    }


    public void FireBullet()
    {
        Vector2 dir = lookDir;
        rb.AddForce(-dir.normalized * 3, ForceMode2D.Impulse);

        //instantiate the bullet in the direction of where the player is looking
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Rigidbody2D>().velocity = lookDir.normalized * 10;
    }

    public void FireBoost()
    {
        //make sure the player has boost
        if (player.GetNumBoost() > 0)
        {
            Vector2 dir = lookDir;
            dir.Normalize();
            rb.AddForce(-dir * 4, ForceMode2D.Force);

            player.SetNumBoost(player.GetNumBoost() - (1 * Time.deltaTime * 25)); //subtract the boost from the player at a constant rate
        }
    }

    public void FireExplosion()
    {
        //check if the player has an explosion to fire
        if (player.GetNumExpos() > 0)
        {
            //instantiate the explosion prefab at the players current position
            Instantiate(explosionPrefab, Position(), this.gameObject.transform.rotation);

            //remove an explosion from the players inventory
            player.SetNumExpos(player.GetNumExpos() - 1);
        }
        
    }

    public void FireTeleport()
    {
        //check if the player has a teleport to use
        if (player.GetNumTele() > 0)
        {
            //set player velocity to 0
            rb.velocity = Vector2.zero;

            //tp the player to the mouse position
            this.gameObject.transform.position = mousePos;

            //remove a teleport from the players inventory
            player.SetNumTele(player.GetNumTele() - 1);
        }
    }

    public void MaxVelocity()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    //check for getting hit by an enemy
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //check is the player is in i-frames
        if(!invincible)
        {
            //if was actually an enemy that hit them
            if (collision.gameObject.layer == 10)//if the layer is enemy
            {
                if (player.GetNumLives() == 1)
                {
                    GameManager._instance.ChangeToDeathScreen();
                    player.LatestPercent(GetComponent<SyncedInput>().beats[0] / 515); //calculate the percent of how far along they got
                }
                else
                {
                    player.SetNumLives(player.GetNumLives());
                    Destroy(collision.gameObject);               //kill the enemy that ran into the player
                    cam.GetComponent<CameraShake>().Shake(0.5f);
                }
                StartCoroutine(StartIFrames());

            }
        }
        //if it was a collision with the screenbounds
        if (collision.gameObject.layer == 11)
        {
            //determine which part of the screen the player ran into
            if(collision.gameObject.name == "Top")
            {
                rb.velocity = Vector2.Reflect(rb.velocity, Vector2.down);
            }
            if (collision.gameObject.name == "Right")
            {
                rb.velocity = Vector2.Reflect(rb.velocity, Vector2.left);
            }
            if (collision.gameObject.name == "Bottom")
            {
                rb.velocity = Vector2.Reflect(rb.velocity, Vector2.up);
            }
            if (collision.gameObject.name == "Left")
            {
                rb.velocity = Vector2.Reflect(rb.velocity, Vector2.right);
            }
        }
    }

    private IEnumerator StartIFrames()
    {
        Debug.Log("Player turned invincible!");
        invincible = true;

        for (float i = 0; i < invincibilityDuration; i += invDeltaFrame)
        {
            if (transform.localScale == Vector3.one)
            {
                transform.localScale = Vector3.zero;
            }
            else
            {
                transform.localScale = Vector3.one;
            }
            yield return new WaitForSeconds(invDeltaFrame);
        }

        Debug.Log("Player is no longer invincible!");
        invincible = false;
    }

}
