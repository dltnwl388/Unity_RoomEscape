using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR1C1_Q1Arrow1 : MonoBehaviour
{
    Vector3 pos;

    float delta = 0.09f;
    float speed = 4.0f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.y += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}