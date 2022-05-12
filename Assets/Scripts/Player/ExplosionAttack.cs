﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAttack : MonoBehaviour
{
    private CircleCollider2D collider;
    private LineRenderer circle;
    private float radius;
    private float lifeTime;
    private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        circle = GetComponent<LineRenderer>();
        radius = 0.1f;
        lifeTime = 3.7f;
        timer = 0;
        StartCoroutine(ExpandCircle());
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the object once it's had enougph time to travel off screen
        if (timer > lifeTime)
            Destroy(this.gameObject);
        timer += 1.0F * Time.deltaTime;
    }

    public IEnumerator ExpandCircle()
    {
        //expand the circle and the collider object at the same rate
        while (true)
        {
            DrawCircle(360, radius, this.gameObject.GetComponent<Transform>().localPosition, 0.1f, 0.1f);
            collider.radius = radius;
            yield return new WaitForSecondsRealtime(0.015f);
            radius += 0.1f;
        }
        
    }


    //draws a circle given center point
    void DrawCircle(int vertexNumber, float radius, Vector3 centerPos, float startWidth, float endWidth)
    {
        circle.startWidth = startWidth;
        circle.endWidth = endWidth;
        circle.loop = true;
        float angle = 2 * Mathf.PI / vertexNumber;
        circle.positionCount = vertexNumber;

        for (int i = 0; i < vertexNumber; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                       new Vector4(0, 0, 1, 0),
                                       new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, radius, 0);
            circle.SetPosition(i, centerPos + rotationMatrix.MultiplyPoint(initialRelativePosition));

        }
    }
}
