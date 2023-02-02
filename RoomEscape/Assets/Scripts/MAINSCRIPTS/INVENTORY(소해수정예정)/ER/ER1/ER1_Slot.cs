using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ER1_Slot : MonoBehaviour
{
    [SerializeField] Image image;

    private ER1_Item _item;

    public GameObject I_E;

    public GameObject I_Ladder;
    public GameObject I_Meat;
    public GameObject I_Bird;
    public GameObject I_Honey;
    public GameObject I_Gloves;
    public GameObject laddermoving;
    public GameObject Answer;

    public Text Title;
    public Text Explain;

    public static int removeitem = 0;
    public static bool ladderused = false;
    

    public static Action removehoney;
    public static Action removemeat;
    public static Action removebird;

    void Awake()
    {
        removehoney = () => { forRemoveHoney(); };
        removemeat = () => { forRemoveMeat(); };
        removebird = () => { forRemoveBird(); };
        laddermoving.SetActive(false);
        Answer.SetActive(false);
    }

    public ER1_Item item
    {
        get { return _item; }
        set
        {
            _item = value;

            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    public void OnclickSlot()
    {
        if (_item != null)
        {
            I_E.SetActive(true);
            I_Bird.SetActive(false);
            I_Gloves.SetActive(false);
            I_Honey.SetActive(false);
            I_Ladder.SetActive(false);
            I_Meat.SetActive(false);
            laddermoving.SetActive(false);
            Answer.SetActive(false);

            if (item.itemName == "MEAT")
            {
                Title.text = "���";
                Explain.text = "��� ���� �ż��� ���.";

                I_Meat.SetActive(true);

            }
            else if (item.itemName == "HONEY")
            {
                Title.text = "��";
                Explain.text = "�������� ���� ä���� �߻� ��.";

                I_Honey.SetActive(true);
            }
            else if (item.itemName == "GLOVES")
            {
                if (ER1C1_MoveManager.ToTreeCheck == true)
                {
                    if (ER1C1_MoveManager.ForGlove == true && ER1_DialogueManager.isDialogue == false)
                    {
                        I_E.SetActive(false);
                        image.color = new Color(1, 1, 1, 0);
                        removeitem = 1;

                        ER1C1_MoveManager.instance.Glove();
                    }
                    else
                    {
                        Title.text = "�尩";
                        Explain.text = "���������߰� �� ���ٴϴ� �尩.";

                        I_Gloves.SetActive(true);
                    }
                }
                else
                {
                    Title.text = "�尩";
                    Explain.text = "���������߰� �� ���ٴϴ� �尩.";

                    I_Gloves.SetActive(true);
                }
            }
            else if (item.itemName == "LADDER")
            {
                if (ER1C1_MoveManager.forladder == true)
                {
                    I_E.SetActive(false);
                    image.color = new Color(1, 1, 1, 0);
                    ladderused = true;
                    laddermoving.SetActive(true);
                    Answer.SetActive(true);
                    laddermoving.transform.localPosition = new Vector2(-2, -400);
                }
                else
                {
                    Title.text = "��ٸ�";
                    Explain.text = "��� �� ������ �߰��� ��ٸ�.";

                    I_Ladder.SetActive(true);
                }
                
            }
            else if (item.itemName == "BIRD")
            {
                Title.text = "������";
                Explain.text = "��û ����� ������.";

                I_Bird.SetActive(true);
            }
        }
    }

    public void forRemoveHoney()
    {
        I_E.SetActive(false);
        image.color = new Color(1, 1, 1, 0);
        removeitem = 2;
    }

    public void forRemoveMeat()
    {
        I_E.SetActive(false);
        image.color = new Color(1, 1, 1, 0);
        removeitem = 3;
    }

    public void forRemoveBird()
    {
        I_E.SetActive(false);
        image.color = new Color(1, 1, 1, 0);
        removeitem = 4;
    }
}