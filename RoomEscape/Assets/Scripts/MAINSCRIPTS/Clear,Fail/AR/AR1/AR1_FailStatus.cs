using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class AR1_FailStatus : MonoBehaviour
{
    [SerializeField] GameObject ICONS;
    [SerializeField] GameObject AR_Fail;
    [SerializeField] EventTrigger Again;

    [SerializeField] GameObject AR1C1;
    [SerializeField] GameObject AR1C2;

    [SerializeField] GameObject AR1C1_Q4;

    [SerializeField] GameObject AR1C2_Q1;
    [SerializeField] GameObject AR1C2_EmptyHouse;
    [SerializeField] GameObject AR1C2_Q2;
    [SerializeField] GameObject AR1C2_Q3;
    [SerializeField] GameObject AR1C2_Q4;
    [SerializeField] GameObject AR1C2_Q5;

    private EventTrigger.Entry entry;

    private void OnEnable()
    {
        ICONS.SetActive(false);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.AddListener(Fail);
        Again.triggers.Remove(entry);
        Again.triggers.Add(entry);
    }

    void Fail(BaseEventData p)
    {
        ICONS.SetActive(true);
        AR_Fail.SetActive(false);

        if (AR1C1 != null)
        {
            if (AR1C1.activeSelf == true)
            {
                AR1C1_Quizs();
            }
        }
        else if (AR1C2 != null)
        {
            if (AR1C2.activeSelf == true)
            {
                AR1C2_Quizs();
            }
        }

        entry.callback.RemoveAllListeners();
    }

    void AR1C1_Quizs()
    {
        if (AR1C1_Q4.activeSelf == true) 
        {
            AR1C1_MoveManager.instance.AR1C1_Q4Fail();
        }
    }

    void AR1C2_Quizs()
    {
        if (AR1C2_Q1.activeSelf == true)
        {
            AR1C2_MoveManager.instance.AR1C2_Q1NoticeClick();
            GameObject.Find("AR1C2_Quiz1").GetComponent<AR1_InteractionController>().Text();
        }
        else if (AR1C2_EmptyHouse.activeSelf == true)
        {
            GameObject.Find("AR1C2_EMPTYHOUSE").GetComponent<AR1_InteractionController>().Text();
        }
        else if (AR1C2_Q2.activeSelf == true)
        {
            AR1C2_MoveManager.instance.AR1C2_Q2();
            GameObject.Find("AR1C2_Q2Main").GetComponent<AR1_InteractionController>().Text();
        }
        else if (AR1C2_Q3.activeSelf == true)
        {
            AR1C2_MoveManager.instance.AR1C2_Q3();
        }
        else if (AR1C2_Q4.activeSelf == true)
        {
            AR1C2_MoveManager.instance.AR1C2_Q4();
        }
        else if (AR1C2_Q5.activeSelf == true)
        {
            AR1C2_MoveManager.instance.AR1C2_Q5();
        }
    }
}