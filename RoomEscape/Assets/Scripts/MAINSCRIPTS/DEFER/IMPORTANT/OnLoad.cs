using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public static OnLoad control;

    // 나중에 추가할 데이터 요소들
    // public float a;
    // public float b;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        
        if(control == null)
        {
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }
}