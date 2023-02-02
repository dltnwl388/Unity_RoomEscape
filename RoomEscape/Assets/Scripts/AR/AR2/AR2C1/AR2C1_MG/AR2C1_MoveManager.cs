using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR2C1_MoveManager : MonoBehaviour
{
    public GameObject Choicebox;
    public GameObject ChoiceOneBtn;
    public GameObject Butler;
    public GameObject TextBox_Butler;
    public GameObject Butler_Basic_Big;

    public GameObject Icons;
    public GameObject BlurryScreen;
    public GameObject Back;
    public EventTrigger BackBtn;

    public GameObject IntroRoom;
    public GameObject usedkey;

    public GameObject Q1;
    public EventTrigger ToHallwayBtn;
    public EventTrigger ToRoomBtn;

    public GameObject Q2;
    public EventTrigger MapBtn1;
    public EventTrigger MapBtn2;
    public EventTrigger MapBtn3;
    public EventTrigger MapBtn4;
    public EventTrigger MapBtn5;

    public GameObject QH;
    public GameObject BoxOpen;
    public GameObject BoxOpenWithGun;

    public GameObject Hallway;
    public GameObject Hallway_Open;

    public GameObject ArRoomBasic;
    public EventTrigger ToCarpetBtn;
    public GameObject ToLetterObj;
    public EventTrigger ToLetterBtn;
    public GameObject ToNoLetterObj;
    public EventTrigger ToNoLetterBtn;
    public EventTrigger ToWindowBtn;
    public EventTrigger ToBookCaseBtn;
    public EventTrigger ToDeskBtn;
    public GameObject DeskHeartCard;
    public GameObject LampOnKeyDesk;
    public GameObject LampOnNoKeyDesk;
    public GameObject ToBoxObj;
    public EventTrigger ToBoxBtn;
    public GameObject ToOpenBoxObj;
    public EventTrigger ToOpenBoxBtn;

    public GameObject UnderCarpet;

    public GameObject NoOpenCarpet;
    public EventTrigger CarpetOpenBtn;

    public GameObject OpenCarpetWithCard;
    public GameObject OpenCarpetWithNoCard;

    public GameObject UpperCarpet;
    public GameObject LetterObj;
    public EventTrigger LetterBtn;
    public GameObject LetterOpenObj;
    public EventTrigger LetterOpenBtn;

    public GameObject LetterCardObj;
    public EventTrigger LetterCardBtn;

    public GameObject Window;
    public EventTrigger WindowBtn;
    public GameObject Box1;
    public GameObject Lamp1;
    public GameObject Lamp2;
    public GameObject Frame1;

    public GameObject BookCase;
    public GameObject BookCaseObj;
    public EventTrigger BookCaseBtn;
    public GameObject AR2C1_OldEtiquette;

    public GameObject Desk;
    public EventTrigger LeftDrawerBtn;
    public EventTrigger RightDrawerBtn;
    public GameObject Heart3Obj;
    public EventTrigger Heart3Btn;
    public GameObject LampOffObj;
    public EventTrigger LampOffBtn;
    public GameObject LampOnKeyObj;
    public EventTrigger LampOnKeyBtn;
    public GameObject LampOnNoKey;
    public EventTrigger Q3KeyBtn;
    public GameObject Dia7Obj;
    public EventTrigger Dia7Btn;
    public EventTrigger Map;
    public Button MapBtn;

    public GameObject Box;
    public EventTrigger LockBtn;
    public GameObject LockBtn2;

    public GameObject Clover2Card;
    public GameObject Dia7Card;
    public GameObject Heart3Card;
    public GameObject Spade5Card;

    public GameObject Things;
    public GameObject ClosePaper;
    public EventTrigger ClosePaperBtn;
    public GameObject OpenPaper;
    public GameObject JustPaper;
    public GameObject Diary;
    public GameObject DiaryContent;
    public EventTrigger DiaryContentBtn;

    public Text MainText;

    public Text TopText;
    public Text BottomText;

    public GameObject ThreeVersions;
    public GameObject Progress_0;
    public GameObject Progress_1;
    public GameObject Progress_2;

    public static int Progress = 0;

    bool BackState = false;

    bool Q2Event = false;
    bool Q3Text = false;
    bool Q3Ok = false;
    bool QHText = false;
    bool QHOk = false;
    bool QHNo = false;

    bool Clover2Check = false;
    bool Dia7Check = false;
    bool Heart3Check = false;
    bool Spade5Check = false;
    bool AllCard = false;

    bool MeetTheMaid = false;
    bool Q2Check = false;
    bool QHCheck1 = false;
    bool QHCheck2 = false;
    bool Q3Check = false;

    public static bool isdia = false;
    public static bool isheart = false;
    public static bool isclover = false;
    public static bool isspade = false;
    public static bool isold = false;
    public static bool isadopt = false;
    public static bool isdiary = false;
    public static bool iskey = false;
    public static bool isgun = false;
    public static bool forkey = false;
    public static bool a = false;

    bool EventABCheck = false;

    public static AR2C1_MoveManager instance;

    private EventTrigger.Entry entry_Btn;

    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;
    private EventTrigger.Entry entry3;
    private EventTrigger.Entry entry4;
    private EventTrigger.Entry entry5;
    private EventTrigger.Entry entry6;
    private EventTrigger.Entry entry7;

    void OnEnable()
    {
        instance = this;

        Back.SetActive(false);

        Hallway.SetActive(false);

        ArRoomBasic.SetActive(false);
        UnderCarpet.SetActive(false);
        UpperCarpet.SetActive(false);
        Window.SetActive(false);
        BookCase.SetActive(false);
        Desk.SetActive(false);
        Box.SetActive(false);

        AR2C1_OldEtiquette.SetActive(false);

        ThreeVersions.SetActive(true);

        entry_Btn = new EventTrigger.Entry();
        entry_Btn.eventID = EventTriggerType.PointerClick;

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
    }

    private void Start()
    {
        entry1.callback.AddListener(Q1Hallway);
        entry2.callback.AddListener(AR2C1_Q1Room);

        ToHallwayBtn.triggers.Add(entry1);
        ToRoomBtn.triggers.Add(entry2);
    }

    void Update()
    {
        if (Q3Text == true)
        {
            Q3Text = false;
        }
        if (BookCase.activeSelf == true)
        {
            forkey = true;
        }
        else
        {
            forkey = false;
        }

        if (AR2C1_Drop.isusedkey == true)
        {
            a = true;
            KeyCheck();
        }

        if (BackState == true)
        {
            Back.SetActive(true);
        }
        else
        {
            Back.SetActive(false);
        }

        if (Progress == 0)
        {
            Progress_1.SetActive(false);
            Progress_2.SetActive(false);

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

        if (EventABCheck == false)
        {
            if (Q2Check && Q3Check && QHCheck1 == true)
            {
                EventABCheck = true;

                if (MeetTheMaid == true)
                {
                    EventA();
                }
                else
                {
                    EventB();
                }
            }
            else if (Q2Check && Q3Check && QHCheck2 == true)
            {
                EventABCheck = true;

                if (MeetTheMaid == true)
                {
                    EventA();
                }
                else
                {
                    EventB();
                }
            }
        }
    }

    public void AR2C1_BackBtnMGT(BaseEventData p)
    {
        BackState = true;

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    public void BackBtnMGT()
    {
        BackState = true;

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    public void AR2C1_BackBtnMGF(BaseEventData p)
    {
        BackState = false;
    }

    public void BackBtnMGF()
    {
        BackState = false;
    }

    void Q1Hallway(BaseEventData p)
    {
        MeetTheMaid = true;

        Icons.SetActive(true);

        BlurryScreen.SetActive(false);

        IntroRoom.SetActive(false);
        Q1.SetActive(false);

        Hallway.SetActive(true);

        MainText.text = "○○○○ ○○○의 복도";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR2C1_Q1Room(BaseEventData p)
    {
        Icons.SetActive(true);

        BlurryScreen.SetActive(false);

        Choicebox.SetActive(false);
        ChoiceOneBtn.SetActive(false);

        IntroRoom.SetActive(false);
        Q1.SetActive(false);
        UnderCarpet.SetActive(false);
        UpperCarpet.SetActive(false);
        Window.SetActive(false);
        BookCase.SetActive(false);
        Desk.SetActive(false);
        Box.SetActive(false);

        ArRoomBasic.SetActive(true);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Carpet);
        ToCarpetBtn.triggers.Remove(entry1);
        ToCarpetBtn.triggers.Add(entry1);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Letter);
        ToLetterBtn.triggers.Remove(entry2);
        ToLetterBtn.triggers.Add(entry2);

        entry3.callback.RemoveAllListeners();
        entry3.callback.AddListener(WindowClick);
        ToWindowBtn.triggers.Remove(entry3);
        ToWindowBtn.triggers.Add(entry3);

        entry4.callback.RemoveAllListeners();
        entry4.callback.AddListener(BookcaseClick);
        ToBookCaseBtn.triggers.Remove(entry4);
        ToBookCaseBtn.triggers.Add(entry4);

        entry5.callback.RemoveAllListeners();
        entry5.callback.AddListener(DeskClick);
        ToDeskBtn.triggers.Remove(entry5);
        ToDeskBtn.triggers.Add(entry5);

        if (Q2Event == true)
        {
            Q2Check = true;
        }

        if (Q3Ok == true)
        {
            Q3Check = true;
        }

        if (QHOk == true)
        {
            QHCheck1 = true;

            ToBoxObj.SetActive(false);

            ToOpenBoxObj.SetActive(true);
            Box1.SetActive(true);

            entry6.callback.RemoveAllListeners();
            entry6.callback.AddListener(AR2C1_Box);
            ToOpenBoxBtn.triggers.Remove(entry6);
            ToOpenBoxBtn.triggers.Add(entry6);
        }
        else
        {
            entry7.callback.RemoveAllListeners();
            entry7.callback.AddListener(AR2C1_Box);
            ToBoxBtn.triggers.Remove(entry7);
            ToBoxBtn.triggers.Add(entry7);
        }

        if (QHNo == true)
        {
            QHCheck2 = true;
        }

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    public void AR2C1_Q1Room2()
    {
        Icons.SetActive(true);

        BlurryScreen.SetActive(false);

        Choicebox.SetActive(false);
        ChoiceOneBtn.SetActive(false);

        IntroRoom.SetActive(false);
        Q1.SetActive(false);
        UnderCarpet.SetActive(false);
        UpperCarpet.SetActive(false);
        Window.SetActive(false);
        BookCase.SetActive(false);
        Desk.SetActive(false);
        Box.SetActive(false);

        ArRoomBasic.SetActive(true);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Carpet);
        ToCarpetBtn.triggers.Remove(entry1);
        ToCarpetBtn.triggers.Add(entry1);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Letter);
        ToLetterBtn.triggers.Remove(entry2);
        ToLetterBtn.triggers.Add(entry2);

        entry3.callback.RemoveAllListeners();
        entry3.callback.AddListener(WindowClick);
        ToWindowBtn.triggers.Remove(entry3);
        ToWindowBtn.triggers.Add(entry3);

        entry4.callback.RemoveAllListeners();
        entry4.callback.AddListener(BookcaseClick);
        ToBookCaseBtn.triggers.Remove(entry4);
        ToBookCaseBtn.triggers.Add(entry4);

        entry5.callback.RemoveAllListeners();
        entry5.callback.AddListener(DeskClick);
        ToDeskBtn.triggers.Remove(entry5);
        ToDeskBtn.triggers.Add(entry5);

        if (Q2Event == true)
        {
            Q2Check = true;
        }

        if (Q3Ok == true)
        {
            Q3Check = true;
        }

        if (QHOk == true)
        {
            QHCheck1 = true;

            ToBoxObj.SetActive(false);

            ToOpenBoxObj.SetActive(true);
            Box1.SetActive(true);

            entry6.callback.RemoveAllListeners();
            entry6.callback.AddListener(AR2C1_Box);
            ToOpenBoxBtn.triggers.Remove(entry6);
            ToOpenBoxBtn.triggers.Add(entry6);
        }
        else
        {
            entry7.callback.RemoveAllListeners();
            entry7.callback.AddListener(AR2C1_Box);
            ToBoxBtn.triggers.Remove(entry7);
            ToBoxBtn.triggers.Add(entry7);
        }

        if (QHNo == true)
        {
            QHCheck2 = true;
        }

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    void Carpet(BaseEventData p)
    {
        BackState = true;

        ArRoomBasic.SetActive(false);

        UnderCarpet.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(OpenCarpet);
        entry2.callback.AddListener(Text1);
        CarpetOpenBtn.triggers.Remove(entry2);
        CarpetOpenBtn.triggers.Add(entry2);
    }

    void Text1(BaseEventData p)
    {
        GameObject.Find("AR2C1_UnderCarpet").GetComponent<AR2_InteractionController>().Text();
    }

    void OpenCarpet(BaseEventData p)
    {
        BackBtnMGF();

        NoOpenCarpet.SetActive(false);

        OpenCarpetWithCard.SetActive(true);
    }

    public void AR2C1_Clover2()
    {
        Clover2Check = true;

        BlurryScreen.SetActive(true);
        Clover2Card.SetActive(true);
    }

    public void AR2C1_C2Add()
    {
        BackState = true;

        BlurryScreen.SetActive(false);

        OpenCarpetWithCard.SetActive(false);
        Clover2Card.SetActive(false);
        isclover = true;

        OpenCarpetWithNoCard.SetActive(true);

        CardCheck();
    }

    void Letter(BaseEventData p)
    {
        BackState = true;

        ArRoomBasic.SetActive(false);

        UpperCarpet.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(AR2C1_BackBtnMGF);
        entry2.callback.AddListener(Text2);
        LetterBtn.triggers.Remove(entry2);
        LetterBtn.triggers.Add(entry2);
    }

    void Text2(BaseEventData p)
    {
        GameObject.Find("AR2C1_UpperCarpet").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_AddLetter()
    {
        Destroy(LetterObj);
        Destroy(ToLetterObj);

        BlurryScreen.SetActive(true);
        LetterOpenObj.SetActive(true);

        ToNoLetterObj.SetActive(true);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(OpenLetter);
        LetterOpenBtn.triggers.Remove(entry1);
        LetterOpenBtn.triggers.Add(entry1);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Letter);
        ToNoLetterBtn.triggers.Remove(entry2);
        ToNoLetterBtn.triggers.Add(entry2);
    }

    void OpenLetter(BaseEventData p)
    {
        LetterOpenObj.SetActive(false);

        LetterCardObj.SetActive(true);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Text3);
        LetterCardBtn.triggers.Remove(entry1);
        LetterCardBtn.triggers.Add(entry1);
    }

    void Text3(BaseEventData p)
    {
        GameObject.Find("AR2C1_Letter").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_Spade5()
    {
        Spade5Check = true;

        LetterCardObj.SetActive(false);

        Spade5Card.SetActive(true);
    }

    public void AR2C1_S5Add()
    {
        BackState = true;

        BlurryScreen.SetActive(false);

        Spade5Card.SetActive(false);
        isspade = true;

        CardCheck();
    }

    void WindowClick(BaseEventData p)
    {
        BackState = true;

        ArRoomBasic.SetActive(false);

        Window.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(AR2C1_BackBtnMGF);
        entry2.callback.AddListener(Text4);
        WindowBtn.triggers.Remove(entry2);
        WindowBtn.triggers.Add(entry2);
    }

    void Text4(BaseEventData p)
    {
        GameObject.Find("AR2C1_Window").GetComponent<AR2_InteractionController>().Text();
    }

    void BookcaseClick(BaseEventData p)
    {
        BackState = true;

        ArRoomBasic.SetActive(false);

        BookCase.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(JustOne);
        entry2.callback.AddListener(AR2C1_BackBtnMGF);
        BookCaseBtn.triggers.Remove(entry2);
        BookCaseBtn.triggers.Add(entry2);
    }

    void JustOne(BaseEventData p)
    {
        if (Q3Text == false)
        {
            Q3Text = true;

            GameObject.Find("AR2C1_Q3Text").GetComponent<AR2_InteractionController>().Text();
        }
        else
        {
            KeyCheck();
        }

        MainText.text = "";

        TopText.text = "Quiz 3.";
        BottomText.text = "책장 문 열기";
    }

    void KeyCheck()
    {
        if (a == true)
        {
            BackBtnMGF();

            GameObject.Find("AR2C1_BookCase").GetComponent<AR2_InteractionController>().Text();

            MainText.text = "";

            TopText.text = "Quiz 3.";
            BottomText.text = "책장 문 열기";
        }
        else
        {
            GameObject.Find("AR2C1_NoKey").GetComponent<AR2_InteractionController>().Text();
        }
    }

    public void AR2C1_OldBook()
    {
        BookCaseObj.SetActive(false);
        usedkey.SetActive(false);

        BlurryScreen.SetActive(true);
        AR2C1_OldEtiquette.SetActive(true);
    }

    public void AR2C1_OldBookAdd()
    {
        Progress++;

        Q3Ok = true;
        BackState = true;

        BlurryScreen.SetActive(false);

        AR2C1_OldEtiquette.SetActive(false);
        isold = true;

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    void DeskClick(BaseEventData p)
    {
        ArRoomBasic.SetActive(false);

        Desk.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        GameObject.Find("AR2C1_Desk").GetComponent<AR2_InteractionController>().Text();

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(DrawerClick);
        LeftDrawerBtn.triggers.Remove(entry2);
        LeftDrawerBtn.triggers.Add(entry2);

        entry3.callback.RemoveAllListeners();
        entry3.callback.AddListener(DrawerClick);
        RightDrawerBtn.triggers.Remove(entry3);
        RightDrawerBtn.triggers.Add(entry3);

        if (Heart3Check == false)
        {
            entry4.callback.RemoveAllListeners();
            entry4.callback.AddListener(HeartClick);
            Heart3Btn.triggers.Remove(entry4);
            Heart3Btn.triggers.Add(entry4);
        }
        if (LampOffObj.activeSelf == true)
        {
            entry5.callback.RemoveAllListeners();
            entry5.callback.AddListener(LampClick);
            LampOffBtn.triggers.Remove(entry5);
            LampOffBtn.triggers.Add(entry5);
        }
        else
        {
            entry6.callback.RemoveAllListeners();
            entry6.callback.AddListener(AR2C1_KeyAdd);
            LampOnKeyBtn.triggers.Remove(entry6);
            LampOnKeyBtn.triggers.Add(entry6);
        }

        entry7.callback.RemoveAllListeners();
        entry7.callback.AddListener(MapClick);
        Map.triggers.Remove(entry7);
        Map.triggers.Add(entry7);
    }

    void DrawerClick(BaseEventData p)
    {
        BackBtnMGF();

        GameObject.Find("AR2C1_Drawer").GetComponent<AR2_InteractionController>().Text();
    }

    void HeartClick(BaseEventData p)
    {
        BackBtnMGF();

        Destroy(Heart3Obj);
        isheart = true;
        Destroy(DeskHeartCard);

        BlurryScreen.SetActive(true);

        Heart3Card.SetActive(true);

        GameObject.Find("AR2C1_Heart3").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_H3Add()
    {
        Heart3Check = true;

        BackState = true;

        BlurryScreen.SetActive(false);

        Heart3Card.SetActive(false);

        CardCheck();
    }

    void LampClick(BaseEventData p)
    {
        BackBtnMGF();

        LampOffObj.SetActive(false);

        LampOnKeyDesk.SetActive(true);
        LampOnKeyObj.SetActive(true);
        Lamp1.SetActive(true);

        GameObject.Find("AR2C1_LampOn").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_LampOn()
    {
        BackState = true;

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(AR2C1_KeyAdd);
        Q3KeyBtn.triggers.Remove(entry1);
        Q3KeyBtn.triggers.Add(entry1);
    }

    public void AR2C1_KeyAdd(BaseEventData p)
    {
        BackBtnMGF();

        LampOnKeyDesk.SetActive(false);
        LampOnKeyObj.SetActive(false);
        Lamp1.SetActive(false);

        LampOnNoKeyDesk.SetActive(true);
        LampOnNoKey.SetActive(true);
        Lamp2.SetActive(true);
        iskey = true;

        GameObject.Find("AR2C1_Lamp").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_FrameClick()
    {
        BackBtnMGF();

        Frame1.SetActive(true);

        GameObject.Find("AR2C1_FrameMove").GetComponent<AR2_InteractionController>().Text();

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Dia7Click);
        Dia7Btn.triggers.Remove(entry1);
        Dia7Btn.triggers.Add(entry1);
    }

    void Dia7Click(BaseEventData p)
    {
        BackBtnMGF();

        Destroy(Dia7Obj);
        isdia = true;

        BlurryScreen.SetActive(true);

        Dia7Card.SetActive(true);

        GameObject.Find("AR2C1_Frame").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_D7Add()
    {
        Dia7Check = true;

        BackState = true;

        BlurryScreen.SetActive(false);

        Dia7Card.SetActive(false);

        CardCheck();
    }

    void CardCheck()
    {
        if (Clover2Check == true && Dia7Check == true && Heart3Check == true && Spade5Check == true && AllCard == false)
        {
            AllCard = true;

            GameObject.Find("AR2C1_Cards").GetComponent<AR2_InteractionController>().Text();
        }
    }

    void MapClick(BaseEventData p)
    {
        BackBtnMGF();

        Map.triggers.Remove(entry7);

        BlurryScreen.SetActive(true);

        Q2.SetActive(true);

        GameObject.Find("AR2C1_Quiz2").GetComponent<AR2_InteractionController>().Text();

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Q2Fail);
        MapBtn1.triggers.Remove(entry1);
        MapBtn1.triggers.Add(entry1);

        MapBtn2.triggers.Remove(entry1);
        MapBtn2.triggers.Add(entry1);

        MapBtn3.triggers.Remove(entry1);
        MapBtn3.triggers.Add(entry1);

        MapBtn4.triggers.Remove(entry1);
        MapBtn4.triggers.Add(entry1);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(Q2Success);
        MapBtn5.triggers.Remove(entry2);
        MapBtn5.triggers.Add(entry2);

        MainText.text = "";

        TopText.text = "Quiz 2.";
        BottomText.text = "현재 위치 파악하기";
    }

    void Q2Fail(BaseEventData p)
    {
        GameObject.Find("AR2C1_Q2Fail").GetComponent<AR2_InteractionController>().Text();
    }

    void Q2Success(BaseEventData p)
    {
        GameObject.Find("AR2C1_Q2Success").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_Q2Event()
    {
        MapBtn.interactable = false;

        entry7.callback.RemoveAllListeners();
        Map.triggers.Remove(entry7);

        Q2Event = true;

        BlurryScreen.SetActive(false);

        Q2.SetActive(false);
        Desk.SetActive(false);

        Hallway.SetActive(true);

        GameObject.Find("AR2C1_Q2Hallway").GetComponent<AR2_InteractionController>().Text();

        MainText.text = "존스티나 대저택의 복도";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR2C1_Q2Event_End()
    {
        Progress++;

        BackState = true;

        Hallway.SetActive(false);

        Desk.SetActive(true);

        MainText.text = "존스티나 대저택, 아이란의 방";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR2C1_Box(BaseEventData p)
    {
        BackState = true;

        ArRoomBasic.SetActive(false);

        Box.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(QHCheck);
        LockBtn.triggers.Remove(entry2);
        LockBtn.triggers.Add(entry2);

        if (QHOk == true)
        {
            BoxOpen.SetActive(true);
        }

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    public void AR2C1_Box2()
    {
        BackState = true;

        ArRoomBasic.SetActive(false);

        Box.SetActive(true);

        entry_Btn.callback.RemoveAllListeners();
        entry_Btn.callback.AddListener(AR2C1_BackBtnMGF);
        entry_Btn.callback.AddListener(AR2C1_Q1Room);
        BackBtn.triggers.Remove(entry_Btn);
        BackBtn.triggers.Add(entry_Btn);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(QHCheck);
        LockBtn.triggers.Remove(entry2);
        LockBtn.triggers.Add(entry2);

        if (QHOk == true)
        {
            BoxOpen.SetActive(true);
        }

        if (Q2Event == true)
        {
            MainText.text = "존스티나 대저택, 아이란의 방";

            TopText.text = "";
            BottomText.text = "";
        }
        else
        {
            MainText.text = "○○○○ ○○○의 방";

            TopText.text = "";
            BottomText.text = "";
        }
    }

    void QHCheck(BaseEventData p)
    {
        BackBtnMGF();

        if ((AllCard == false && QHText == false) || (AllCard == true && QHText == false))
        {
            QHText = true;

            GameObject.Find("AR2C1_Box").GetComponent<AR2_InteractionController>().Text();
        }
        else if (AllCard == false && QHText == true)
        {
            GameObject.Find("AR2C1_LockedBox").GetComponent<AR2_InteractionController>().Text();
        }
        else if (AllCard == true && QHText == true)
        {
            QHLocker();
        }

        MainText.text = "";

        TopText.text = "Hidden Quiz.";
        BottomText.text = "자물쇠 해제하기";
    }

    void QHLocker()
    {
        BlurryScreen.SetActive(true);

        QH.SetActive(true);
    }

    public void AR2C1_QHFail()
    {
        QHNo = true;

        Destroy(LockBtn2);

        BlurryScreen.SetActive(false);

        QH.SetActive(false);
    }

    public void AR2C1_QHSuccess()
    {
        QHOk = true;

        Destroy(LockBtn2);

        entry2.callback.RemoveAllListeners();
        LockBtn.triggers.Remove(entry2);

        BlurryScreen.SetActive(false);

        QH.SetActive(false);

        BoxOpenWithGun.SetActive(true);
        isgun = true;

        GameObject.Find("AR2C1_QHSuccess").GetComponent<AR2_InteractionController>().Text();
    }

    void EventA()
    {
        BackBtnMGF();

        GameObject.Find("AR2C1_EventA").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_HallwayA_1()
    {
        ArRoomBasic.SetActive(false);

        Hallway.SetActive(true);

        StartCoroutine(EventA_1());

        MainText.text = "존스티나 대저택의 복도";

        TopText.text = "";
        BottomText.text = "";
    }

    IEnumerator EventA_1()
    {
        yield return new WaitForSeconds(0.4f);

        Hallway.SetActive(false);

        Hallway_Open.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        GameObject.Find("AR2C1_EventA_1").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_HallwayA_2()
    {
        ArRoomBasic.SetActive(false);

        Hallway.SetActive(true);

        StartCoroutine(EventA_2());

        MainText.text = "존스티나 대저택의 복도";

        TopText.text = "";
        BottomText.text = "";
    }

    IEnumerator EventA_2()
    {
        yield return new WaitForSeconds(0.4f);

        Hallway.SetActive(false);

        Hallway_Open.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        GameObject.Find("AR2C1_EventA_2").GetComponent<AR2_InteractionController>().Text();
    }

    void EventB()
    {
        BackBtnMGF();

        GameObject.Find("AR2C1_EventB").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_EventB_1()
    {
        GameObject.Find("AR2C1_EventB_1").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_HallwayB_1()
    {
        ArRoomBasic.SetActive(false);

        Hallway.SetActive(true);

        StartCoroutine(EventB_2());

        MainText.text = "존스티나 대저택의 복도";

        TopText.text = "";
        BottomText.text = "";
    }

    IEnumerator EventB_2()
    {
        yield return new WaitForSeconds(0.4f);

        Hallway.SetActive(false);

        Hallway_Open.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        GameObject.Find("AR2C1_EventB_2").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_EventAB()
    {
        Hallway_Open.SetActive(false);

        ArRoomBasic.SetActive(true);
        Things.SetActive(true);

        GameObject.Find("AR2C1_EventAB").GetComponent<AR2_InteractionController>().Text();

        MainText.text = "존스티나 대저택, 아이란의 방";

        TopText.text = "";
        BottomText.text = "";
    }

    public void AR2C1_AdoptDocument_Closed()
    {
        BlurryScreen.SetActive(true);

        ClosePaper.SetActive(true);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Adopt_DocumentOpened);
        ClosePaperBtn.triggers.Remove(entry1);
        ClosePaperBtn.triggers.Add(entry1);
    }

    void Adopt_DocumentOpened(BaseEventData p)
    {
        ClosePaper.SetActive(false);

        OpenPaper.SetActive(true);

        StartCoroutine(AdoptDocument());
    }

    IEnumerator AdoptDocument()
    {
        yield return new WaitForSeconds(0.4f);

        OpenPaper.SetActive(false);

        JustPaper.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        GameObject.Find("AR2C1_AdoptDocument").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_Diary()
    {
        JustPaper.SetActive(false);
        isadopt = true;

        Diary.SetActive(true);
    }

    public void AR2C1_DiaryContent()
    {
        Diary.SetActive(false);

        DiaryContent.SetActive(true);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Text5);
        DiaryContentBtn.triggers.Remove(entry1);
        DiaryContentBtn.triggers.Add(entry1);
    }

    void Text5(BaseEventData p)
    {
        GameObject.Find("AR2C1_Diary").GetComponent<AR2_InteractionController>().Text();
    }

    public void AR2C1_IntroRoom()
    {
        BlurryScreen.SetActive(false);

        ArRoomBasic.SetActive(false);
        DiaryContent.SetActive(false);
        isdiary = true;

        IntroRoom.SetActive(true);
    }

    public void AR2C1_Hallway()
    {
        IntroRoom.SetActive(false);

        Hallway.SetActive(true);

        Butler.SetActive(true);
        TextBox_Butler.SetActive(false);
        Butler_Basic_Big.SetActive(true);

        MainText.text = "존스티나 대저택의 복도";

        TopText.text = "";
        BottomText.text = "";
    }
}