using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AR1_OpenClose : MonoBehaviour
{
    public GameObject Inventory;

    public GameObject AR1C1;

    public GameObject Block0;
    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;
    public GameObject Block4;
    public GameObject Block5;
    public GameObject Block6;
    public GameObject Block7;
    public GameObject Block8;
    public GameObject Block9;
    public GameObject Block10;
    public GameObject Block11;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;

    public EventTrigger Mybag;

    private EventTrigger.Entry entry;

    bool m_Temp = false;

    public static Action actionT;
    public static Action actionF;

    void Awake()
    {
        actionT = () => { MyBagTrue(); };
        actionF = () => { MyBagFalse(); }; 
    }

    private void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(FirstClick);
        entry.callback.AddListener(ClickedMyBag);
        Mybag.triggers.Remove(entry);
        Mybag.triggers.Add(entry);
    }

    public void MyBagTrue()
    {
        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(FirstClick);
        entry.callback.AddListener(ClickedMyBag);
        Mybag.triggers.Remove(entry);
        Mybag.triggers.Add(entry);
    }

    public void MyBagFalse()
    {
        entry.callback.RemoveAllListeners();
        Mybag.triggers.Remove(entry);
    }

    public void FirstClick(BaseEventData p)
    {
        if (m_Temp == false)
        {
            m_Temp = true;

            AR1C1_MoveManager.instance.MybagClick();
        }
    }

    public void ClickedMyBag(BaseEventData p)
    {
        MyBagFalse();

        Inventory.SetActive(true);

        Block0.SetActive(false);
        Block1.SetActive(false);
        Block2.SetActive(false);
        Block3.SetActive(false);
        Block4.SetActive(false);
        Block5.SetActive(false);
        Block6.SetActive(false);
        Block7.SetActive(false);
        Block8.SetActive(false);
        Block9.SetActive(false);
        Block10.SetActive(false);
        Block11.SetActive(false);

        if (AR1C1!= null) 
        {
            AR1C1_MoveManager.instance.AR1C1_BackBtnAF();
        }
    }

    public void ClickedX()
    {
        MyBagTrue();

        Inventory.SetActive(false);

        if (AR1C1 != null)
        {
            Item1.SetActive(true);
            Item2.SetActive(true);
            Item3.SetActive(true);
            Item4.SetActive(true);
        }

        if (AR1C1 != null)
        {
            AR1C1_MoveManager.instance.AR1C1_BackBtnAT();
        }
    }
}