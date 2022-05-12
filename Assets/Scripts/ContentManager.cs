using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PanelResizer))]
public class ContentManager : MonoBehaviour
{
    public AudioClip audio;
    public int bpm;
    private float bps;  //varibale to store beats per second, makes calculates spacing and size much easier
    private float size;
    private float length;
    private PanelResizer panel;

    void Start()
    {
        panel = GetComponent<PanelResizer>();

        length = audio.length;

        //find beats per second by dividing beats per minute by 60;
        bps = bpm / 60;
        
        size = length * bps * 25;
    
        panel.changeHeight(size);
    }
}
