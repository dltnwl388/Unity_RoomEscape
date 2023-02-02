using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class AR2_FailStatus : MonoBehaviour
{
    private EventTrigger.Entry entry;

    [SerializeField] GameObject ICONS;
    [SerializeField] GameObject AR_Fail;
    [SerializeField] EventTrigger Again;

    [SerializeField] GameObject AR2C1;

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

        if (AR2C1 != null)
        {
            if (AR2C1.activeSelf == true)
            {
                AR2C1_Quizs();
            }
        }

        entry.callback.RemoveAllListeners();
    }

    void AR2C1_Quizs()
    {

    }
}