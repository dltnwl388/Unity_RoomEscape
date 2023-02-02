using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ER1_Inventory : MonoBehaviour
{
    public List<ER1_Item> items;

    public ER1_Item Meat;
    public ER1_Item Feed;
    public ER1_Item Honey;
    public ER1_Item Ladder;

    public static string[] Forname = new string[15];

    [SerializeField] private Transform slotParent;
    [SerializeField] private ER1_Slot[] slots;

    int a = 2;
    int b = 3;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<ER1_Slot>();
    }

    void Update()
    {
        RemoveItem();

        if (ER1C1_MoveManager.MeatCheck == true)
        {
            ER1C1_MoveManager.MeatCheck = false;

            AddItem(Meat);
        }
        if (ER1C1_MoveManager.LadderAdd == true)
        {
            ER1C1_MoveManager.LadderAdd = false;
            AddItem(Ladder);
        }

        if (ER1C1_MoveManager.FeedCheck == true)
        {
            ER1C1_MoveManager.FeedCheck = false;

            ReturnFeed(Feed);
        }

        if (ER1C1_MoveManager.BearMeat == true)
        {
            ER1C1_MoveManager.BearMeat = false;

            ReturnMeat(Meat);
        }

        if (ER1C1_MoveManager.BirdHoney == true)
        {
            ER1C1_MoveManager.BirdHoney = false;

            ReturnHoney(Honey);
        }
        if (ER1_Slot.ladderused == true)
        {
            ER1_Slot.ladderused = false;
            RemoveLadder();
        }
    }

    void OnEnable()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;

        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i<slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(ER1_Item _item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(_item);

            FreshSlot();
        }   
        else
        {

        }
    }

    public void RemoveItem()
    {
        if (ER1_Slot.removeitem == 1)
        {
            RemoveGloves();
        }
        if (ER1_Slot.removeitem == 2)
        {
            RemoveHoney();
        }
        if (ER1_Slot.removeitem == 3)
        {
            RemoveMeat();
        }
        if (ER1_Slot.removeitem == 4)
        {
            RemoveBird();
        }
    }

    public void RemoveGloves()
    {
        ER1_Item iitem = items.Find(x => x.itemName == "GLOVES");
        items.Remove(iitem);
        ER1_Slot.removeitem = 100;

        a = 1;
        b = 2;

        FreshSlot();
    }

    public void RemoveHoney()
    {
        ER1_Item iitem = items.Find(x => x.itemName == "HONEY");
        items.Remove(iitem);
        ER1_Slot.removeitem = 100;

        FreshSlot();
    }

    public void RemoveMeat()
    {
        ER1_Item iitem = items.Find(x => x.itemName == "MEAT");
        items.Remove(iitem);
        ER1_Slot.removeitem = 100;

        FreshSlot();
    }

    public void RemoveBird()
    {
        ER1_Item iitem = items.Find(x => x.itemName == "BIRD");
        items.Remove(iitem);
        ER1_Slot.removeitem = 100;

        FreshSlot();
    }

    public void RemoveLadder()
    {
        ER1_Item iitem = items.Find(x => x.itemName == "LADDER");
        items.Remove(iitem);
        ER1_Slot.removeitem = 100;
        

        FreshSlot();
    }

    public void ReturnFeed(ER1_Item _item)
    {
        items.Insert(0, _item);

        FreshSlot();
    }

    public void ReturnMeat(ER1_Item _item)
    {
        items.Insert(a, _item);

        FreshSlot();
    }

    public void ReturnHoney(ER1_Item _item)
    {
        items.Insert(b, _item);

        FreshSlot();
    }
}