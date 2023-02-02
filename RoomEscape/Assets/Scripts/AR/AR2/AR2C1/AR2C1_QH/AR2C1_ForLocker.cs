using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AR2C1_ForLocker : MonoBehaviour
{
    private EventTrigger.Entry entry;

    public EventTrigger LockerNum;

    public GameObject image0;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    public GameObject image9;

    int Num = 0;

    void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(Nums);
        LockerNum.triggers.Remove(entry);
        LockerNum.triggers.Add(entry);
    }

    void Nums(BaseEventData p)
    {
        if (Num == 0)
        {
            Num = 1;

            image0.SetActive(false);
            image1.SetActive(true);
        }
        else if (Num == 1)
        {
            Num = 2;

            image1.SetActive(false);
            image2.SetActive(true);
        }
        else if (Num == 2)
        {
            Num = 3;

            image2.SetActive(false);
            image3.SetActive(true);
        }
        else if (Num == 3)
        {
            Num = 4;

            image3.SetActive(false);
            image4.SetActive(true);
        }
        else if (Num == 4)
        {
            Num = 5;

            image4.SetActive(false);
            image5.SetActive(true);
        }
        else if (Num == 5)
        {
            Num = 6;

            image5.SetActive(false);
            image6.SetActive(true);
        }
        else if (Num == 6)
        {
            Num = 7;

            image6.SetActive(false);
            image7.SetActive(true);
        }
        else if (Num == 7)
        {
            Num = 8;

            image7.SetActive(false);
            image8.SetActive(true);
        }
        else if (Num == 8)
        {
            Num = 9;

            image8.SetActive(false);
            image9.SetActive(true);
        }
        else if (Num == 9)
        {
            Num = 0;

            image9.SetActive(false);
            image0.SetActive(true);
        }
    }
}