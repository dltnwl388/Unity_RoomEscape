using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR1_Slot : MonoBehaviour
{
    private AR1_Item _item;

    [SerializeField] Image image;

    public GameObject Inventory;
    public GameObject Black;
    public GameObject CBtn;
    public GameObject ExBtn;
    public Text TitleText;
    public Text ExText;
    public Text ExBtnText;

    public GameObject Quiz2Content;

    public GameObject Q3Paper;
    public GameObject Q4Paper;

    public GameObject Block0;
    public GameObject Q2Block;
    public static int Putnum;

    public Text TopText;
    public Text BottomText;

    public AR1_Item item
    {
        get 
        { 
            return _item; 
        }
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

    public void OnClickSlot()
    {
        if (_item != null)
        {
            Black.SetActive(true);
            CBtn.SetActive(true);
            ItemExplanation();

            if (item.itemName == "AR1C1_CorrectBlue")
            {
                Putnum = 1;
            }
            if (item.itemName == "AR1C1_CorrectGreen")
            {
                Putnum = 2;
            }
            if (item.itemName == "AR1C1_CorrectPurple")
            {
                Putnum = 3;
            }
            if (item.itemName == "AR1C1_CorrectRed")
            {
                Putnum = 4;
            }
            if (item.itemName == "AR1C1_Wrong1")
            {
                Putnum = 5;
            }
            if (item.itemName == "AR1C1_Wrong2")
            {
                Putnum = 6;
            }
            if (item.itemName == "AR1C1_Wrong3")
            {
                Putnum = 7;
            }
            if (item.itemName == "AR1C1_Wrong4")
            {
                Putnum = 8;
            }
            if (item.itemName == "AR1C1_Wrong5")
            {
                Putnum = 9;
            }
            if (item.itemName == "AR1C1_Wrong6")
            {
                Putnum = 10;
            }
        }
    }

    void ItemExplanation()
    {
        Q2Block.SetActive(false);

        if (item.itemName == "AR1C1_KEY")
        {
            TitleText.text = "������ ����";
            ExText.text = "������ å�󿡼� �߰��� ����.\n� ���� �� �� �ִ� �ɱ�?";
            ExBtn.SetActive(false);
        }

        if (item.itemName == "AR1C1_PAPERS")
        {
            TitleText.text = "������ ����";
            ExText.text = "�˽��޽� ���������� �����ִ� ����.\n�̷� ������ �繫�ǿ� �ִٴ�, �����ϴ�.";
            ExBtnText.text = "���� ����";
            ExBtn.SetActive(true);
        }

        if (item.itemName == "AR1C1_CorrectBlue")
        {
            TitleText.text = "Ǫ�� å";
            ExText.text = "�Ķ����� ������ �̷� ���ϱ�?\n��޽����� ������ Ǫ�� å.";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "å �ȱ�";
            }
        }

        if (item.itemName == "AR1C1_CorrectGreen")
        {
            TitleText.text = "�ʷ� å";
            ExText.text = "�̷��� £�� �ʷϺ��̶��.\n������ £�� �� ���� å";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "å �ȱ�";
            }
        }

        if (item.itemName == "AR1C1_CorrectPurple")
        {
            TitleText.text = "���� å";
            ExText.text = "����ó�� £�� ����� å.\n���� ������ å�ϱ�?";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "å �ȱ�";
            }
        }

        if (item.itemName == "AR1C1_CorrectRed")
        {
            TitleText.text = "���� å";
            ExText.text = "£�� �������� å.\nǫ �;� ���� ������ �޵ΰ���.";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "å �ȱ�";
            }
        }

        for (int i = 1; i < 7; i++)
        {
            if (item.itemName == "AR1C1_Wrong"+i)
            {
                TitleText.text = "����� å";
                ExText.text = "���� ����� å.\n������ ����� �� �� �ִ�.";
                ExBtn.SetActive(false);

                if (Block0.activeSelf == true)
                {
                    ExBtn.SetActive(true);
                    ExBtnText.text = "å �ȱ�";
                }
            }
        }

        if (item.itemName == "CONFIDENTIAL")
        {
            TitleText.text = "�������� ��������";
            ExText.text = "���纻�� �ƴϰ� �����̴�.\n���̶� ���޴� �Ҹ��� �鸮�� ���...";
            ExBtnText.text = "���� ����";
            ExBtn.SetActive(true);
        }

        if (item.itemName == "MysteriousPaper")
        {
            TitleText.text = "�۾��� ��Ÿ�� ����";
            ExText.text = "��н����� ������ �����ִ� ����.\n�� �� ������ ���� �������� �ñ��ϴ�.";
            ExBtnText.text = "���� ����";
            ExBtn.SetActive(true);
        }
    }

    public void ClickExBtn()
    {
        Q2Block.SetActive(true);

        if (item.itemName == "AR1C1_PAPERS")
        {
            Quiz2Content.SetActive(true);

            TopText.text = "Quiz 2.";
            BottomText.text = "������ ������ �ص��϶�!";
        }

        if (item.itemName == "MysteriousPaper")
        {
            Q3Paper.SetActive(true);
        }

        if(item.itemName == "CONFIDENTIAL")
        {
            Q4Paper.SetActive(true);
        }

        Inventory.SetActive(false);
        Black.SetActive(false);
    }

    public void CloseBlack()
    {
        Q2Block.SetActive(true);
        Black.SetActive(false);
    }
}