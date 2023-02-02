using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR2_Inventory : MonoBehaviour
{
    public List<AR2_Item> items;

    public AR2_Item Clover;
    public AR2_Item Heart;
    public AR2_Item Spade;
    public AR2_Item Dia;
    public AR2_Item Adopt;
    public AR2_Item Key;
    public AR2_Item Diary;
    public AR2_Item Old;
    public AR2_Item Gun;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private AR2_Slot[] slots;

    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<AR2_Slot>();
    }

    void Update()
    {
        if (AR2C1_MoveManager.isheart == true)
        {
            AR2C1_MoveManager.isheart = false;
            AddItem(Heart);
        }
        if (AR2C1_MoveManager.isdia == true)
        {
            AR2C1_MoveManager.isdia = false;
            AddItem(Dia);
        }
        if (AR2C1_MoveManager.isspade == true)
        {
            AR2C1_MoveManager.isspade = false;
            AddItem(Spade);
        }
        if (AR2C1_MoveManager.isclover == true)
        {
            AR2C1_MoveManager.isclover = false;
            AddItem(Clover);
        }
        if (AR2C1_MoveManager.isadopt == true)
        {
            AR2C1_MoveManager.isadopt = false;
            AddItem(Adopt);
        }
        if (AR2C1_MoveManager.iskey == true)
        {
            AR2C1_MoveManager.iskey = false;
            AddItem(Key);
        }
        if (AR2C1_MoveManager.isold == true)
        {
            AR2C1_MoveManager.isold = false;
            AddItem(Old);
        }
        if (AR2C1_MoveManager.isgun == true)
        {
            AR2C1_MoveManager.isgun = false;
            AddItem(Gun);
        }
        if (AR2C1_MoveManager.isdiary == true)
        {
            AR2C1_MoveManager.isdiary = false;
            AddItem(Diary);
        }
        if (AR2_Slot.keyused == true)
        {
            AR2_Slot.keyused = false;
            RemoveKey();
        }
        if (AR2C1_Drop.isusedkey == true)
        {
            AR2C1_Drop.isusedkey = false;
        }
    }
    void OnEnable()
    {
        FreshSlot();
    }
    public void FreshSlot()
    {
        int i = 0;
        for (; i<items.Count && i<slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for(; i<slots.Length; i++)
        {
            slots[i].item = null;
        }
    }
    public void AddItem(AR2_Item _item)
    {
        if (items.Count <slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {

        }
    }

    public void RemoveKey()
    {
        AR2_Item item = items.Find(x => x.itemName == "KEY");
        items.Remove(item);
        FreshSlot();
    }
}
