using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1C1_Q2GetBook : MonoBehaviour
{
    public GameObject CB;
    public GameObject CG;
    public GameObject GP;
    public GameObject GR;
    public GameObject W1;
    public GameObject W2;
    public GameObject W3;
    public GameObject W4;
    public GameObject W5;
    public GameObject W6;

    public EventTrigger ClickBtn;

    private EventTrigger.Entry entry;

    int i = 0;

    public void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(FirstClickBtn);
        ClickBtn.triggers.Remove(entry);
        ClickBtn.triggers.Add(entry);
    }

    public void FirstClickBtn(BaseEventData p)
    {
        GameObject.Find("AR1C1_EmptyText1").GetComponent<AR1_InteractionController>().Text();
        AR1C1_MoveManager.instance.BackBtnMGF();
    }

    public void CBClick()
    {
        Destroy(CB);

        Test("CB");
    }

    public void CGClick()
    {
        Destroy(CG);
        Test("CG");
    }

    public void GPClick()
    {
        Destroy(GP);
        Test("GP");
    }

    public void GRClick()
    {
        Destroy(GR);
        Test("GR");
    }

    public void W1Click()
    {
        Destroy(W1);
        Test("W1");
    }

    public void W2Click()
    {
        Destroy(W2);
        Test("W2");
    }

    public void W3Click()
    {
        Destroy(W3);
        Test("W3");
    }

    public void W4Click()
    {
        Destroy(W4);
        Test("W4");
    }

    public void W5Click()
    {
        Destroy(W5);
        Test("W5");
    }

    public void W6Click()
    {
        Destroy(W6);
        Test("W6");
    }

    void Test(string a)
    {
        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(TwoClickBtn);
        ClickBtn.triggers.Remove(entry);
        ClickBtn.triggers.Add(entry);

        if ("CB" == a || "CG" == a || "GP" == a || "GR" == a) 
        {
            i++;
        }

        if (i == 4)
        {
            entry.callback.RemoveAllListeners();
            entry.callback.AddListener(ThreeClickBtn);
            ClickBtn.triggers.Remove(entry);
            ClickBtn.triggers.Add(entry);
        }
    }

    public void TwoClickBtn(BaseEventData p)
    {
        GameObject.Find("AR1C1_EmptyText2").GetComponent<AR1_InteractionController>().Text();
        AR1C1_MoveManager.instance.BackBtnMGF();
    }

    public void ThreeClickBtn(BaseEventData p)
    {
        GameObject.Find("AR1C1_EmptyText3").GetComponent<AR1_InteractionController>().Text();
        AR1C1_MoveManager.instance.BackBtnMGF();
    }
}