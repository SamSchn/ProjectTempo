using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{
    public int songBpm;
    public float songBps;
    public float songPos;
    public float songBeatPos;
    public float dspSongTime;
    public bool doesSpawn;
    private SyncedInput player;
    private SpawnManager spawner;
    private AudioSource song;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<SyncedInput>();
        if (doesSpawn)
            spawner = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        song = GetComponent<AudioSource>();
        songBps = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        song.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //find how long since the song has started
        songPos = (float)(AudioSettings.dspTime - dspSongTime);

        //find how many beats since the song has started
        songBeatPos = songPos / songBps;

        player.HandleBeats(songBeatPos);
        if (doesSpawn)
            spawner.HandleBeats(songBeatPos);

    }
}
