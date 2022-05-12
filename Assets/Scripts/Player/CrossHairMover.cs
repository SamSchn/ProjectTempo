using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairMover : MonoBehaviour
{

    private Transform pos;

    private Camera cam;

    public Vector2 mousePos;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        pos = GetComponent<Transform>();
        Cursor.visible = false; //hide the cursor from the player
    }

    // Update is called once per frame
    void Update()
    {
        //if we have changed scenes then reset the camera referece
        if (cam == null)
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        pos.position = mousePos;
    }
}
