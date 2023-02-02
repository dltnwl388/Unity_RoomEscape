using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1C1_MoveManager : MonoBehaviour
{
    public GameObject ClickBtnBox;
    public GameObject ClickOneBtn;

    public Text MainText;

    public Text TopText;
    public Text BottomText;

    public GameObject Office;

    public GameObject BookCase1;
    public GameObject BookCase2;
    public GameObject BookCase3;

    public GameObject Popup;
    public EventTrigger PopupBtn;

    public GameObject Back;
    public EventTrigger BackBtn;

    public GameObject EmptyCase1;
    public EventTrigger EmptyCase1Btn;
    public EventTrigger EmptyCase1Click;
    public GameObject EmptyCase2;
    public EventTrigger EmptyCase2Btn;
    public GameObject EmptyCase2Click;

    public GameObject ColorCase1;
    public EventTrigger ColorCase1Btn;
    public EventTrigger ColorCase1Click;
    public GameObject ColorCase2;
    public EventTrigger ColorCase2Btn;
    public GameObject ColorCase2Click;
    public EventTrigger ColorCase2ClickBtn;

    public GameObject E1Case1;
    public EventTrigger E1Case1Btn;
    public GameObject E1Case2;
    public EventTrigger E1Case2Btn;

    public GameObject C1Case1;
    public EventTrigger C1Case1Btn;
    public GameObject C1Case2;
    public EventTrigger C1Case2Btn;

    public GameObject DeskCase1;
    public EventTrigger DeskCase1Btn;
    public GameObject DeskCase1Click;
    public EventTrigger DeskCase1ClickBtn;
    public GameObject DeskCase2;
    public EventTrigger DeskCase2Btn;

    public GameObject Quiz;
    public GameObject BlackBg;
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q4;
    public GameObject Q5;

    public GameObject BaseDesk;
    public GameObject KeyDesk;
    public GameObject KeyBtn;
    public GameObject PaperDesk;
    public GameObject PaperBtn;
    public GameObject BothDesk;
    public GameObject Down;

    public GameObject Q2BookCase;
    public GameObject CancelBtn;
    public GameObject FPutObj;
    public EventTrigger FPutBtn;
    public EventTrigger CPutBtn;
    public GameObject CorrectBookCase;
    public EventTrigger Q2SuccessBtn;

    public GameObject PaperIntend1_0;
    public GameObject PaperIntend1_1;
    public GameObject PaperIntend2_0;
    public GameObject PaperIntend2_1;

    public GameObject SecretRoom;

    public GameObject Map;
    public GameObject Calendar;
    public GameObject Q3Paper;
    public GameObject Confidential;

    public GameObject CalendarText;
    public EventTrigger CalendarTextBtn;
    public GameObject CalendarBtn;
    public GameObject CalendarObj;

    public GameObject Q3PaperObj;
    public GameObject Q3PaperDesk;
    public EventTrigger Q3PaperBtn;
    public GameObject Fire;
    public GameObject Skill;
    public GameObject SkillUsedPaper;
    public Text Paper_text;
    public GameObject OpenBtn;
    public GameObject FindBtn;

    public GameObject Confidential1;
    public GameObject Confidential2;
    public GameObject Confidential3;

    public GameObject Q3Item1;
    public GameObject Q3Item2;

    public GameObject Q4_Interview;
    public GameObject Apple;
    public GameObject Banana;
    public GameObject Cream;
    public GameObject Doughnut;

    public GameObject MapTextBtn;
    public GameObject MapBtn;
    public GameObject MapText1;
    public GameObject MapText2;
    public GameObject MapText3;

    public GameObject FiveVersions;
    public GameObject Progress_0;
    public GameObject Progress_1;
    public GameObject Progress_2;
    public GameObject Progress_3;
    public GameObject Progress_4;

    public static int Progress = 0;
    public static bool ItemState = false;
    bool BackState = false;

    bool AR1C1_Q1Key = false;
    bool AR1C1_Q1Paper = false;
    bool Q1Check = false;
    bool Q1BagOpen = false;

    bool Q2Intro = false;
    bool Q2PutBook = false;

    bool Q3Check1 = false;
    bool Q3Check2 = false;

    bool Q4Check = false;

    int Q5num1 = 0;
    int Q5num2 = 0;
    int Q5num3 = 0;
    int Q5num4 = 0;

    AR1_DialogueManager TheDM;

    public static AR1C1_MoveManager instance;

    private EventTrigger.Entry entry_BackBtn;

    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;
    private EventTrigger.Entry entry3;
    private EventTrigger.Entry entry4;
    private EventTrigger.Entry entry5;

    private EventTrigger.Entry entry6;
    private EventTrigger.Entry entry7;
    private EventTrigger.Entry entry8;
    private EventTrigger.Entry entry9;
    private EventTrigger.Entry entry10;

    private EventTrigger.Entry entry11;
    private EventTrigger.Entry entry12;
    private EventTrigger.Entry entry13;
    private EventTrigger.Entry entry14;
    private EventTrigger.Entry entry15;
    private EventTrigger.Entry entry16;
    private EventTrigger.Entry entry17;
    private EventTrigger.Entry entry18;

    private void Start()
    {
        entry_BackBtn = new EventTrigger.Entry();
        entry_BackBtn.eventID = EventTriggerType.PointerClick;

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
        entry7 = new EventTrigger.Entry();
        entry7.eventID = EventTriggerType.PointerClick;
        entry8 = new EventTrigger.Entry();
        entry8.eventID = EventTriggerType.PointerClick;
        entry9 = new EventTrigger.Entry();
        entry9.eventID = EventTriggerType.PointerClick;
        entry10= new EventTrigger.Entry();
        entry10.eventID = EventTriggerType.PointerClick;

        entry11 = new EventTrigger.Entry();
        entry11.eventID = EventTriggerType.PointerClick;
        entry12 = new EventTrigger.Entry();
        entry12.eventID = EventTriggerType.PointerClick;
        entry13 = new EventTrigger.Entry();
        entry13.eventID = EventTriggerType.PointerClick;
        entry14 = new EventTrigger.Entry();
        entry14.eventID = EventTriggerType.PointerClick;
        entry15 = new EventTrigger.Entry();
        entry15.eventID = EventTriggerType.PointerClick;
        entry16 = new EventTrigger.Entry();
        entry16.eventID = EventTriggerType.PointerClick;
        entry17 = new EventTrigger.Entry();
        entry17.eventID = EventTriggerType.PointerClick;
        entry18 = new EventTrigger.Entry();
        entry18.eventID = EventTriggerType.PointerClick;

        instance = this;

        TheDM = FindObjectOfType<AR1_DialogueManager>();

        BookCase2.SetActive(false);
        EmptyCase1.SetActive(false);
        ColorCase1.SetActive(false);
        E1Case1.SetActive(false);
        C1Case1.SetActive(false);
        DeskCase1.SetActive(false);

        BookCase3.SetActive(false);
        EmptyCase2.SetActive(false);
        ColorCase2.SetActive(false);
        E1Case2.SetActive(false);
        C1Case2.SetActive(false);
        DeskCase2.SetActive(false);

        Quiz.SetActive(false);
        Q1.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);

        FiveVersions.SetActive(true);

        SecretRoom.SetActive(false);
        Map.SetActive(false);
        Calendar.SetActive(false);
        Q3Paper.SetActive(false);
        Confidential.SetActive(false);

        entry1.callback.AddListener(NextEmptyCase1);
        EmptyCase1Btn.triggers.Add(entry1);

        entry2.callback.AddListener(NextColorCase1);
        ColorCase1Btn.triggers.Add(entry2);

        entry3.callback.AddListener(NextE1Case1);
        E1Case1Btn.triggers.Add(entry3);

        entry4.callback.AddListener(NextC1Case1);
        C1Case1Btn.triggers.Add(entry4);

        entry5.callback.AddListener(NextDeskCase1);
        DeskCase1Btn.triggers.Add(entry5);

        entry6.callback.AddListener(NextEmptyCase2);
        EmptyCase2Btn.triggers.Add(entry6);

        entry7.callback.AddListener(NextColorCase2);
        ColorCase2Btn.triggers.Add(entry7);

        entry8.callback.AddListener(NextE1Case2);
        E1Case2Btn.triggers.Add(entry8);

        entry9.callback.AddListener(NextC1Case2);
        C1Case2Btn.triggers.Add(entry9);

        entry10.callback.AddListener(NextDeskCase2);
        DeskCase2Btn.triggers.Add(entry10);

        MainText.text = "존스티나 학교, 교수의 사무실";

        TopText.text = "";
        BottomText.text = "";
    }

    void Update()
    {
        if (BackState == true)
        {
            Back.SetActive(true);

            if (BookCase2.activeSelf == true)
            {
                BookCase1BackBtn();
            }
            else if (BookCase3.activeSelf == true)
            {
                BookCase2BackBtn();
            }
            else if (SecretRoom.activeSelf == true)
            {
                SecretroomBackBtn();
            }
        }
        else
        {
            Back.SetActive(false);
        }

        if (Progress == 0)
        {
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

    public void AR1C1_BackBtnAT()
    {
        if (BookCase2.activeSelf == true) 
        {
            BookCase1BackBtn();
        }
        else if (BookCase3.activeSelf == true)
        {
            BookCase2BackBtn();
        }
        else if (SecretRoom.activeSelf == true)
        {
            SecretroomBackBtn();
        }
    }

    public void AR1C1_BackBtnAF()
    {
        entry_BackBtn.callback.RemoveAllListeners();
        BackBtn.triggers.Remove(entry_BackBtn);
    }

    public void AR1C1_BackBtnMGT()
    {
        BackState = true;
    }

    public void BackBtnMGF()
    {
        BackState = false;
    }

    public void BackBtnMGF_Trigger(BaseEventData p)
    {
        BackState = false;
    }

    void BookCase1BackBtn()
    {
        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(Back1Btn);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    void BookCase2BackBtn()
    {
        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(Back2Btn);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);

        if (Q2PutBook == true)
        {
            entry_BackBtn.callback.RemoveAllListeners();
            entry_BackBtn.callback.AddListener(Back2Btn);
            BackBtn.triggers.Remove(entry_BackBtn);
            BackBtn.triggers.Add(entry_BackBtn);

            AR1C1_Q2Put.action1();

            Debug.Log("e들어와");
        }
    }

    public void AR1C1_Popup()
    {
        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);

        Popup.SetActive(true);

        entry11.callback.AddListener(PopupClick);
        PopupBtn.triggers.Add(entry11);
    }

    void PopupClick(BaseEventData p)
    {
        BookCase1.SetActive(false);
        BookCase2.SetActive(true);
    }

    void NextEmptyCase1(BaseEventData p)
    {
        BookCase2.SetActive(false);

        EmptyCase1.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase1BackBtn();

        entry11.callback.RemoveAllListeners();
        entry11.callback.AddListener(BackBtnMGF_Trigger);
        EmptyCase1Click.triggers.Remove(entry11);
        EmptyCase1Click.triggers.Add(entry11);
    }

    void NextColorCase1(BaseEventData p)
    {
        BookCase2.SetActive(false);

        ColorCase1.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase1BackBtn();

        entry12.callback.RemoveAllListeners();
        entry12.callback.AddListener(BackBtnMGF_Trigger);
        ColorCase1Click.triggers.Remove(entry12);
        ColorCase1Click.triggers.Add(entry12);
    }

    void NextE1Case1(BaseEventData p)
    {
        BookCase2.SetActive(false);

        E1Case1.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase1BackBtn();
    }

    void NextC1Case1(BaseEventData p)
    {
        BookCase2.SetActive(false);

        C1Case1.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase1BackBtn();
    }

    void NextDeskCase1(BaseEventData p)
    {
        BookCase2.SetActive(false);

        DeskCase1.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase1BackBtn();

        entry13.callback.RemoveAllListeners();
        entry13.callback.AddListener(BackBtnMGF_Trigger);
        DeskCase1ClickBtn.triggers.Remove(entry13);
        DeskCase1ClickBtn.triggers.Add(entry13);
    }

    public void EmptyCase1RBtn()
    {
        EmptyCase1.SetActive(false);

        ColorCase1.SetActive(true);

        entry14.callback.RemoveAllListeners();
        entry14.callback.AddListener(BackBtnMGF_Trigger);
        ColorCase1Click.triggers.Remove(entry14);
        ColorCase1Click.triggers.Add(entry14);
    }

    public void EmptyCase1LBtn()
    {
        EmptyCase1.SetActive(false);

        E1Case1.SetActive(true);
    }

    public void ColorCase1RBtn()
    {
        ColorCase1.SetActive(false);

        C1Case1.SetActive(true);
    }

    public void ColorCase1LBtn()
    {
        ColorCase1.SetActive(false);

        EmptyCase1.SetActive(true);

        entry15.callback.RemoveAllListeners();
        entry15.callback.AddListener(BackBtnMGF_Trigger);
        EmptyCase1Click.triggers.Remove(entry15);
        EmptyCase1Click.triggers.Add(entry15);
    }

    public void Other1RBtn()
    {
        E1Case1.SetActive(false);

        EmptyCase1.SetActive(true);

        entry16.callback.RemoveAllListeners();
        entry16.callback.AddListener(BackBtnMGF_Trigger);
        EmptyCase1Click.triggers.Remove(entry16);
        EmptyCase1Click.triggers.Add(entry16);
    }

    public void Other1LBtn()
    {
        C1Case1.SetActive(false);

        ColorCase1.SetActive(true);

        entry17.callback.RemoveAllListeners();
        entry17.callback.AddListener(BackBtnMGF_Trigger);
        ColorCase1Click.triggers.Remove(entry17);
        ColorCase1Click.triggers.Add(entry17);
    }

    void Back1Btn(BaseEventData p)
    {
        EmptyCase1.SetActive(false);
        ColorCase1.SetActive(false);
        E1Case1.SetActive(false);
        C1Case1.SetActive(false);
        DeskCase1.SetActive(false);

        BookCase2.SetActive(true);

        BackBtnMGF();
    }

    public void AR1C1_Q1()
    {
        DeskCase1Click.SetActive(false);

        Quiz.SetActive(true);
        Q1.SetActive(true);

        MainText.text = "";

        TopText.text = "Quiz 1.";
        BottomText.text = "책상 위에서 물건 찾기";
    }

    public void AR1C1_Q1_Key()
    {
        AR1C1_Q1Key = true;

        if (AR1C1_Q1Paper == false) 
        {
            Q1Check = true;

            BaseDesk.SetActive(false);
            KeyBtn.SetActive(false);

            KeyDesk.SetActive(true);
        }
        else
        {
            PaperDesk.SetActive(false);
            KeyBtn.SetActive(false);

            BothDesk.SetActive(true);
        }
    }

    public void AR1C1_Q1_Paper()
    {
        AR1C1_Q1Paper = true;

        if (AR1C1_Q1Key == false)
        {
            BaseDesk.SetActive(false);
            PaperBtn.SetActive(false);

            PaperDesk.SetActive(true);
        }
        else
        {
            KeyDesk.SetActive(false);
            PaperBtn.SetActive(false);

            BothDesk.SetActive(true);
        }
    }

    public void AR1C1_InventoryUnLock()
    {
        AR1_OpenClose.actionT();

        Down.SetActive(true);
    }

    public void AR1C1_Q1_Check()
    {
        if (AR1C1_Q1Key == true && AR1C1_Q1Paper == true)
        {
            GameObject.Find("AR1C1_Q1Desk").GetComponent<AR1_InteractionController>().Text();
        }
        else
        {
            GameObject.Find("AR1C1_Quiz1").GetComponent<AR1_InteractionController>().Text();
        }
    }

    public void MybagClick()
    {
        DeskCase1.SetActive(false);
        Q1.SetActive(false);
        BlackBg.SetActive(false);

        DeskCase2.SetActive(true);

        if (Q1Check == true)
        {
            PaperIntend2_0.SetActive(true);
        }
        else
        {
            PaperIntend1_0.SetActive(true);
        }
    }

    public void MybagOk()
    {
        if (Q1BagOpen == false)
        {
            Q1BagOpen = true;

            if (Q1Check == true)
            {
                Destroy(PaperIntend1_0);
                Destroy(PaperIntend2_0);

                PaperIntend2_1.SetActive(true);
            }
            else
            {
                Destroy(PaperIntend1_0);
                Destroy(PaperIntend2_0);

                PaperIntend1_1.SetActive(true);
            }
        }
    }

    public void MybagClose()
    {
        Progress = 1;

        Destroy(PaperIntend1_1);
        Destroy(PaperIntend2_1);
    }

    public void ContentClose()
    {
        Q2.SetActive(false);

        if (Q2Intro == false)
        {
            Q2Intro = true;

            GameObject.Find("AR1C1_Quiz2").GetComponent<AR1_InteractionController>().Text();
        }

        BookCase2BackBtn();

        MainText.text = "존스티나 학교, 교수의 사무실";

        TopText.text = "";
        BottomText.text = "";
    }

    void NextEmptyCase2(BaseEventData p)
    {
        BookCase3.SetActive(false);

        EmptyCase2.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase2BackBtn();
    }

    void NextColorCase2(BaseEventData p)
    {
        BookCase3.SetActive(false);

        ColorCase2.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase2BackBtn();

        entry11.callback.RemoveAllListeners();
        entry11.callback.AddListener(BackBtnMGF_Trigger);
        ColorCase2ClickBtn.triggers.Remove(entry11);
        ColorCase2ClickBtn.triggers.Add(entry11);
    }

    void NextE1Case2(BaseEventData p)
    {
        BookCase3.SetActive(false);

        E1Case2.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase2BackBtn();
    }

    void NextC1Case2(BaseEventData p)
    {
        BookCase3.SetActive(false);

        C1Case2.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase2BackBtn();
    }

    void NextDeskCase2(BaseEventData p)
    {
        BookCase3.SetActive(false);

        DeskCase2.SetActive(true);

        AR1C1_BackBtnMGT();
        BookCase2BackBtn();
    }

    public void EmptyCase2RBtn()
    {
        EmptyCase2.SetActive(false);

        ColorCase2.SetActive(true);

        entry12.callback.RemoveAllListeners();
        entry12.callback.AddListener(BackBtnMGF_Trigger);
        ColorCase2ClickBtn.triggers.Remove(entry12);
        ColorCase2ClickBtn.triggers.Add(entry12);
    }

    public void EmptyCase2LBtn()
    {
        EmptyCase2.SetActive(false);

        E1Case2.SetActive(true);
    }

    public void ColorCase2RBtn()
    {
        ColorCase2.SetActive(false);

        C1Case2.SetActive(true);
    }

    public void ColorCase2LBtn()
    {
        ColorCase2.SetActive(false);

        EmptyCase2.SetActive(true);
    }

    public void Other2RBtn()
    {
        E1Case2.SetActive(false);

        EmptyCase2.SetActive(true);
    }

    public void Other2LBtn()
    {
        C1Case2.SetActive(false);

        ColorCase2.SetActive(true);

        entry13.callback.RemoveAllListeners();
        entry13.callback.AddListener(BackBtnMGF_Trigger);
        ColorCase2ClickBtn.triggers.Remove(entry13);
        ColorCase2ClickBtn.triggers.Add(entry13);
    }

    void Back2Btn(BaseEventData p)
    {
        EmptyCase2.SetActive(false);
        ColorCase2.SetActive(false);
        E1Case2.SetActive(false);
        C1Case2.SetActive(false);
        DeskCase2.SetActive(false);

        BookCase3.SetActive(true);

        BackBtnMGF();
    }

    public void AR1C1_JustOneText()
    {
        AR1C1_BackBtnMGT();

        ColorCase2Click.SetActive(false);
    }

    public void AR1C1_Q2()
    {
        ItemState = true;

        Q2PutBook = true;

        AR1C1_BackBtnMGT();

        EmptyCase2Click.SetActive(false);

        Q2BookCase.SetActive(true);
        CancelBtn.SetActive(true);
        FPutObj.SetActive(true);

        entry14.callback.RemoveAllListeners();
        entry14.callback.AddListener(Q2Try);

        CPutBtn.triggers.Remove(entry14);
        CPutBtn.triggers.Add(entry14);

        FPutBtn.triggers.Remove(entry14);
        FPutBtn.triggers.Add(entry14);

        MainText.text = "";

        TopText.text = "Quiz 2.";
        BottomText.text = "수상한 서류를 해독하라!";
    }

    void Q2Try(BaseEventData p)
    {
        if (GameObject.Find("Q2Itemcase(1)").transform.GetChild(2).gameObject.activeSelf == true
            && GameObject.Find("Q2Itemcase(2)").transform.GetChild(1).gameObject.activeSelf == true
            && GameObject.Find("Q2Itemcase(3)").transform.GetChild(0).gameObject.activeSelf == true
            && GameObject.Find("Q2Itemcase(4)").transform.GetChild(3).gameObject.activeSelf == true)
        {
            BackBtnMGF();

            EmptyCase2.SetActive(false);

            CorrectBookCase.SetActive(true);

            MainText.text = "존스티나 학교, 교수의 사무실";

            TopText.text = "";
            BottomText.text = "";


            entry15.callback.RemoveAllListeners();
            entry15.callback.AddListener(ToSecretRoom);
            Q2SuccessBtn.triggers.Remove(entry15);
            Q2SuccessBtn.triggers.Add(entry15);
        }
        else
        {
            BackBtnMGF();

            GameObject.Find("AR1C1_Q2main").GetComponent<AR1_InteractionController>().Text();
        }
    }

    void ToSecretRoom(BaseEventData p)
    {
        Progress = 2;

        Office.SetActive(false);
        CorrectBookCase.SetActive(false);

        SecretRoom.SetActive(true);

        MainText.text = "존스티나 학교, 교수의 비밀공간";

        TopText.text = "";
        BottomText.text = "";
    }

    void SecretroomBackBtn()
    {
        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(Back3Btn);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    void Back3Btn(BaseEventData p)
    {
        Map.SetActive(false);
        Calendar.SetActive(false);
        Q3Paper.SetActive(false);
        Confidential.SetActive(false);

        SecretRoom.SetActive(true);

        BackBtnMGF();
    }

    public void ToMap()
    {
        SecretRoom.SetActive(false);

        Map.SetActive(true);

        AR1C1_BackBtnMGT();
        SecretroomBackBtn();
    }

    public void ToCalendar()
    {
        SecretRoom.SetActive(false);

        Calendar.SetActive(true);

        AR1C1_BackBtnMGT();
        SecretroomBackBtn();

        entry11.callback.RemoveAllListeners();
        entry11.callback.AddListener(BackBtnMGF_Trigger);
        entry11.callback.AddListener(Text1);
        entry11.callback.AddListener(CalendarClick);
        CalendarTextBtn.triggers.Remove(entry11);
        CalendarTextBtn.triggers.Add(entry11);
    }

    public void Text1(BaseEventData p)
    {
        GameObject.Find("AR1C1_Calendar").GetComponent<AR1_InteractionController>().Text();
    }

    void CalendarClick(BaseEventData p)
    {
        CalendarText.SetActive(false);

        CalendarBtn.SetActive(true);
    }

    public void AR1C1_Calendar()
    {
        CalendarObj.SetActive(true);

        BackBtnMGF();
    }

    public void CalendarBack()
    {
        CalendarObj.SetActive(false);

        AR1C1_BackBtnMGT();
    }

    public void ToQ3Paper()
    {
        SecretRoom.SetActive(false);

        Q3Paper.SetActive(true);

        AR1C1_BackBtnMGT();
        SecretroomBackBtn();

        entry12.callback.RemoveAllListeners();
        entry12.callback.AddListener(BackBtnMGF_Trigger);
        entry12.callback.AddListener(Text2);
        entry12.callback.AddListener(Q3PaperClick);
        Q3PaperBtn.triggers.Remove(entry12);
        Q3PaperBtn.triggers.Add(entry12);
    }

    public void Text2(BaseEventData p)
    {
        GameObject.Find("AR1C1_Quiz3").GetComponent<AR1_InteractionController>().Text();
    }

    void Q3PaperClick(BaseEventData p)
    {
        Q3PaperObj.SetActive(false);
        Q3PaperDesk.SetActive(false);

        MainText.text = "";

        TopText.text = "Quiz 3.";
        BottomText.text = "비어있는 종이 읽기";
    }

    public void AR1C1_Q3()
    {
        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);

        Skill.SetActive(true);
    }

    public void SkillBtn()
    {
        Skill.SetActive(false);
    }

    public void AR1C1_Paper()
    {
        StartCoroutine(SkillUse());
    }

    IEnumerator SkillUse()
    {
        Q3Check2 = true;

        Fire.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        SkillUsedPaper.SetActive(true);

        if (Q3Check1 == true) 
        {
            Paper_text.text = "수사일지를 확인하세요.";

            OpenBtn.SetActive(true);
        }
        else
        {
            FindBtn.SetActive(true);
        }
    }

    public void Opening()
    {
        SkillUsedPaper.SetActive(false);
        Fire.SetActive(false);

        AR1C1_BackBtnMGT();
        AR1C1_Confidential();
    }

    public void Finding()
    {
        SkillUsedPaper.SetActive(false);
        Fire.SetActive(false);

        AR1C1_BackBtnMGT();

        MainText.text = "존스티나 학교, 교수의 비밀공간";

        TopText.text = "";
        BottomText.text = "";
    }

    public void ToConfidential()
    {
        SecretRoom.SetActive(false);

        Confidential.SetActive(true);

        AR1C1_BackBtnMGT();
        SecretroomBackBtn();
    }

    public void AddConfidential()
    {
        Q3Check1 = true;

        Destroy(Confidential1);
        Destroy(Confidential2);
        Destroy(Confidential3);
    }

    public void CloseItem()
    {
        Q3Item1.SetActive(false);
        Q3Item2.SetActive(false);
    }

    public void AR1C1_Confidential()
    {
        if (Q3Check2 == true)
        {
            Progress = 3;

            BlackBg.SetActive(true);
            Q4.SetActive(true);

            BackBtnMGF();

            GameObject.Find("AR1C1_Quiz4").GetComponent<AR1_InteractionController>().Text();

            MainText.text = "";

            TopText.text = "Quiz 4.";
            BottomText.text = "수상한 인물을 찾아라";
        }
        else
        {
            AR1C1_BackBtnMGT();
        }
    }

    public void AR1C1_Q4()
    {
        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);

        Q4_Interview.SetActive(true);
    }

    public void AR1C1_ToBanana()
    {
        Q4_Interview.SetActive(false);

        Banana.SetActive(true);
    }

    public void AR1C1_ToCream()
    {
        Q4_Interview.SetActive(false);

        Cream.SetActive(true);
    }

    public void AR1C1_ToDoughnut()
    {
        Q4_Interview.SetActive(false);

        Doughnut.SetActive(true);
    }

    public void AR1C1_Q4Fail()
    {
        Banana.SetActive(false);
        Cream.SetActive(false);
        Doughnut.SetActive(false);

        Q4_Interview.SetActive(true);
    }

    public void AR1C1_ToApple()
    {
        Q4_Interview.SetActive(false);

        Apple.SetActive(true);
    }

    public void AR1C1_Q4Success()
    {
        Q4Check = true;

        BlackBg.SetActive(false);
        Q4.SetActive(false);
        Apple.SetActive(false);

        AR1C1_BackBtnMGT();

        MainText.text = "존스티나 학교, 교수의 비밀공간";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR1C1_Q5()
    {
        if (Q4Check == true) 
        {
            Progress = 4;

            MapTextBtn.SetActive(false);

            MapBtn.SetActive(true);
            BlackBg.SetActive(true);
            Q5.SetActive(true);

            BackBtnMGF();

            MainText.text = "";

            TopText.text = "Quiz 5.";
            BottomText.text = "범인이 있는 위치 찾기";
        }
        else
        {
            AR1C1_BackBtnMGT();
        }
    }

    public void AR1C1_MapClick()
    {
        Progress = 4;

        BlackBg.SetActive(true);
        Q5.SetActive(true);

        BackBtnMGF();

        MainText.text = "";

        TopText.text = "Quiz 5.";
        BottomText.text = "범인이 있는 위치 찾기";
    }

    public void Q5Text1()
    {
        MapText1.SetActive(false);
        MapText2.SetActive(true);
    }

    public void Q5Text2()
    {
        MapText2.SetActive(false);
    }

    public void AR1C1_Q5Text()
    {
        MapText3.SetActive(true);
    }

    public void ToRoom()
    {
        BlackBg.SetActive(false);
        Q5.SetActive(false);

        AR1C1_BackBtnMGT();

        MainText.text = "존스티나 학교, 교수의 비밀공간";

        TopText.text = "";
        BottomText.text = "";
    }

    public void OnClickS()
    {
        MapText3.SetActive(false);

        String Text = "정말로 '스키엔티아'를 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num1 = 1;
    }

    public void OnClickM()
    {
        MapText3.SetActive(false);

        String Text = "정말로 '메디움'를 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num2 = 1;
    }

    public void OnClickR()
    {
        MapText3.SetActive(false);

        String Text = "정말로 '렐리기오'를 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num3 = 1;
    }

    public void OnClickF()
    {
        MapText3.SetActive(false);

        String Text = "정말로 '핌브리아'를 선택하시겠습니까?";

        TheDM.Fun_PopupTwoBtn_Text(Text);

        Q5num4 = 1;
    }

    public void AR1C1_Q5Result()
    {
        if (Q5num1 == 1 || Q5num2 == 1 || Q5num3 == 1)
        {
            GameObject.Find("AR1C1_Fail").GetComponent<AR1_InteractionController>().Text();
            TheDM.PT_Back();

            Q5num1 = 0;
            Q5num2 = 0;
            Q5num3 = 0;
        }
        else if (Q5num4 == 1)
        {
            GameObject.Find("AR1C1_Success").GetComponent<AR1_InteractionController>().Text();
            TheDM.PT_Back();

            Q5num4 = 0;

            AR1_DialogueManager.Checknum = 0;

            BackBtnMGF();
        }
    }

    public void AR1C1_Q5Cancle()
    {
        MapText3.SetActive(true);
    }
}