using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AR1C1_Q2OpenClose : MonoBehaviour
{
    public GameObject Q2Inventory;
    
    public GameObject Block0;
    public GameObject Block1;

    public void ClickedMyBag()
    {
        AR1_OpenClose.actionF();

        Q2Inventory.SetActive(true);
        Block0.SetActive(true);
        Block1.SetActive(true);
    }
}