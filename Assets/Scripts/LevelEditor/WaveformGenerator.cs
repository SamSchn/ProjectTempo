using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WaveformGenerator : MonoBehaviour
{

    public int width;
    public int height;
    public Color waveformColor;
    public Color bgColor;
    public float sat;

    private Image img;
    [SerializeField] AudioClip clip;

    void Awake()
    {
        img = GetComponent<Image>();
        Texture2D texture = CreateWaveFormTexture(clip, sat, width, height, waveformColor, bgColor);
        img.overrideSprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture2D CreateWaveFormTexture(AudioClip audio, float saturation, int width, int height, Color col, Color back)
    {
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGBA32, false);
        float[] samples = new float[audio.samples];
        float[] waveform = new float[width];

        audio.GetData(samples, 0);

        int packSize = (audio.samples / width) + 1;

        int s = 0;

        for (int i = 0; i < audio.samples; i += packSize)
        {
            waveform[s] = Mathf.Abs(samples[i]);
            s++;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tex.SetPixel(x, y, back);
            }
        }

        for (int y = 0; y < waveform.Length; y++)
        {
            for (int x = 0; x <= waveform[y] * ((float)width * .75f); x++)
            {
                tex.SetPixel((width / 2) + x, y, col);
                tex.SetPixel((width / 2) - x, y, col);
            }
        }
     
        tex.Apply();


        return tex;
    }
}
