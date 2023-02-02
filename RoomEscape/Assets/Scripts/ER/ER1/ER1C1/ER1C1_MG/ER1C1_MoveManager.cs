using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class ER1C1_MoveManager : MonoBehaviour
{
    public GameObject TB_Choice1;
    public GameObject TB_Choice2;
    public GameObject THB_Choice1;
    public GameObject THB_Choice2;

    public GameObject TB_Choice1_F;
    public GameObject TB_Choice2_F;
    public GameObject THB_Choice1_F;
    public GameObject THB_Choice2_F;

    public GameObject Banner;
    public GameObject MainTitle;
    public Text txt_MainTitle;

    public GameObject BlurryScreen;
    public GameObject Back;
    public EventTrigger BackBtn;
    public GameObject ItemCheck;

    public GameObject Intro;

    public GameObject PastureLand_PM;

    public GameObject Hill;
    public EventTrigger ToRockBtn;
    public GameObject SheepGrey3;
    public EventTrigger ToTreeBtn;
    public GameObject SheepGreen2;
    public EventTrigger ToCloudBtn;
    public EventTrigger ToBirdBtn;
    public GameObject SheepPink2;

    public GameObject ToRock;
    public GameObject Rock;
    public GameObject RockMove;
    public GameObject Skill1;
    public GameObject SheepGrey1;
    public GameObject SheepGrey2;

    public GameObject ToTree;
    public GameObject Tree;
    public GameObject TreeExpand;
    public GameObject TreeBtn;
    public GameObject SheepGrey4;
    public GameObject SheepGreen1;
    public EventTrigger SheepGreen1Btn;
    public GameObject SheepGreen3;

    public GameObject ToCloud;
    public GameObject SheepPink1;
    public GameObject SheepPink3;

    public GameObject ToBird;
    public GameObject SheepGrey5;
    public GameObject Bird_Basic;
    public GameObject Bird_Angry;
    public GameObject BirdBtn;

    public GameObject CavesLakes;
    public EventTrigger ToLakeBtn;
    public GameObject SheepBlue3;
    public EventTrigger ToHoneyBtn;
    public EventTrigger ToCaveBtn;

    public GameObject ToLake;
    public GameObject SheepBlue1;
    public GameObject SheepBlue2;

    public GameObject ToHoney;
    public GameObject Bees1;
    public GameObject Bees2;
    public GameObject HoneyBtn;

    public GameObject ToCave;
    public GameObject Picture;
    public GameObject PictureBtn;
    public GameObject BearDoor;
    public GameObject CaveInside;
    public GameObject Bear1;
    public GameObject Bear2;
    public GameObject BearEye1;
    public GameObject BearEye2;
    public GameObject BearBtn;
    public GameObject SheepBrown1;
    public GameObject SheepBrown2;

    public GameObject Cliff;
    public GameObject Quiz;
    public GameObject QuizText;

    public GameObject CottonField;
    public EventTrigger SheepCottonBtn;
    public GameObject SheepCotton1;
    public GameObject SheepCotton2;
    public GameObject Man_Sleep;
    public GameObject Man_No;
    public GameObject Man_Smile;
    public GameObject SheepGold;
    public GameObject Ladder;
    public GameObject Ladder_Hide;
    public GameObject LadderUse;
    public GameObject SheepWhite1;
    public GameObject SheepWhite2;

    public GameObject SixVersions;
    public GameObject Progress_0;
    public GameObject Progress_1;
    public GameObject Progress_2;
    public GameObject Progress_3;
    public GameObject Progress_4;
    public GameObject Progress_5;

    public GameObject SheepBasket_0;
    public GameObject SheepBasket_1;
    public GameObject SheepBasket_2;
    public GameObject SheepBasket_3;
    public GameObject SheepBasket_4;
    public GameObject SheepBasket_5;
    public GameObject SheepBasket_6;
    public GameObject SheepBasket_7;
    public GameObject SheepBasket_8;

    public GameObject Meat;

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

    bool BackState = false;

    public static int Progress = 0;
    public static int SheepBasket = -1;

    public static bool ToTreeCheck = false;
    public static bool ForGlove = false;

    public static bool BearMeat = false;
    public static bool BirdHoney = false;

    public static bool MeatCheck = false;
    public static bool FeedCheck = false;

    bool BirdHoneyCheck = false;

    bool HoneyItem = false;
    bool MeatItem = false;

    bool CaveCheck = false;

    bool QuizStart = false;

    bool addladder = false;

    public static bool LadderAdd = false;
    public static bool forladder = false;

    public static bool NoChoice = false;
    public static bool JustFail = false;
    public static bool AllBack = false;

    bool EndCheck = false;

    public static ER1C1_MoveManager instance;

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
        entry10 = new EventTrigger.Entry();
        entry10.eventID = EventTriggerType.PointerClick;
        entry11 = new EventTrigger.Entry();
        entry11.eventID = EventTriggerType.PointerClick;
        entry12 = new EventTrigger.Entry();
        entry12.eventID = EventTriggerType.PointerClick;
        entry13 = new EventTrigger.Entry();
        entry13.eventID = EventTriggerType.PointerClick;

        instance = this;

        PastureLand_PM.SetActive(false);

        Hill.SetActive(false);
        ToRock.SetActive(false);
        ToTree.SetActive(false);
        ToCloud.SetActive(false);
        ToBird.SetActive(false);

        CavesLakes.SetActive(false);
        ToLake.SetActive(false);
        ToHoney.SetActive(false);
        ToCave.SetActive(false);

        Cliff.SetActive(false);
        Quiz.SetActive(false);

        CottonField.SetActive(false);

        ItemCheck.SetActive(false);
        Back.SetActive(false);
        SixVersions.SetActive(true);
        MainTitle.SetActive(true);

        GameObject.Find("ER1C1_PastureLand_AM").GetComponent<ER1_InteractionController>().Text();

        entry1.callback.AddListener(RockClick);
        ToRockBtn.triggers.Add(entry1);

        entry2.callback.AddListener(ER1C1_TreeClick);
        ToTreeBtn.triggers.Add(entry2);

        entry3.callback.AddListener(CloudClick);
        ToCloudBtn.triggers.Add(entry3);

        entry4.callback.AddListener(BirdClick);
        ToBirdBtn.triggers.Add(entry4);

        entry5.callback.AddListener(LakeClick);
        ToLakeBtn.triggers.Add(entry5);

        entry6.callback.AddListener(HoneyClick);
        ToHoneyBtn.triggers.Add(entry6);

        entry7.callback.AddListener(CaveClick);
        ToCaveBtn.triggers.Add(entry7);

        entry8.callback.AddListener(SheepCottonClick);
        SheepCottonBtn.triggers.Add(entry8);
    }

    private void Update()
    {
        if (BackState == true)
        {
            Back.SetActive(true);
        }
        else
        {
            Back.SetActive(false);
        }
        if (ER1_Answerplace.isusedladder == true)
        {
            ER1_Answerplace.isusedladder = false;
            LadderEvent();
        }
        if (Hill.activeSelf == true || ToRock.activeSelf == true || ToTree.activeSelf == true || ToCloud.activeSelf == true || ToBird.activeSelf == true)
        {
            txt_MainTitle.text = "목초지 근처 언덕";
        }
        else if (CavesLakes.activeSelf == true || ToLake.activeSelf == true || ToHoney.activeSelf == true || ToCave.activeSelf == true)
        {
            txt_MainTitle.text = "동굴과 호수";
        }
        else if (PastureLand_PM.activeSelf == true)
        {
            txt_MainTitle.text = "목초지 앞";
        }
        else if (Cliff.activeSelf == true || Quiz.activeSelf == true)
        {
            txt_MainTitle.text = "절벽";
        }
        else if (CottonField.activeSelf == true)
        {
            txt_MainTitle.text = "목화밭";
        }
        else if (Banner.activeSelf == true)
        {
            txt_MainTitle.text = "";
        }
        else
        {
            txt_MainTitle.text = "목초지 앞";
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
        else if (Progress == 5)
        {
            Progress_4.SetActive(false);

            Progress_5.SetActive(true);
        }

        if (SheepBasket == 0)
        {
            SheepBasket_0.SetActive(true);

            SheepBasket_1.SetActive(false);
        }
        else if (SheepBasket == 1)
        {
            SheepBasket_0.SetActive(false);

            SheepBasket_1.SetActive(true);

            SheepBasket_2.SetActive(false);
        }
        else if (SheepBasket == 2)
        {
            SheepBasket_1.SetActive(false);

            SheepBasket_2.SetActive(true);

            SheepBasket_3.SetActive(false);
        }
        else if (SheepBasket == 3)
        {
            SheepBasket_2.SetActive(false);

            SheepBasket_3.SetActive(true);

            SheepBasket_4.SetActive(false);
        }
        else if (SheepBasket == 4)
        {
            SheepBasket_3.SetActive(false);

            SheepBasket_4.SetActive(true);

            SheepBasket_5.SetActive(false);
        }
        else if (SheepBasket == 5)
        {
            SheepBasket_4.SetActive(false);

            SheepBasket_5.SetActive(true);

            SheepBasket_6.SetActive(false);

            if (Hill.activeSelf == true || CavesLakes.activeSelf == true)
            {
                if (QuizStart == false)
                {
                    CliffClick();
                }
            }
        }
        else if (SheepBasket == 6)
        {
            SheepBasket_5.SetActive(false);

            SheepBasket_6.SetActive(true);

            SheepBasket_7.SetActive(false);
        }
        else if (SheepBasket == 7)
        {
            SheepBasket_6.SetActive(false);

            SheepBasket_7.SetActive(true);

            SheepBasket_8.SetActive(false);
        }
        else if (SheepBasket == 8)
        {
            EndCheck = true;

            SheepBasket_7.SetActive(false);

            SheepBasket_8.SetActive(true);
        }

        if (ItemCheck.activeSelf == true)
        {
            if (HoneyItem)
            {
                TB_Choice1.SetActive(true);
                THB_Choice2.SetActive(true);

                TB_Choice1_F.SetActive(false);
                THB_Choice2_F.SetActive(false);
            }
            else
            {
                TB_Choice1_F.SetActive(true);
                THB_Choice2_F.SetActive(true);

                TB_Choice1.SetActive(false);
                THB_Choice2.SetActive(false);
            }

            if (MeatItem)
            {
                THB_Choice1.SetActive(true);
                TB_Choice2.SetActive(true);

                THB_Choice1_F.SetActive(false);
                TB_Choice2_F.SetActive(false);
            }
            else
            {
                THB_Choice1_F.SetActive(true);
                TB_Choice2_F.SetActive(true);

                THB_Choice1.SetActive(false);
                TB_Choice2.SetActive(false);
            }

            if (ToCave.activeSelf == true)
            {
                if (HoneyItem == true && MeatItem == true)
                {
                    JustFail = true;
                }
                else if (HoneyItem == false && MeatItem == true)
                {
                    if (!BirdHoneyCheck)
                    {
                        ER1_DialogueManager.Checknum = 0;

                        JustFail = false;
                        AllBack = false;
                    }
                }
                else if (HoneyItem == false && MeatItem == false)
                {
                    if (!BirdHoneyCheck)
                    {
                        ER1_DialogueManager.Checknum = 0;

                        NoChoice = true;
                        AllBack = false;
                    }
                    else if (BirdHoneyCheck)
                    {
                        ER1_DialogueManager.Checknum = 0;

                        NoChoice = true;
                        AllBack = true;
                    }
                }
                else
                {
                    ER1_DialogueManager.Checknum = 0;

                    NoChoice = false;
                    AllBack = false;
                }
            }
            else
            {
                NoChoice = false;
                AllBack = false;
            }
        }
        else
        {
            TB_Choice1.SetActive(true);
            THB_Choice2.SetActive(true);

            TB_Choice1_F.SetActive(false);
            THB_Choice2_F.SetActive(false);

            THB_Choice1.SetActive(true);
            TB_Choice2.SetActive(true);

            THB_Choice1_F.SetActive(false);
            TB_Choice2_F.SetActive(false);

            NoChoice = false;
            AllBack = false;
        }
    }

    public void ER1C1_BackBtnMGT()
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

    public void ER1C1_Meat()
    {
        MeatCheck = true;
        MeatItem = true;

        BlurryScreen.SetActive(true);

        Meat.SetActive(true);
    }

    public void ER1C1_ItemOut()
    {
        BlurryScreen.SetActive(false);

        Meat.SetActive(false);
        SheepGrey2.SetActive(false);
        SheepGreen3.SetActive(false);
        SheepPink3.SetActive(false);
        SheepBlue2.SetActive(false);
        SheepBrown2.SetActive(false);
        SheepCotton2.SetActive(false);
        SheepGold.SetActive(false);
        Ladder.SetActive(false);
        SheepWhite2.SetActive(false);
    }

    public void ER1C1_Intro()
    {
        Intro.SetActive(true);
    }

    public void ER1C1_Hill(BaseEventData p)
    {
        ToTreeCheck = false;

        CavesLakes.SetActive(false);

        ToRock.SetActive(false);
        ToTree.SetActive(false);
        ToCloud.SetActive(false);
        ToBird.SetActive(false);

        Hill.SetActive(true);
    }

    public void ER1C1_Hill2()
    {
        ToTreeCheck = false;

        CavesLakes.SetActive(false);

        ToRock.SetActive(false);
        ToTree.SetActive(false);
        ToCloud.SetActive(false);
        ToBird.SetActive(false);

        Hill.SetActive(true);
    }

    void RockClick(BaseEventData p)
    {
        ER1C1_BackBtnMGT();

        Hill.SetActive(false);

        ToRock.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_Hill);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    public void ER1C1_RockMove()
    {
        Rock.SetActive(false);

        RockMove.SetActive(true);
    }

    public void ER1C1_Skill1()
    {
        Skill1.SetActive(true);
    }

    public void Skill1Click()
    {
        Skill1.SetActive(false);

        SheepGrey3.SetActive(true);
        SheepGrey4.SetActive(true);
        SheepGrey5.SetActive(true);
    }

    public void SheepGreyAdd()
    {
        BackBtnMGF();

        SheepBasket++;

        SheepGrey1.SetActive(false);
        SheepGrey3.SetActive(false);
        SheepGrey4.SetActive(false);
        SheepGrey5.SetActive(false);

        BlurryScreen.SetActive(true);

        SheepGrey2.SetActive(true);
    }

    public void ER1C1_TreeClick(BaseEventData p)
    {
        ToTreeCheck = true;

        ER1C1_BackBtnMGT();

        if (TreeBtn.activeSelf == true)
        {
            ForGlove = true;

            entry9.callback.RemoveAllListeners();
            SheepGreen1Btn.triggers.Remove(entry9);
        }
        else
        {
            entry9.callback.RemoveAllListeners();
            entry9.callback.AddListener(Text1);
            SheepGreen1Btn.triggers.Remove(entry9);
            SheepGreen1Btn.triggers.Add(entry9);
        }

        Hill.SetActive(false);
        TreeExpand.SetActive(false);

        ToTree.SetActive(true);
        Tree.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_Hill);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    public void ER1C1_TreeClick2()
    {
        ToTreeCheck = true;

        ER1C1_BackBtnMGT();

        if (TreeBtn.activeSelf == true)
        {
            ForGlove = true;

            entry9.callback.RemoveAllListeners();
            SheepGreen1Btn.triggers.Remove(entry9);
        }
        else
        {
            entry9.callback.RemoveAllListeners();
            entry9.callback.AddListener(Text1);
            SheepGreen1Btn.triggers.Remove(entry9);
            SheepGreen1Btn.triggers.Add(entry9);
        }

        Hill.SetActive(false);
        TreeExpand.SetActive(false);

        ToTree.SetActive(true);
        Tree.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_Hill);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    void Text1(BaseEventData p)
    {
        BackBtnMGF();

        GameObject.Find("ER1C1_ToTree").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_TreeExpand()
    {
        Tree.SetActive(false);

        TreeExpand.SetActive(true);
        TreeBtn.SetActive(true);
    }

    public void Glove()
    {
        BackBtnMGF();

        GameObject.Find("ER1C1_Tree").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_SheepGreenAdd()
    {
        SheepBasket++;

        TreeBtn.SetActive(false);
        SheepGreen1.SetActive(false);
        SheepGreen2.SetActive(false);

        BlurryScreen.SetActive(true);
        SheepGreen3.SetActive(true);
    }

    void CloudClick(BaseEventData p)
    {
        ER1C1_BackBtnMGT();

        Hill.SetActive(false);

        ToCloud.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_Hill);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    void BirdClick(BaseEventData p)
    {
        ER1C1_BackBtnMGT();

        Hill.SetActive(false);

        ToBird.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_Hill);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    public void ER1C1_BirdBasic()
    {
        Bird_Angry.SetActive(false);

        Bird_Basic.SetActive(true);
    }

    public void ER1C1_BirdAngry()
    {
        Bird_Basic.SetActive(false);

        Bird_Angry.SetActive(true);
    }

    public void ER1C1_BirdNo()
    {
        Bird_Basic.SetActive(false);
        Bird_Angry.SetActive(false);

        ItemCheck.SetActive(true);
    }

    public void ER1C1_BirdFeed()
    {
        ER1_Slot.removebird();

        Bird_Angry.SetActive(true);
    }

    public void ER1C1_BirdFeed_Return()
    {
        FeedCheck = true;
    }

    public void ER1C1_BirdHoney()
    {
        BirdHoneyCheck = true;
        HoneyItem = false;

        ER1_Slot.removehoney();

        Bird_Angry.SetActive(true);
    }

    public void ER1C1_BirdMeat()
    {
        MeatItem = false;

        ER1_Slot.removemeat();

        Bird_Angry.SetActive(true);
    }

    public void ER1C1_SheepPinkAdd()
    {
        SheepBasket++;

        ItemCheck.SetActive(false);

        SheepPink1.SetActive(false);
        SheepPink2.SetActive(false);
        BirdBtn.SetActive(false);

        BlurryScreen.SetActive(true);
        SheepPink3.SetActive(true);
    }

    public void ER1C1_CavesLakes(BaseEventData p)
    {
        ER1C1_MoveManager.Progress = 2;

        Hill.SetActive(false);

        ToLake.SetActive(false);
        ToHoney.SetActive(false);
        ToCave.SetActive(false);

        CavesLakes.SetActive(true);
    }

    public void ER1C1_CavesLakes2()
    {
        ER1C1_MoveManager.Progress = 2;

        Hill.SetActive(false);

        ToLake.SetActive(false);
        ToHoney.SetActive(false);
        ToCave.SetActive(false);

        CavesLakes.SetActive(true);
    }

    void LakeClick(BaseEventData p)
    {
        ER1C1_BackBtnMGT();

        CavesLakes.SetActive(false);

        ToLake.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_CavesLakes);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    public void SheepBlueAdd()
    {
        BackBtnMGF();

        SheepBasket++;

        SheepBlue1.SetActive(false);
        SheepBlue3.SetActive(false);

        BlurryScreen.SetActive(true);
        SheepBlue2.SetActive(true);
    }

    void HoneyClick(BaseEventData p)
    {
        ER1C1_BackBtnMGT();

        CavesLakes.SetActive(false);

        ToHoney.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_CavesLakes);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    public void HoneyAdd()
    {
        HoneyItem = true;

        HoneyBtn.SetActive(false);
        Bees1.SetActive(false);
        Bees2.SetActive(false);
    }

    void CaveClick(BaseEventData p)
    {
        if (CaveCheck)
        {
            ER1C1_BackBtnMGT();
        }
        else if (!CaveCheck)
        {
            CaveCheck = true;

            GameObject.Find("ER1C1_ToCave").GetComponent<ER1_InteractionController>().Text();
        }

        CavesLakes.SetActive(false);

        ToCave.SetActive(true);

        entry_BackBtn.callback.RemoveAllListeners();
        entry_BackBtn.callback.AddListener(BackBtnMGF_Trigger);
        entry_BackBtn.callback.AddListener(ER1C1_CavesLakes);
        BackBtn.triggers.Remove(entry_BackBtn);
        BackBtn.triggers.Add(entry_BackBtn);
    }

    public void PictureClick()
    {
        BackBtnMGF();

        Picture.SetActive(true);
    }

    public void ER1C1_Picture()
    {
        ER1C1_BackBtnMGT();

        Picture.SetActive(false);
    }

    public void CaveInsideClick()
    {
        BackBtnMGF();

        PictureBtn.SetActive(false);

        CaveInside.SetActive(true);
    }

    public void ER1C1_CaveInsideOut()
    {
        CaveInside.SetActive(false);

        PictureBtn.SetActive(true);
    }

    public void ER1C1_BearMeat()
    {
        ER1_Slot.removemeat();

        ItemCheck.SetActive(false);
    }

    public void ER1C1_BearDoor()
    {
        BearDoor.SetActive(true);

        ER1C1_DoorMove.StartMove = true;
    }

    public void ER1C1_BearMeat_Return()
    {
        BearMeat = true;
    }

    public void ER1C1_BearHoney()
    {
        HoneyItem = false;

        ER1_Slot.removehoney();

        ItemCheck.SetActive(false);
    }

    public void ER1C1_Bear()
    {
        ER1C1_BackBtnMGT();

        PictureBtn.SetActive(false);
        BearEye1.SetActive(false);
        BearEye2.SetActive(false);

        Bear1.SetActive(true);
        Bear2.SetActive(true);
        SheepBrown1.SetActive(true);
    }

    public void ER1C1_BearClcik()
    {
        BackBtnMGF();

        Bear1.SetActive(false);
        Bear2.SetActive(false);
        SheepBrown1.SetActive(false);
    }

    public void ER1C1_SheepBrownAdd()
    {
        SheepBasket++;

        BlurryScreen.SetActive(true);

        SheepBrown2.SetActive(true);
    }

    public void ER1C1_CaveEnd()
    {
        ER1C1_BackBtnMGT();

        BearBtn.SetActive(false);
    }

    public void ER1C1_FailCheck()
    {
        ItemCheck.SetActive(true);
    }

    public void Restore_NoHoney()
    {
        ER1C1_CavesLakes2();

        MeatItem = true;


        CaveInside.SetActive(false);

        CavesLakes.SetActive(true);
        PictureBtn.SetActive(true);

        BearMeat = true;
    }

    public void ER1C1_PM()
    {
        ER1C1_Hill2();
        ER1C1_CavesLakes2();

        CavesLakes.SetActive(false);

        PastureLand_PM.SetActive(true);
    }

    public void All_Restore()
    {
        ER1_DialogueManager.Checknum = 0;

        BirdHoneyCheck = false;
        MeatItem = true;
        HoneyItem = true;

        SheepBasket--;

        PastureLand_PM.SetActive(false);

        Bird_Basic.SetActive(false);
        Bird_Angry.SetActive(false);
        CaveInside.SetActive(false);

        SheepPink1.SetActive(true);
        SheepPink2.SetActive(true);
        BirdBtn.SetActive(true);
        PictureBtn.SetActive(true);

        Hill.SetActive(true);

        BearMeat = true;
        BirdHoney = true;
    }

    void CliffClick()
    {
        Progress = 3;

        QuizStart = true;

        Hill.SetActive(false);
        CavesLakes.SetActive(false);

        Cliff.SetActive(true);

        GameObject.Find("ER1C1_Cliff").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_Cliff()
    {
        Cliff.SetActive(false);

        Quiz.SetActive(true);
        QuizText.SetActive(true);
        ER1C1_QuizDragAndDrop.action2();
    }

    public void ER1C1_WSFail()
    {
        QuizText.SetActive(false);

        GameObject.Find("ER1C1_WolfFail").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_SGFail()
    {
        QuizText.SetActive(false);

        GameObject.Find("ER1C1_SheepFail").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_QSuccess()
    {
        QuizText.SetActive(false);

        GameObject.Find("ER1C1_CottonField").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_CottonField()
    {
        Progress = 4;

        Quiz.SetActive(false);

        CottonField.SetActive(true);
    }

    void SheepCottonClick(BaseEventData p)
    {
        SheepBasket++;

        SheepCotton1.SetActive(false);

        BlurryScreen.SetActive(true);
        SheepCotton2.SetActive(true);
    }

    public void ER1C1_ManSleep()
    {
        Man_No.SetActive(false);

        Man_Sleep.SetActive(true);
    }

    public void ER1C1_ManNo()
    {
        Man_Sleep.SetActive(false);

        Man_No.SetActive(true);
    }

    public void ER1C1_ManSmile()
    {
        Man_Sleep.SetActive(false);

        Man_Smile.SetActive(true);
    }

    public void ER1C1_SheepGold()
    {
        SheepBasket++;

        BlurryScreen.SetActive(true);
        SheepGold.SetActive(true);
    }

    public void ER1C1_Ladder()
    {
        Ladder_Hide.SetActive(false);
        BlurryScreen.SetActive(true);
        Ladder.SetActive(true);
    }

    public void ER1C1_LadderAdd()
    {
        LadderAdd = true;
        addladder = true;
        ER1C1_ItemOut();
    }

    public void ER1C1_LadderCheck()
    {
        if (addladder == true)
        {
            addladder = false;

            forladder = true;
        }
        else
        {

        }
    }

    public void LadderEvent()
    {
        GameObject.Find("ER1C1_LadderUse").GetComponent<ER1_InteractionController>().Text();
    }

    public void ER1C1_SheepWhite()
    {
        SheepBasket++;

        SheepWhite1.SetActive(false);

        BlurryScreen.SetActive(true);
        SheepWhite2.SetActive(true);
    }

    public void ER1C1_EndCheck()
    {
        if (EndCheck)
        {
            EndCheck = false;

            GameObject.Find("ER1C1_End").GetComponent<ER1_InteractionController>().Text();
        }
    }

    public void ER1C1_End()
    {
        ER1_DialogueManager.Checknum = 0;
        Progress = 5;

        CottonField.SetActive(false);

        PastureLand_PM.SetActive(true);
    }
}