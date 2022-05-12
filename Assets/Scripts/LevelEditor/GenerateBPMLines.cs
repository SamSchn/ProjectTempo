using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GenerateBPMLines : MonoBehaviour
{
    public Color lineColor;
    public Color backgroundColor;
    private Image img;
    public int spacing;    //vertical space between each line

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        DrawLines(img, lineColor, backgroundColor, spacing);
    }

    public void DrawLines(Image img, Color col, Color back, int vertSpace)
    {
        Texture2D tex = new Texture2D((int)img.GetComponent<RectTransform>().rect.width, (int)img.GetComponent<RectTransform>().rect.height);

        //setbackground of texture to transparent
        for (int y = 0; y < (int)img.GetComponent<RectTransform>().rect.height; y ++)
            for (int x = 0; x < (int)img.GetComponent<RectTransform>().rect.width; x++)
                tex.SetPixel(x, y, back);

        //start from the bottom of image and draw lines left to right vertSpace apart
        for (int y = 0; y < (int)img.GetComponent<RectTransform>().rect.height; y += vertSpace)
            for (int x = 0; x < (int)img.GetComponent<RectTransform>().rect.width; x++)
                tex.SetPixel(x, y, col);

        tex.Apply();

        img.overrideSprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));

    }
}
