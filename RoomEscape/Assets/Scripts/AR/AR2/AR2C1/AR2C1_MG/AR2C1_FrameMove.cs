using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.ComponentModel;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR2C1_FrameMove : MonoBehaviour
{
    private EventTrigger.Entry entry;

    public GameObject FrameMove;

    public EventTrigger Frame;
    public Button Frame2;
    public GameObject Dia7;

    bool StartMove = false;

    void Update()
    {
        if (StartMove == true)
        {
            this.transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, -14) * Time.deltaTime * 4f;

            Invoke("StopFrameMove", 0.5f);
        }
    }

    void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(StartFrameMove);
        Frame.triggers.Remove(entry);
        Frame.triggers.Add(entry);
    }

    void StartFrameMove(BaseEventData p)
    {
        StartMove = true;

        Frame2.interactable = false;

        entry.callback.AddListener(StartFrameMove);
        Frame.triggers.Remove(entry);

        FrameMove.SetActive(true);

        AR2C1_MoveManager.instance.AR2C1_FrameClick();
    }

    void StopFrameMove()
    {
        StartMove = false;

        Dia7.SetActive(true);
    }
}