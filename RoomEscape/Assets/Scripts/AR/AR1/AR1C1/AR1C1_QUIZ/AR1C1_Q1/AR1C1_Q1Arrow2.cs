using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR1C1_Q1Arrow2 : MonoBehaviour
{
    Vector3 pos;

    float delta = 0.1f;
    float speed = 4.0f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}