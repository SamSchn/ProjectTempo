using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelResizer : MonoBehaviour
{
    public List<RectTransform> children;

    private RectTransform panel;
    private float origHeight;
    private float changeRatio;

    // awake
    void Awake()
    {
        panel = GetComponent<RectTransform>();

        origHeight = panel.sizeDelta.y;

    }

    public void changeHeight(float height)
    {
        print("hello");
        changeRatio = height / origHeight;

        //set the vertical hieght of the panel with given height -- ensure that it only moves upward
        panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        panel.anchoredPosition = new Vector2(0, height / 2);

        print("original height was: " + origHeight);
        print("chnage ratio was: " + changeRatio);

        foreach (RectTransform child in children)
            child.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, child.sizeDelta.y * changeRatio);
    }
}
