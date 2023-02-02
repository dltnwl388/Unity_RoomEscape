using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad_Manager : MonoBehaviour
{
    private Object ManagerControl;
    
    void Awake()
    {
        ManagerControl = Resources.Load("Prefabs/OnLoad");

        if(OnLoad.control == null)
        {
            Instantiate(ManagerControl);
        }

        Destroy(gameObject);
    }
}