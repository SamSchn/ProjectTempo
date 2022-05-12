using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTimer;
    public string direction;
    public float lifeTime;
    private float timeAlive;
    public int numSpawn; //given time alive and time between each soawn, will the hold the total amount of enemies spawned by this spawner

    Vector2 screenBounds;

    public void UpdateSettings(float timer, float lifeTimeAge, GameObject enemy, string dir)
    {
        spawnTimer = timer;
        lifeTime = lifeTimeAge;
        prefab = enemy;
        direction = dir;
    }

    // Start is called before the first frame update
    void Start()
    {
        numSpawn = (int)(spawnTimer * timeAlive);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Spawn());
        timeAlive = 0;
    }

    IEnumerator Spawn()
    {
        Vector2 spawnPos;
        double innerSpawnWidth = screenBounds.x + (screenBounds.x * 0.2);
        double outerSpawnWidth = screenBounds.x + (screenBounds.x * 0.6); ;
        double innerSpawnHeight = screenBounds.y + (screenBounds.y * 0.2); ;
        double outerSpawnHeight = screenBounds.y + (screenBounds.y * 0.6); ;



        //we are going to split our big spawn area into 4 smaller rectangles
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            switch (SelectQadrant())
            {
               

                //our rectangle one(left) -- see diagram
                case 0:
                    spawnPos = new Vector2(Random.Range((float)(-outerSpawnWidth), (float)(-innerSpawnWidth)), Random.Range((float)(-outerSpawnHeight), (float)(outerSpawnHeight)));
                    Transform.Instantiate(prefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
                    break;
                //our rectangle two(bottom) -- see diagram
                case 1:
                    spawnPos = new Vector2(Random.Range((float)(-innerSpawnWidth), (float)(innerSpawnWidth)), Random.Range((float)(-outerSpawnHeight), (float)(-innerSpawnHeight)));
                    Transform.Instantiate(prefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
                    break;
                //our rectangle three(right) -- see diagram
                case 2:
                    spawnPos = new Vector2(Random.Range((float)(outerSpawnWidth), (float)(innerSpawnWidth)), Random.Range((float)(-outerSpawnHeight), (float)(outerSpawnHeight)));
                    Transform.Instantiate(prefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
                    break;
                //our rectangle two(top) -- see diagram
                case 3:
                    spawnPos = new Vector2(Random.Range((float)(innerSpawnWidth), (float)(-innerSpawnWidth)), Random.Range((float)(outerSpawnHeight), (float)(innerSpawnHeight)));
                    Transform.Instantiate(prefab, new Vector3(spawnPos.x, spawnPos.y, 0), Quaternion.identity);
                    break;
            }
        }
    }
     
    //given its parameters, select the quadrant to spawn
    private int SelectQadrant()
    {
        //the spawn rectangle
        int quadrant;

        //get the result
        if (direction == "left")
            quadrant = 0;
        else if (direction == "bottom")
            quadrant = 1;
        else if (direction == "right")
            quadrant = 2;
        else if (direction == "top")
            quadrant = 3;
        else
            quadrant = Random.Range(0, 4);

        return quadrant;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //keep track of how long this spawner has been alive
        timeAlive += Time.deltaTime;

        //check if its exceeded it's lifetime
        if (timeAlive > lifeTime)
            Destroy(this.gameObject);
    }

    private void OnValidate()
    {
        numSpawn = (int)(lifeTime / spawnTimer);
    }
}
