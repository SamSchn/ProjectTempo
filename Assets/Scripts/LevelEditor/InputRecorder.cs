using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{

    //subclass to store the input and timings
    public class InputType
    {
        public float timeInSong { get; }

        public InputType(double time, int inputType)
        {
            timeInSong = (float)time;
        }
    }

    public AudioSource song;
    public List<InputType> inputs;
    private double time;
    private double prevTime;
    private InputType[] inputsArray;

    private void Start()
    {
        inputs = new List<InputType>();
        Debug.Log(song.timeSamples);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AddLeftClick();
        if (Input.GetMouseButtonDown(1))
            Save();
        if (Input.GetMouseButtonDown(2))
            StartRecording();

    }

    public void StartRecording()
    {
        prevTime = Time.time;//initialize this to the current time
        song.Play();
    }

    //adds a left click to the input array
    public void AddLeftClick()
    {
        inputs.Add(new InputType(song.time, 0));
        prevTime = Time.time;//update the prev time
        print(song.timeSamples.ToString());
    }

    //saves the inputs for this level
    public void Save()
    {
        print("hello");
        inputsArray = inputs.ToArray();
    }

}
