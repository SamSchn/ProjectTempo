using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public class SpawnContainer
    {
        private float beat;
        private float timer;
        private float age;
        private GameObject enemy;
        private string dir;

        public SpawnContainer(float beatNum, float spawnTimer, float lifeTime, GameObject prefab, string direction)
        {
            beat = beatNum;
            timer = spawnTimer;
            age = lifeTime;
            enemy = prefab;
            dir = direction;

        }

        //return the beat
        public float GetBeat()
        {
            return beat;
        }

        //return the timer
        public float GetTimer()
        {
            return timer;
        }

        //return the age
        public float GetAge()
        {
            return age;
        }

        //return the enemy
        public GameObject GetEnemy()
        {
            return enemy;
        }

        //return the direction
        public string GetDirection()
        {
            return dir;
        }



    }

    public GameObject spawner;
    public GameObject linger;
    public GameObject tracker;
    public GameObject stalker;
    public GameObject traveller;

    public List<SpawnContainer> spawns;

    private void Awake()
    {
        spawns = new List<SpawnContainer>() {new SpawnContainer(5, 1f, 40, traveller, null),
                                             new SpawnContainer(31.7f, 0.02f, 2, linger, "bottom"),
                                             //------------------- Beat 50 ---------------------//
                                             new SpawnContainer(62f, 1f, 2.1f, tracker, "top"),
                                             new SpawnContainer(62f, 1f, 2.1f, tracker, "right"),
                                             new SpawnContainer(62f, 1f, 2.1f, tracker, "bottom"),
                                             new SpawnContainer(62f, 1f, 2.1f, tracker, "left"),
                                             new SpawnContainer(79, 1.5f, 34, linger, null),
                                             new SpawnContainer(79, 1f, 34, traveller, null),
                                             new SpawnContainer(95, 1f, 1.1f, tracker, "top"),
                                             new SpawnContainer(95, 1f, 1.1f, tracker, "right"),
                                             new SpawnContainer(95, 1f, 1.1f, tracker, "bottom"),
                                             new SpawnContainer(95, 1f, 1.1f, tracker, "left"),
                                             new SpawnContainer(95, 3f, 7f, tracker, null),
                                             //------------------- Beat 100 ---------------------//
                                             new SpawnContainer(124, 1f, 1.5f, stalker, "right"),
                                             new SpawnContainer(124, 1f, 1.5f, stalker, "left"),
                                             new SpawnContainer(130, 0.1f, 0.25f, tracker, "right"),
                                             new SpawnContainer(132, 0.05f, 0.3f, tracker, null),
                                             //------------------- Beat 150 ---------------------//
                                             new SpawnContainer(163, 1f, 20, traveller, null),
                                             new SpawnContainer(163, 1f, 20, traveller, null),
                                             new SpawnContainer(170, 0.9f, 20, linger, null),
                                             new SpawnContainer(169, 0.05f, 0.25f, stalker, "top"),
                                             new SpawnContainer(196, 0.39f, 20, linger, "left"),
                                             //------------------- Beat 200 ---------------------//
                                             new SpawnContainer(208, 0.7f, 20, traveller, null),
                                             new SpawnContainer(225, 3f, 7f, tracker, "top"),
                                             new SpawnContainer(225, 3f, 7f, tracker, "right"),
                                             new SpawnContainer(225, 3f, 7f, tracker, "bottom"),
                                             new SpawnContainer(225, 3f, 7f, tracker, "left"),
                                             new SpawnContainer(240, 0.6f, 12f, linger, "top"),
                                             new SpawnContainer(240, 0.6f, 12f, linger, "bottom"),
                                             //------------------- Beat 250 ---------------------//
                                             new SpawnContainer(258, 0.05f, 0.11f, tracker, "right"),
                                             new SpawnContainer(258, 0.05f, 0.11f, tracker, "left"),
                                             new SpawnContainer(257, 1.7f, 25f, tracker, null),
                                             new SpawnContainer(257, 0.5f, 25, traveller, null),
                                             //------------------- Beat 300 ---------------------//
                                             new SpawnContainer(308, 1f, 18f, traveller, null),
                                             new SpawnContainer(323, 0.4f, 9f, linger, null),
                                             new SpawnContainer(335, 1f, 1.1f, stalker, "top"),
                                             new SpawnContainer(335, 1f, 1.1f, stalker, "right"),
                                             new SpawnContainer(335, 1f, 1.1f, stalker, "bottom"),
                                             new SpawnContainer(335, 1f, 1.1f, stalker, "left"),
                                             new SpawnContainer(335, 6f, 60f, stalker, null),
                                             new SpawnContainer(339, 1f, 2.1f, tracker, "top"),
                                             new SpawnContainer(339, 1f, 2.1f, tracker, "right"),
                                             new SpawnContainer(339, 1f, 2.1f, tracker, "bottom"),
                                             new SpawnContainer(339, 1f, 2.1f, tracker, "left"),
                                             new SpawnContainer(342, 3f, 55f, tracker, null),
                                             //------------------- Beat 350 ---------------------//
                                             new SpawnContainer(350, 1f, 52f, linger, null),
                                             new SpawnContainer(350, 1f, 52f, traveller, null),
                                             //------------------- Beat 400 ---------------------//
                                             new SpawnContainer(420, 0.4f, 25f, linger, null),
                                             new SpawnContainer(420, 0.4f, 25f, traveller, null),
                                             //------------------- Beat 450 ---------------------//
                                             new SpawnContainer(450, 1f, 40f, traveller, null)
        };
    }

    public void HandleBeats(float currBeat)
    {
        if(spawns.Count > 0)
        {
            EnemySpawner temp;

            //if we have hit the next beat
            if (currBeat >= spawns[0].GetBeat())
            {
                //spawn that enemy spawner
                temp = Transform.Instantiate(spawner, new Vector2(0, 0), Quaternion.identity).GetComponent<EnemySpawner>();
                SetSettings(temp);
                spawns.RemoveAt(0);
            }
        }
    }

    private void SetSettings(EnemySpawner enemySpawner)
    {
        enemySpawner.UpdateSettings(spawns[0].GetTimer(), spawns[0].GetAge(), spawns[0].GetEnemy(), spawns[0].GetDirection());
    }

}
