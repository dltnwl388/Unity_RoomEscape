using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1C2_MoveManager : MonoBehaviour
{
    public GameObject Street1;
    public GameObject Street2;
    public GameObject Info;
    public GameObject EmptyHouse;
    public GameObject Hideout;

    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;
    public GameObject Q4;
    public GameObject Q5;

    public GameObject Q1NoticeBox;
    public GameObject Q1Houses;

    public GameObject TextBox;
    public GameObject Choicebox;
    public GameObject ChoiceOneBtn;
    public GameObject ClickBtnBox;
    public GameObject ClickOneBtn;
    public GameObject QuizBox;
    public GameObject Q_Medium;
    public GameObject PopupBox;
    public GameObject PopupTwoBtn;

    public EventTrigger PT_Choose1;

    public Text MainText;

    public Text TopText;
    public Text BottomText;

    public EventTrigger Q1_Notice;
    public EventTrigger Q1_134A;

    public GameObject Q2_ARSeated;
    public GameObject Q2_ARSeated_Shadow;
    public GameObject Q2_Iipstic;
    public GameObject EmptyHouseCheck;

    public GameObject Q2_Main;
    public GameObject Q2_Woman;
    public GameObject Q2_Man;
    public GameObject Q2_Choice;

    public EventTrigger Q2W;
    public EventTrigger Q2M;
    public GameObject Q2FObj;
    public GameObject Q2Obj;
    public EventTrigger Q2Btn;
    public EventTrigger Q2ChoiceBtn;

    public GameObject ARSkill2;
    public EventTrigger ARSkill2Btn;
    public GameObject ARSkill3;
    public EventTrigger ARSkill3Btn;
    public GameObject ARSkill3Shot;

    public GameObject Q3Main;

    public EventTrigger Q4Block1;
    public EventTrigger Q4Block2;
    public EventTrigger Q4Block3;

    public GameObject Q4Maze;

    public EventTrigger Q5Btn1;
    public EventTrigger Q5Btn2;
    public EventTrigger Q5Btn3;
    public EventTrigger Q5Btn4;

    public GameObject FiveVersions;
    public GameObject Progress_0;
    public GameObject Progress_1;
    public GameObject Progress_2;
    public GameObject Progress_3;
    public GameObject Progress_4;

    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;
    private EventTrigger.Entry entry3;
    private EventTrigger.Entry entry4;
    private EventTrigger.Entry entry5;
    private EventTrigger.Entry entry6;

    public static int Progress = 0;

    int Q2num1 = 0;
    int Q2num2 = 0;

    int Q5num1 = 0;
    int Q5num2 = 0;
    int Q5num3 = 0;
    int Q5num4 = 0;

    AR1_DialogueManager TheDM;
    public static AR1C2_MoveManager instance;

    private void Start()
    {
        entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerClick;
        entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerClick;
        entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.PointerClick;
        entry4 = new EventTrigger.Entry();
        entry4.eventID = EventTriggerType.PointerClick;
        entry5 = new EventTrigger.Entry();
        entry5.eventID = EventTriggerType.PointerClick;
        entry6 = new EventTrigger.Entry();
        entry6.eventID = EventTriggerType.PointerClick;

        TheDM = FindObjectOfType<AR1_DialogueManager>();

        MainText.text = "핌브리아 거리의 뒷골목";

        TopText.text = "";
        BottomText.text = "";
    }

    void OnEnable()
    {
        instance = this;

        Street1.SetActive(false);
        Street2.SetActive(false);
        Info.SetActive(false);
        EmptyHouse.SetActive(false);
        Hideout.SetActive(false);

        Q1.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);
    }

    public void Update()
    {
        if (Progress == 0)
        {
            Progress_1.SetActive(false);
            Progress_2.SetActive(false);
            Progress_3.SetActive(false);
            Progress_4.SetActive(false);

            Progress_0.SetActive(true);
        }
        else if (Progress == 1)
        {
            Progress_0.SetActive(false);

            Progress_1.SetActive(true);
        }
        else if (Progress == 2)
        {
            Progress_1.SetActive(false);

            Progress_2.SetActive(true);
        }
        else if (Progress == 3)
        {
            Progress_2.SetActive(false);

            Progress_3.SetActive(true);
        }
        else if (Progress == 4)
        {
            Progress_3.SetActive(false);

            Progress_4.SetActive(true);
        }
    }

    public void AR1C2_StreetClick()
    {
        Street1.SetActive(false);
        Info.SetActive(true);

        TextBox.SetActive(true);
        Choicebox.SetActive(false);
        ChoiceOneBtn.SetActive(false);

        MainText.text = "핌브리아 구역의 정보상";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR1C2_Q1()
    {
        Q1.SetActive(true);

        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);

        MainText.text = "";

        TopText.text = "Quiz 1.";
        BottomText.text = "핌브리아 가의 빈집 찾기";

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(EmptyHouseClick);
        Q1_134A.triggers.Remove(entry1);
        Q1_134A.triggers.Add(entry1);
    }

    public void Q1Fail()
    {
        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);
    }

    public void Q1NextNotice2()
    {
        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Text1);
        Q1_Notice.triggers.Remove(entry2);
        Q1_Notice.triggers.Add(entry2);
    }

    void Text1(BaseEventData p)
    {
        AR1C2_Q1NoticeClick();

        GameObject.Find("AR1C2_Quiz1").GetComponent<AR1_InteractionController>().Text();
    }

    public void AR1C2_Q1NoticeClick()
    {
        TextBox.SetActive(true);
        Q1NoticeBox.SetActive(false);

        Q1Houses.SetActive(false);

        Invoke("Q1HousesTure", 0.8f);
    }

    public void Q1HousesTure()
    {
        Q1Houses.SetActive(true);
    }

    public void EmptyHouseClick(BaseEventData p)
    {
        Progress = 1;

        Info.SetActive(false);
        Q1.SetActive(false);

        Street2.SetActive(true);
        EmptyHouse.SetActive(true);

        MainText.text = "핌브리아 9번지의 빈 집";

        TopText.text = "";
        BottomText.text = "";

        AR1_DialogueManager.Checknum = 0;
    }

    public void AR1C2_state(bool a, bool b)
    {
        if (a == true && b == false)
        {
            Q2_ARSeated.SetActive(true);
            Q2_ARSeated_Shadow.SetActive(false);
        }
        else if (a == false && b == true)
        {
            Q2_ARSeated.SetActive(false);
            Q2_ARSeated_Shadow.SetActive(true);
        }
    }

    public void AR1C2_Lipstic_state(bool a)
    {
        if (a == true)
        {
            Q2_Iipstic.SetActive(true);
        }
        else if (a == false)
        {
            Q2_Iipstic.SetActive(false);
        }
    }

    public void AR1C2_Q2()
    {
        Q2.SetActive(true);
        Q2_Man.SetActive(false);
        Q2_Woman.SetActive(false);

        Q2_Main.SetActive(true);
        Q2_Choice.SetActive(false);

        EmptyHouseCheck.SetActive(false);

        QuizBox.SetActive(true);
        Q_Medium.SetActive(true);

        Q2_ARSeated.SetActive(false);
        Q2_ARSeated_Shadow.SetActive(false);

        MainText.text = "";

        TopText.text = "Quiz 2.";
        BottomText.text = "진범 추리하기";

        entry3.callback.RemoveAllListeners();
        entry3.callback.AddListener(Q2Man);
        Q2M.triggers.Remove(entry3);
        Q2M.triggers.Add(entry3);

        entry4.callback.RemoveAllListeners();
        entry4.callback.AddListener(Q2Woman);
        Q2W.triggers.Remove(entry4);
        Q2W.triggers.Add(entry4);

        AR1_DialogueManager.Checknum = 0;

        if (Q2num1 >= 1 && Q2num2 >= 1)
        {
            Q2Obj.SetActive(true);
            Q2FObj.SetActive(false);

            entry5.callback.RemoveAllListeners();
            entry5.callback.AddListener(Q2NextBtn);
            Q2Btn.triggers.Remove(entry5);
            Q2Btn.triggers.Add(entry5);
        }
        else
        {
            Q2FObj.SetActive(true);
            Q2Obj.SetActive(false);

        }
    }

    public void Q2Woman(BaseEventData p)
    {
        Q2_Man.SetActive(false);
        Q2_Woman.SetActive(true);

        AR1C2_state(true, false);

        Q2num1 += 1;
    }

    public void Q2Man(BaseEventData p)
    {
        Q2_Man.SetActive(true);
        Q2_Woman.SetActive(false);

        AR1C2_state(true, false);

        Q2num2 += 1;
    }

    public void Q2NextBtn(BaseEventData p)
    {
        Q2_Main.SetActive(false);
        Q2_Choice.SetActive(true);

        QuizBox.SetActive(false);
        Q_Medium.SetActive(false);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Q2_ChoiceBtn);
        Q2ChoiceBtn.triggers.Remove(entry1);
        Q2ChoiceBtn.triggers.Add(entry1);
    }

    public void Q2_ChoiceBtn(BaseEventData p)
    {
        if (AR1C2_Q2A.AR1C2_Q2ACheck == true && AR1C2_Q2B.AR1C2_Q2BCheck == false)
        {
            Q2_Choice.SetActive(false);

            GameObject.Find("Q2Choice").GetComponent<AR1_InteractionController>().Text();
        }
        else if (AR1C2_Q2A.AR1C2_Q2ACheck == false && AR1C2_Q2B.AR1C2_Q2BCheck == true)
        {
            Progress = 2;

            Q2_Choice.SetActive(false);
            EmptyHouse.SetActive(false);

            MainText.text = "핌브리아 9번지의 뒷골목";

            TopText.text = "";
            BottomText.text = "";

            GameObject.Find("AR1C2_Quiz2").GetComponent<AR1_InteractionController>().Text();
        }
    }

    public void AR1C2_ARSkill2_Add()
    {
        Q2.SetActive(false);
        ARSkill2.SetActive(true);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Text2);
        ARSkill2Btn.triggers.Remove(entry2);
        ARSkill2Btn.triggers.Add(entry2);
    }

    void Text2(BaseEventData p)
    {
        ARSkill2_End();

        GameObject.Find("AR1C2_Skill2").GetComponent<AR1_InteractionController>().Text();
    }

    public void ARSkill2_End()
    {
        ARSkill2.SetActive(false);
    }

    public void AR1C2_Q3()
    {
        Q3.SetActive(true);
        Q3Main.SetActive(true);

        MainText.text = "";

        TopText.text = "Quiz 3.";
        BottomText.text = "증인과 함께 빠져나오기";

        GameObject.Find("AR1C2_Maze").GetComponent<AR1_InteractionController>().Text();
    }

    public void Q3Success()
    {
        Progress = 3;

        Q3.SetActive(false);

        MainText.text = "핌브리아 9번지의 뒷골목";

        TopText.text = "";
        BottomText.text = "";

        GameObject.Find("AR1C2_Street2").GetComponent<AR1_InteractionController>().Text();
    }

    public void AR1C2_ARSkill3_Add()
    {
        ARSkill3.SetActive(true);


        entry3.callback.RemoveAllListeners();
        entry3.callback.AddListener(Text3);
        ARSkill3Btn.triggers.Remove(entry3);
        ARSkill3Btn.triggers.Add(entry3);
    }

    void Text3(BaseEventData p)
    {
        ARSkill3_End();

        GameObject.Find("AR1C2_Skill3").GetComponent<AR1_InteractionController>().Text();
    }

    public void ARSkill3_End()
    {
        ARSkill3.SetActive(false);
    }

    public void AR1C2_ARSkill_Shot()
    {
        ARSkill3Shot.SetActive(true);
    }

    public void AR1C2_Q4()
    {
        ARSkill3Shot.SetActive(false);
        Q4.SetActive(true);

        Q4Maze.SetActive(true);

        MainText.text = "";

        TopText.text = "Quiz 4.";
        BottomText.text = "길 봉쇄하기";

        GameObject.Find("AR1C2_Q4Maze").GetComponent<AR1_InteractionController>().Text();

        entry4.callback.RemoveAllListeners();
        entry4.callback.AddListener(Q4fail);
        Q4Block1.triggers.Remove(entry4);
        Q4Block1.triggers.Add(entry4);

        entry5.callback.RemoveAllListeners();
        entry5.callback.AddListener(Q4Success);
        Q4Block2.triggers.Remove(entry5);
        Q4Block2.triggers.Add(entry5);

        Q4Block3.triggers.Remove(entry4);
        Q4Block3.triggers.Add(entry4);
    }

    public void Q4fail(BaseEventData p)
    {
        AR1C2_ARSkill_Shot();

        Q4Maze.SetActive(false);

        MainText.text = "핌브리아 9번지의 뒷골목";

        TopText.text = "";
        BottomText.text = "";
    }

    public void Q4Success(BaseEventData p)
    {
        Progress = 4;

        Q4.SetActive(false);

        MainText.text = "핌브리아 9번지의 뒷골목";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR1C2_Q5()
    {
        Q5.SetActive(true);

        QuizBox.SetActive(true);
        Q_Medium.SetActive(true);

        MainText.text = "";

        TopText.text = "Quiz 5.";
        BottomText.text = "진짜 문 고르기";

        Q5num1 = 0;
        Q5num2 = 0;
        Q5num3 = 0;
        Q5num4 = 0;

        entry6.callback.RemoveAllListeners();
        entry6.callback.AddListener(Blue);
        Q5Btn1.triggers.Remove(entry6);
        Q5Btn1.triggers.Add(entry6);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Red);
        Q5Btn2.triggers.Remove(entry1);
        Q5Btn2.triggers.Add(entry1);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Green);
        Q5Btn3.triggers.Remove(entry2);
        Q5Btn3.triggers.Add(entry2);

        entry3.callback.RemoveAllListeners();
        entry3.callback.AddListener(Yellow);
        Q5Btn4.triggers.Remove(entry3);
        Q5Btn4.triggers.Add(entry3);
    }

    public void Blue(BaseEventData p)
    {
        QuizBox.SetActive(false);
        Q_Medium.SetActive(false);

        String Text = "정말로 '파란 문'을 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num1 = 1;
    }

    public void Red(BaseEventData p)
    {
        QuizBox.SetActive(false);
        Q_Medium.SetActive(false);

        String Text = "정말로 '빨간 문'을 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num2 = 1;
    }

    public void Green(BaseEventData p)
    {
        QuizBox.SetActive(false);
        Q_Medium.SetActive(false);

        String Text = "정말로 '초록 문'을 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num3 = 1;
    }

    public void Yellow(BaseEventData p)
    {
        QuizBox.SetActive(false);
        Q_Medium.SetActive(false);

        String Text = "정말로 '노란 문'을 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num4 = 1;
    }

    public void AR1C2_Q5Result()
    {
        if (Q5num1 == 1 || Q5num3 == 1 || Q5num4 == 1)
        {
            PopupBox.SetActive(false);
            PopupTwoBtn.SetActive(false);

            GameObject.Find("AR1C2_Quiz5").GetComponent<AR1_InteractionController>().Text();
        }
        else if (Q5num2 == 1)
        {
            PopupBox.SetActive(false);
            PopupTwoBtn.SetActive(false);

            Q5Success();
        }
    }

    public void Q5Success()
    {
        Q5.SetActive(false);
        Hideout.SetActive(true);

        MainText.text = "증인의 아지트";

        TopText.text = "";
        BottomText.text = "";

        GameObject.Find("AR1C2_Hideout").GetComponent<AR1_InteractionController>().Text();
    }
}