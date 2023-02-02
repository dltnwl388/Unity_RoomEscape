using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR1_ItemDescription: MonoBehaviour
{
    public GameObject Inventory;

    bool Check = false;

    void OnEnable()
    {
        AR1_OpenClose.actionF();
    }

    void OnDisable()
    {
        if (Check == true)
        {
            AR1_OpenClose.actionT();

            Inventory.SetActive(true);
        }
        else
        {
            if (AR1C1_MoveManager.ItemState == false)
            {
                Check = true;

                AR1_OpenClose.actionT();

                AR1C1_MoveManager.instance.AR1C1_BackBtnAT();
            }
            else
            {
                AR1_OpenClose.actionT();

                Inventory.SetActive(true);
            }
        }
    }
}