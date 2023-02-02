using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public static OnLoad control;

    // ���߿� �߰��� ������ ��ҵ�
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