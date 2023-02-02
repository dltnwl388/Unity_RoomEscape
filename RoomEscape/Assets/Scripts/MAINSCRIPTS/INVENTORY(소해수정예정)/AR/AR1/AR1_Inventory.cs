using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class AR1_Inventory : MonoBehaviour
{
    public List<AR1_Item> items;
    public static string[] Forname = new string[12];

    [SerializeField] private Transform slotParent;
    [SerializeField] private AR1_Slot[] slots;

    public static Action action;

    int a = 0;
    public static int FOR_R = 0;

    void Awake()
    {
        FreshSlot();

        action = () => { AR1C1_AllDel(); };
    }

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<AR1_Slot>();
    }

    public void FreshSlot()
    {
        int i = 0;

        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void Additem(AR1_Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();

            string name = _item.itemName;

            if (a < 12)
            {
                Forname[a] = name;
                a++;
            }
            else
            {
                a = 0;
            }
        }
        else
        {
            print("½½·ÔÀÌ °¡µæ Â÷ ÀÖ½À´Ï´Ù.");
        }
    }

    public void deleteBookitem(string value)
    {
        while(items.Count > 2)
        {
            items[2] = null;
            slots[2].item = null;
            items.Remove(items[2]);
        }

        int index = Array.IndexOf(Forname, "AR1C1_PAPERS");
        items[index] = null;
        slots[index].item = null;
        items.Remove(items[index]);

        FreshSlot();
    }

    public void deletekey()
    {
        items[0] = null;
        slots[0].item = null;
        items.Remove(items[0]);
    }

    public void AR1C1_AllDel()
    {
        for (int i = 0; i < 2; i++)
        {
            items[0] = null;
            slots[0].item = null;
            items.Remove(items[0]);

            FreshSlot();
        }
    }

    public static int FindIndex(string value)
    {
        int index = Array.IndexOf(Forname, value);

        return index;
    } 

    public void FindingName(AR1_Item _item)
    {
        string name = _item.itemName;

        switch (name.Contains("CONFIDENTIAL"))
        {
            case true:
                FOR_R += 100;
                break;
        }
    }
}