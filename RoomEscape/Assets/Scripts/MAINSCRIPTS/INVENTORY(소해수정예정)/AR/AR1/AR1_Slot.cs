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
            TitleText.text = "교수의 열쇠";
            ExText.text = "교수의 책상에서 발견한 열쇠.\n어떤 문을 열 수 있는 걸까?";
            ExBtn.SetActive(false);
        }

        if (item.itemName == "AR1C1_PAPERS")
        {
            TitleText.text = "수상한 서류";
            ExText.text = "알쏭달쏭 수수께끼가 적혀있는 서류.\n이런 서류가 사무실에 있다니, 수상하다.";
            ExBtnText.text = "서류 보기";
            ExBtn.SetActive(true);
        }

        if (item.itemName == "AR1C1_CorrectBlue")
        {
            TitleText.text = "푸른 책";
            ExText.text = "파랑새의 깃털이 이런 색일까?\n고급스러운 느낌의 푸른 책.";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "책 꽂기";
            }
        }

        if (item.itemName == "AR1C1_CorrectGreen")
        {
            TitleText.text = "초록 책";
            ExText.text = "이렇게 짙은 초록빛이라니.\n녹음이 짙게 깔린 듯한 책";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "책 꽂기";
            }
        }

        if (item.itemName == "AR1C1_CorrectPurple")
        {
            TitleText.text = "보라 책";
            ExText.text = "와인처럼 짙은 보라색 책.\n무슨 내용의 책일까?";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "책 꽂기";
            }
        }

        if (item.itemName == "AR1C1_CorrectRed")
        {
            TitleText.text = "붉은 책";
            ExText.text = "짙은 붉은빛의 책.\n푹 익어 가장 달콤한 앵두같다.";
            ExBtn.SetActive(false);

            if (Block0.activeSelf == true)
            {
                ExBtn.SetActive(true);
                ExBtnText.text = "책 꽂기";
            }
        }

        for (int i = 1; i < 7; i++)
        {
            if (item.itemName == "AR1C1_Wrong"+i)
            {
                TitleText.text = "평범한 책";
                ExText.text = "아주 평범한 책.\n던지면 무기로 쓸 수 있다.";
                ExBtn.SetActive(false);

                if (Block0.activeSelf == true)
                {
                    ExBtn.SetActive(true);
                    ExBtnText.text = "책 꽂기";
                }
            }
        }

        if (item.itemName == "CONFIDENTIAL")
        {
            TitleText.text = "빼돌려진 수사일지";
            ExText.text = "복사본도 아니고 원본이다.\n아이란 열받는 소리가 들리는 기분...";
            ExBtnText.text = "서류 보기";
            ExBtn.SetActive(true);
        }

        if (item.itemName == "MysteriousPaper")
        {
            TitleText.text = "글씨가 나타난 종이";
            ExText.text = "비밀스러운 편지가 적혀있는 종이.\n왜 이 편지를 읽지 못했을지 궁금하다.";
            ExBtnText.text = "종이 보기";
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
            BottomText.text = "수상한 서류를 해독하라!";
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