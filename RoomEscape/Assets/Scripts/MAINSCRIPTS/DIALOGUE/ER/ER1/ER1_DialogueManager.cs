using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;
using Unity.VisualScripting;

public class ER1_DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject DialogueBtn;
    
    [SerializeField] GameObject Textbox;
    [SerializeField] GameObject Choicebox;
    [SerializeField] GameObject ClickBtnBox;
    [SerializeField] GameObject PopupBox;
    [SerializeField] GameObject QuizBox;

    [SerializeField] GameObject ED_Fail;
    [SerializeField] GameObject ED_Success;

    [SerializeField] GameObject ED;
    [SerializeField] GameObject Notice;
    [SerializeField] GameObject C_Notice;
    [SerializeField] GameObject Etc;
    [SerializeField] GameObject ChoiceOneBtn;
    [SerializeField] GameObject ChoiceTwoBtn;
    [SerializeField] GameObject ChoiceThreeBtn;
    [SerializeField] GameObject ClickOneBtn;
    [SerializeField] GameObject PopupTwoBtn;
    [SerializeField] GameObject Q_Small;
    [SerializeField] GameObject Q_Medium;

    [SerializeField] Text txt_Fail;

    [SerializeField] GameObject EDArrow;
    [SerializeField] GameObject NoticeArrow;
    [SerializeField] GameObject EtcArrow;

    [SerializeField] Text txt_EDName;
    [SerializeField] Text txt_EDDialogue;
    [SerializeField] GameObject ED_Basic;
    [SerializeField] GameObject ED_Happy;
    [SerializeField] GameObject ED_Smile;
    [SerializeField] GameObject ED_Curious;
    [SerializeField] GameObject ED_Lazy;
    [SerializeField] GameObject ED_Sad;
    [SerializeField] GameObject ED_Surprised;

    [SerializeField] Text txt_Notice;

    [SerializeField] Text txt_C_Notice;

    [SerializeField] Text txt_EtcName;
    [SerializeField] Text txt_EtcDialogue;
    [SerializeField] GameObject SheepGrey;
    [SerializeField] GameObject SheepGreen;
    [SerializeField] GameObject SheepPink;
    [SerializeField] GameObject SheepBlue;

    [SerializeField] EventTrigger OB_Choice1;
    [SerializeField] Button OB_Choice1_Btn;
    [SerializeField] Text OB_txt_Choice1;

    [SerializeField] EventTrigger TB_Choice1;
    [SerializeField] Button TB_Choice1_Btn;
    [SerializeField] EventTrigger TB_Choice2;
    [SerializeField] Button TB_Choice2_Btn;
    [SerializeField] Text TB_txt_Choice1;
    [SerializeField] Text TB_txt_Choice2;

    [SerializeField] EventTrigger THB_Choice1;
    [SerializeField] Button THB_Choice1_Btn;
    [SerializeField] EventTrigger THB_Choice2;
    [SerializeField] Button THB_Choice2_Btn;
    [SerializeField] EventTrigger THB_Choice3;
    [SerializeField] Button THB_Choice3_Btn;
    [SerializeField] Text THB_txt_Choice1;
    [SerializeField] Text THB_txt_Choice2;
    [SerializeField] Text THB_txt_Choice3;

    [SerializeField] Text OB_txt_Btn1;
    [SerializeField] EventTrigger OB_Btn1;
    [SerializeField] Button OB_Btn1_Btn;
    [SerializeField] Text OB_txt_TextBtn1;
    [SerializeField] GameObject OB_Btn1Block;

    [SerializeField] Text txt_PT;
    [SerializeField] EventTrigger PT_Choose1;
    [SerializeField] Button PT_Choose1_Btn;
    [SerializeField] Text PT_txt_Choose1;
    [SerializeField] EventTrigger PT_Choose2;
    [SerializeField] Button PT_Choose2_Btn;
    [SerializeField] Text PT_txt_Choose2;

    [SerializeField] Text txt_QS;
    [SerializeField] Text txt_QM;

    ER1_Dialogue[] dialogues;

    [SerializeField] GameObject ER1C1;

    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;
    private EventTrigger.Entry entry3;
    private EventTrigger.Entry entry4;
    private EventTrigger.Entry entry5;
    private EventTrigger.Entry entry6;
    private EventTrigger.Entry entry7;
    private EventTrigger.Entry entry8;
    private EventTrigger.Entry entry9;

    public static bool isDialogue = false;
    bool isNext = false;

    int lineCount = 0;
    int contextCount = 0;

    float x = 0, y = 0;

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;

    int _StartNum = 0;
    int _Num1 = 0, _Num2 = 0, _Num3 = 0;

    public static int Checknum = 0;

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

        entry7 = new EventTrigger.Entry();
        entry7.eventID = EventTriggerType.PointerClick;

        entry8 = new EventTrigger.Entry();
        entry8.eventID = EventTriggerType.PointerClick;

        entry9 = new EventTrigger.Entry();
        entry9.eventID = EventTriggerType.PointerClick;
    }

    void Update()
    {
        if (isNext)
        {
            if (isDialogue)
            {
                if (ER1_DialogueButton.isBtnUp == true)
                {        
                    isNext = false;
                    ER1_DialogueButton.isBtnUp = false;

                    txt_EDDialogue.text = "";
                    txt_EtcDialogue.text = "";
                    txt_Notice.text = "";
                    txt_C_Notice.text = "";
                    OB_txt_Btn1.text = "";

                    if (++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;

                        if (++lineCount < dialogues.Length)
                        {
                            if (dialogues[lineCount - 1].multi == "Return")
                            {
                                lineCount = int.Parse(dialogues[lineCount - 1].move);
                            }
                            else if (dialogues[lineCount - 1].multi == "Jump")
                            {
                                lineCount = int.Parse(dialogues[lineCount - 1].move);
                            }

                            if (dialogues[lineCount].name == "선택지1개")
                            {
                                Fun_ChoiceOneBtn();
                            }
                            else if (dialogues[lineCount].name == "선택지2개")
                            {
                                if (ER1C1 != null)
                                {
                                    if (ER1C1_MoveManager.NoChoice == true)
                                    {
                                        if (ER1C1_MoveManager.AllBack == true)
                                        {
                                            GameObject.Find("ER1C1_BearFail").GetComponent<ER1_InteractionController>().Text();
                                        }
                                        else
                                        {
                                            ER1C1_MoveManager.instance.ER1C1_BackBtnMGT();
                                            ER1C1_MoveManager.instance.ER1C1_CaveInsideOut();

                                            EndDialogue();
                                        }
                                    }
                                    else
                                    {
                                        Fun_ChoiceTwoBtn();
                                    }
                                }
                                else
                                {
                                    Fun_ChoiceTwoBtn();
                                }
                            }
                            else if (dialogues[lineCount].name == "선택지3개")
                            {
                                Fun_ChoiceThreeBtn();
                            }
                            else if (dialogues[lineCount].name == "버튼1개")
                            {
                                Fun_ClickOneBtn();
                            }
                            else if (dialogues[lineCount].name == "버튼종료")
                            {
                                Fun_EndBtn();
                            }
                            else if (dialogues[lineCount].name == "Q_Small")
                            {
                                Fun_Quiz_Small();
                            }
                            else if (dialogues[lineCount].name == "Q_Medium")
                            {
                                Fun_Quiz_medium();
                            }
                            else if (dialogues[lineCount].name == "Fail")
                            {
                                if (dialogues[lineCount].single == "ER1C1_BirdFeed_Return")
                                {
                                    ER1C1_MoveManager.instance.ER1C1_BirdFeed_Return();
                                }
                                else if (dialogues[lineCount].single == "ER1C1_BearMeat_Return")
                                {
                                    ER1C1_MoveManager.instance.ER1C1_BearMeat_Return();
                                }

                                Fun_Fail();
                            }
                            else if (dialogues[lineCount - 1].move == "Success")
                            {
                                ED_Success.SetActive(true);

                                EndDialogue();
                            }
                            else if (ER1C1 != null)
                            {
                                if (ER1C1.activeSelf == true)
                                {
                                    ER1C1_lineCountIng();
                                }
                            }
                            else
                            {
                                StartCoroutine(TypeWriter());
                            }
                        }
                        else
                        {
                            if (dialogues[lineCount - 1].multi == "Return")
                            {
                                lineCount = int.Parse(dialogues[lineCount - 1].move);

                                isNext = true;
                            }
                            else if (dialogues[lineCount - 1].multi == "Jump")
                            {
                                lineCount = int.Parse(dialogues[lineCount - 1].move);

                                isNext = true;
                            }

                            if (dialogues[lineCount - 1].name == "Fail")
                            {
                                Fun_Fail();
                            }
                            else if (dialogues[lineCount - 1].move == "Success")
                            {
                                ED_Success.SetActive(true);

                                EndDialogue();
                            }
                            else if (ER1C1 != null)
                            {
                                if (ER1C1.activeSelf == true)
                                {
                                    ER1C1_lineCountEnd();
                                }
                            }
                            else
                            {
                                EndDialogue();
                            }
                        }
                    }
                }
            }
        }
    }

    void ER1C1_lineCountIng()
    {
        if (dialogues[lineCount].single == "ER1C1_Meat")
        {
            ER1C1_MoveManager.instance.ER1C1_Meat();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_ItemOut")
        {
            ER1C1_MoveManager.instance.ER1C1_ItemOut();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_Skill1")
        {
            ER1C1_MoveManager.instance.ER1C1_Skill1();

            EndDialogue();
        }
        else if (dialogues[lineCount].single == "ER1C1_TreeExpand")
        {
            ER1C1_MoveManager.instance.ER1C1_TreeExpand();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BirdBasic")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdBasic();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BirdAngry")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdAngry();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BirdNo")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdNo();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_SheepPinkAdd")
        {
            ER1C1_MoveManager.instance.ER1C1_SheepPinkAdd();

            EndDialogue();
        }
        else if (dialogues[lineCount].single == "ER1C1_BearDoor")
        {
            ER1C1_MoveManager.instance.ER1C1_BearDoor();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_Bear")
        {
            ER1C1_MoveManager.instance.ER1C1_Bear();

            EndDialogue();
        }
        else if (dialogues[lineCount].single == "ER1C1_SheepBrownAdd")
        {
            ER1C1_MoveManager.instance.ER1C1_SheepBrownAdd();

            EndDialogue();
        }
        else if (dialogues[lineCount].single == "ER1C1_PM")
        {
            ER1C1_MoveManager.instance.ER1C1_PM();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_CottonField")
        {
            ER1C1_MoveManager.instance.ER1C1_CottonField();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_ManNo")
        {
            ER1C1_MoveManager.instance.ER1C1_ManNo();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_ManSmile")
        {
            ER1C1_MoveManager.instance.ER1C1_ManSmile();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_SheepGold")
        {
            ER1C1_MoveManager.instance.ER1C1_SheepGold();

            EndDialogue();
        }
        else if (dialogues[lineCount].single == "ER1C1_LadderAdd")
        {
            ER1C1_MoveManager.instance.ER1C1_LadderAdd();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_BackBtn")
        {
            ER1C1_MoveManager.instance.ER1C1_BackBtnMGT();

            EndDialogue();
        }
        else
        {
            StartCoroutine(TypeWriter());
        }
    }

    void ER1C1_lineCountEnd()
    {
        if (dialogues[lineCount - 1].single == "ER1C1_Intro")
        {
            ER1C1_MoveManager.instance.ER1C1_Intro();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_TreeClick")
        {
            ER1C1_MoveManager.instance.ER1C1_TreeClick2();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_SheepGreenAdd")
        {
            ER1C1_MoveManager.instance.ER1C1_SheepGreenAdd();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_Picture")
        {
            ER1C1_MoveManager.instance.ER1C1_Picture();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_CaveEnd")
        {
            ER1C1_MoveManager.instance.ER1C1_CaveEnd();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_Cliff")
        {
            ER1C1_MoveManager.instance.ER1C1_Cliff();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_LadderCheck")
        {
            ER1C1_MoveManager.instance.ER1C1_LadderCheck();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_SheepWhite")
        {
            ER1C1_MoveManager.instance.ER1C1_SheepWhite();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_BackBtn")
        {
            ER1C1_MoveManager.instance.ER1C1_BackBtnMGT();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "ER1C1_EndCheck")
        {
            ER1C1_MoveManager.instance.ER1C1_EndCheck();

            EndDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    public void ShowDialogue(ER1_Dialogue[] p_dialogues, float a, float b)
    {
        isDialogue = true;

        txt_EDDialogue.text = "";
        txt_EtcDialogue.text = "";
        txt_Notice.text = "";
        txt_C_Notice.text = "";
        txt_EDName.text = "";
        txt_EtcName.text = "";
        OB_txt_Choice1.text = "";
        TB_txt_Choice1.text = "";
        TB_txt_Choice2.text = "";
        OB_txt_Btn1.text = "";
        OB_txt_TextBtn1.text = "";
        PT_txt_Choose1.text = "";
        PT_txt_Choose2.text = "";

        dialogues = p_dialogues;

        lineCount = 0;
        x = a; y = b;

        if (dialogues[lineCount].move == "JustOne")
        {
            ++Checknum;

            if (Checknum >= 2)
            {
                ++lineCount;
                ++x;
            }
        }

        if (dialogues[lineCount].move == "Start" && _StartNum != 0)
        {
            lineCount = _StartNum;
            x = _StartNum;

            int number = 0;

            for(int i = (int)x; i < y+1; i++)
            {
                if (dialogues[lineCount + number].move == "End")
                {
                    y = i+1;
                    break;
                }

                number += 1;
            }
        }

        if (dialogues[lineCount].name == "Fail")
        {
            Fun_Fail();
        }
        else if (dialogues[lineCount].name == "버튼1개")
        {
            Fun_ClickOneBtn();
        }
        else if (dialogues[lineCount].name == "선택지2개")
        {
            Fun_ChoiceTwoBtn();
        }
        else if (dialogues[lineCount].name == "선택지3개")
        {
            Fun_ChoiceThreeBtn();
        }
        else if (dialogues[lineCount].name == "Q_Small")
        {
            Fun_Quiz_Small();
        }
        else if (dialogues[lineCount].name == "Q_Medium")
        {
            Fun_Quiz_medium();
        }
        else if (dialogues[lineCount].name == "Popup")
        {
            Fun_PopupTwoBtn_Btn();
        }
        else if (ER1C1 != null)
        {
            if (ER1C1.activeSelf == true)
            {
                ER1C1_ShowDialogue();
            }
        }
        else
        {
            StartCoroutine(TypeWriter());
        }
    }

    void ER1C1_ShowDialogue()
    {
        if (dialogues[lineCount].single == "ER1C1_RockMove")
        {
            ER1C1_MoveManager.instance.ER1C1_RockMove();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BirdFeed")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdFeed();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BirdHoney")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdHoney();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BirdMeat")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdMeat();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_CavesLakes")
        {
            ER1C1_MoveManager.instance.ER1C1_CavesLakes2();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_FailCheck")
        {
            ER1C1_MoveManager.instance.ER1C1_FailCheck();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BearMeat")
        {
            ER1C1_MoveManager.instance.ER1C1_BearMeat();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BearHoney")
        {
            ER1C1_MoveManager.instance.ER1C1_BearHoney();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_BearClcik")
        {
            ER1C1_MoveManager.instance.ER1C1_BearClcik();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_Ladder")
        {
            ER1C1_MoveManager.instance.ER1C1_Ladder();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "ER1C1_End")
        {
            ER1C1_MoveManager.instance.ER1C1_End();

            StartCoroutine(TypeWriter());
        }
        else
        {
            StartCoroutine(TypeWriter());
        }
    }

    IEnumerator TypeWriter()
    {
        SettingUI(true);

        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("@", ",");
        t_ReplaceText = t_ReplaceText.Replace("\\n", "\n");
        t_ReplaceText = t_ReplaceText.Replace("\"", "");

        bool t_white = false, t_red = false, t_green = false, t_black = false;
        bool t_italic = false;
        bool t_ignore = false;

        for (int i = 0; i < t_ReplaceText.Length; i++)
        {
            isNext = false;

            switch (t_ReplaceText[i])
            {
                case 'ⓡ': t_white = false; t_red = true; t_green = false; t_black = false; t_italic = false; t_ignore = true; break;
                case 'ⓦ': t_white = true; t_red = false; t_green = false; t_black = false; t_italic = false; t_ignore = true; break;
                case 'ⓖ': t_white = false; t_red = false; t_green = true; t_black = false; t_italic = false; t_ignore = true; break;
                case 'ⓚ': t_white = false; t_red = false; t_green = false; t_black = true; t_italic = false; t_ignore = true; break;
                case 'ⓘ': t_white = false; t_red = false; t_green = false; t_black = false; t_italic = true; t_ignore = true; break;
            }

            string t_letter = t_ReplaceText[i].ToString();

            if (!t_ignore)
            {
                if (t_red) { t_letter = "<color=#FF0000>" + t_letter + "</color>"; }
                else if (t_white) { t_letter = "<color=#FFFFFF>" + t_letter + "</color>"; }
                else if (t_green) { if (C_Notice.activeSelf == true) { t_letter = "<color=#305519>" + t_letter + "</color>"; } else { t_letter = "<color=#62A339>" + t_letter + "</color>"; } }
                else if (t_black) { t_letter = "<color=#000000>" + t_letter + "</color>"; }
                else if (t_italic) { t_letter = "<i>" + t_letter + "</i>"; }

                txt_EDDialogue.text += t_letter;
                txt_EtcDialogue.text += t_letter;
                txt_Notice.text += t_letter;
                txt_C_Notice.text += t_letter;
                OB_txt_Btn1.text += t_letter;
            }
            t_ignore = false;

            yield return new WaitForSeconds(textDelay);
        }

        if (dialogues[lineCount].multi == "NoBlock")
        {
            OB_Btn1Block.SetActive(false);
        }
        else
        {
            OB_Btn1Block.SetActive(true);
        }

        OB_Btn1.triggers.Add(entry1);

        isNext = true;
    }

    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;

        x = 0; y = 0;

        SettingUI(false);
    }

    void OnlyTextbox()
    {
        Textbox.SetActive(true);
        Choicebox.SetActive(false);
        ClickBtnBox.SetActive(false);
        PopupBox.SetActive(false);
        QuizBox.SetActive(false);

        ChoiceOneBtn.SetActive(false);
        ChoiceTwoBtn.SetActive(false);
        ChoiceThreeBtn.SetActive(false);
        ClickOneBtn.SetActive(false);
        PopupTwoBtn.SetActive(false);
        Q_Small.SetActive(false);
        Q_Medium.SetActive(false);
    }

    public void SettingUI(bool p_flag)
    {
        if (p_flag == true)
        {
            DialogueBtn.SetActive(true);

            if (x >= y)
            {
                EDArrow.SetActive(false);
                NoticeArrow.SetActive(false);
                EtcArrow.SetActive(false);
            }
            else
            {
                EDArrow.SetActive(true);
                NoticeArrow.SetActive(true);
                EtcArrow.SetActive(true);

                x += 1;
            }

            if (dialogues[lineCount].name == "")
            {
                ED.SetActive(false);
                Notice.SetActive(true);
                C_Notice.SetActive(false);
                Etc.SetActive(false);

                OnlyTextbox();
            }
            else if (dialogues[lineCount].name == "C_Notice")
            {
                ED.SetActive(false);
                Notice.SetActive(false);
                C_Notice.SetActive(true);
                Etc.SetActive(false);

                OnlyTextbox();
            }
            else if (dialogues[lineCount].name == "아주머니" || dialogues[lineCount].name == "퐁신새" || dialogues[lineCount].name == "검은 양" || dialogues[lineCount].name == "초록 양" || dialogues[lineCount].name == "분홍 양" || dialogues[lineCount].name == "파란 양")
            {
                ED.SetActive(false);
                Notice.SetActive(false);
                C_Notice.SetActive(false);
                Etc.SetActive(true);
                SheepGrey.SetActive(false);
                SheepGreen.SetActive(false);
                SheepPink.SetActive(false);
                SheepBlue.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].name == "검은 양")
                {
                    SheepGrey.SetActive(true);
                }
                else if (dialogues[lineCount].name == "초록 양")
                {
                    SheepGreen.SetActive(true);
                }
                else if (dialogues[lineCount].name == "분홍 양")
                {
                    SheepPink.SetActive(true);
                }
                else if (dialogues[lineCount].name == "파란 양")
                {
                    SheepBlue.SetActive(true);
                }

                txt_EtcName.text = dialogues[lineCount].name;
            }
            else if (dialogues[lineCount].name == "에르덴투야")
            {
                ED.SetActive(true);
                ED_Basic.SetActive(false);
                ED_Happy.SetActive(false);
                ED_Smile.SetActive(false);
                ED_Curious.SetActive(false);
                ED_Lazy.SetActive(false);
                ED_Sad.SetActive(false);
                ED_Surprised.SetActive(false);
                Notice.SetActive(false);
                C_Notice.SetActive(false);
                Etc.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].multi == "ED_Happy")
                {
                    ED_Happy.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "ED_Smile")
                {
                    ED_Smile.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "ED_Curious")
                {
                    ED_Curious.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "ED_Lazy")
                {
                    ED_Lazy.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "ED_Sad")
                {
                    ED_Sad.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "ED_Surprised")
                {
                    ED_Surprised.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "ED_No")
                {
                    ED_Basic.SetActive(false);
                }
                else
                {
                    ED_Basic.SetActive(true);
                }

                txt_EDName.text = dialogues[lineCount].name;
            }
        }
        else if (p_flag == false)
        {
            DialogueBtn.SetActive(false);

            Textbox.SetActive(false);

            ED.SetActive(false);
            Notice.SetActive(false);
            C_Notice.SetActive(false);
            Etc.SetActive(false);

            EDArrow.SetActive(true);
            NoticeArrow.SetActive(true);
            EtcArrow.SetActive(true);
        }
    }

    void Fun_Fail()
    {
        ED_Fail.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");
        Text1 = Text1.Replace("ⓖ", "<color=#62A339>");
        Text1 = Text1.Replace("ⓡ", "<color=#FF0000>");
        Text1 = Text1.Replace("ⓦ", "</color>");

        txt_Fail.text = Text1;

        Text1 = "";

        EndDialogue();
    }

    void Fun_ChoiceOneBtn()
    {
        Choicebox.SetActive(true);
        ChoiceOneBtn.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");

        OB_txt_Choice1.text = Text1;

        Text1 = "";

        EndDialogue();
    }

    void Fun_ChoiceTwoBtn()
    {
        Choicebox.SetActive(true);
        ChoiceTwoBtn.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");

        string Text2 = dialogues[lineCount + 1].contexts[contextCount];
        Text2 = Text2.Replace("@", ",");
        Text2 = Text2.Replace("\\n", "\n");
        Text2 = Text2.Replace("\"", "");

        TB_txt_Choice1.text = Text1;
        TB_txt_Choice2.text = Text2;

        Text1 = "";
        Text2 = "";

        if (dialogues[lineCount].single == "ER1C1_ManSleep")
        {
            ER1C1_MoveManager.instance.ER1C1_ManSleep();
        }

        if (dialogues[lineCount].multi == "Text")
        {
            _Num1 = int.Parse(dialogues[lineCount].move);
            _Num2 = int.Parse(dialogues[lineCount + 1].move);

            entry2.callback.RemoveAllListeners();
            entry2.callback.AddListener(TextOpen_TBChoice1);
            TB_Choice1.triggers.Remove(entry2);
            TB_Choice1.triggers.Add(entry2);

            entry3.callback.RemoveAllListeners();
            entry3.callback.AddListener(TextOpen_TBChoice2);
            TB_Choice2.triggers.Remove(entry3);
            TB_Choice2.triggers.Add(entry3);
        }

        EndDialogue();
    }

    void TextOpen_TBChoice1(BaseEventData p)
    {
        Textbox.SetActive(true);
        Choicebox.SetActive(false);
        ChoiceTwoBtn.SetActive(false);

        _StartNum = _Num1;
    }

    void TextOpen_TBChoice2(BaseEventData p)
    {
        Textbox.SetActive(true);
        Choicebox.SetActive(false);
        ChoiceTwoBtn.SetActive(false);

        _StartNum = _Num2;
    }

    void Fun_ChoiceThreeBtn()
    {
        Choicebox.SetActive(true);
        ChoiceThreeBtn.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");

        string Text2 = dialogues[lineCount + 1].contexts[contextCount];
        Text2 = Text2.Replace("@", ",");
        Text2 = Text2.Replace("\\n", "\n");
        Text2 = Text2.Replace("\"", "");

        string Text3 = dialogues[lineCount + 2].contexts[contextCount];
        Text3 = Text3.Replace("@", ",");
        Text3 = Text3.Replace("\\n", "\n");
        Text3 = Text3.Replace("\"", "");

        THB_txt_Choice1.text = Text1;
        THB_txt_Choice2.text = Text2;
        THB_txt_Choice3.text = Text3;

        Text1 = "";
        Text2 = "";
        Text3 = "";

        if (dialogues[lineCount].single == "ER1C1_BirdNo")
        {
            ER1C1_MoveManager.instance.ER1C1_BirdNo();
        }

        if (dialogues[lineCount].multi == "Text")
        {
            _Num1 = int.Parse(dialogues[lineCount].move);
            _Num2 = int.Parse(dialogues[lineCount + 1].move);
            _Num3 = int.Parse(dialogues[lineCount + 2].move);

            entry4.callback.RemoveAllListeners();
            entry4.callback.AddListener(TextOpen_THBChoice1);
            THB_Choice1.triggers.Remove(entry4);
            THB_Choice1.triggers.Add(entry4);

            entry5.callback.RemoveAllListeners();
            entry5.callback.AddListener(TextOpen_THBChoice2);
            THB_Choice2.triggers.Remove(entry5);
            THB_Choice2.triggers.Add(entry5);

            entry6.callback.RemoveAllListeners();
            entry6.callback.AddListener(TextOpen_THBChoice3);
            THB_Choice3.triggers.Remove(entry6);
            THB_Choice3.triggers.Add(entry6);
        }

        EndDialogue();
    }

    void TextOpen_THBChoice1(BaseEventData p)
    {
        Textbox.SetActive(true);
        Choicebox.SetActive(false);
        ChoiceThreeBtn.SetActive(false);

        _StartNum = _Num1;
    }

    void TextOpen_THBChoice2(BaseEventData p)
    {
        Textbox.SetActive(true);
        Choicebox.SetActive(false);
        ChoiceThreeBtn.SetActive(false);

        _StartNum = _Num2;
    }

    void TextOpen_THBChoice3(BaseEventData p)
    {
        Textbox.SetActive(true);
        Choicebox.SetActive(false);
        ChoiceThreeBtn.SetActive(false);

        _StartNum = _Num3;
    }

    void Fun_ClickOneBtn()
    {
        ClickBtnBox.SetActive(true);
        ClickOneBtn.SetActive(true);

        entry1.callback.RemoveAllListeners();
        OB_Btn1.triggers.Remove(entry1);

        string Text1 = dialogues[lineCount + 1].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");

        OB_txt_TextBtn1.text = Text1;

        Text1 = "";
        OB_txt_Btn1.text = "";

        StartCoroutine(TypeWriter());
        SettingUI(false);
    }

    void Fun_EndBtn()
    {
        string Text1 = dialogues[lineCount - 1].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");
        Text1 = Text1.Replace("ⓖ", "<color=#62A339>");
        Text1 = Text1.Replace("ⓦ", "</color>");

        OB_txt_Btn1.text = Text1;

        Text1 = "";

        EndDialogue();
    }

    void Fun_PopupTwoBtn_Btn()
    {
        PopupBox.SetActive(true);
        PopupTwoBtn.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        string Text2 = dialogues[lineCount + 1].contexts[contextCount];

        PT_txt_Choose1.text = Text1;
        PT_txt_Choose2.text = Text2;

        Text1 = "";
        Text2 = "";

        entry7.callback.RemoveAllListeners();
        entry7.callback.AddListener(PT_Back);

        if (dialogues[lineCount + 1].contexts[contextCount] == "돌아가기")
        {
            PT_Choose2.triggers.Remove(entry7);
            PT_Choose2.triggers.Add(entry7);
        }

        EndDialogue();
    }

    public void Fun_PopupTwoBtn_Text(string a)
    {
        txt_PT.text = a;
    }

    public void PT_Back(BaseEventData p)
    {
        PopupBox.SetActive(false);
        PopupTwoBtn.SetActive(false);
    }

    void Fun_Quiz_Small()
    {
        QuizBox.SetActive(true);
        Q_Small.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");
        Text1 = Text1.Replace("ⓖ", "<color=#62A339>");
        Text1 = Text1.Replace("ⓡ", "<color=#FF0000>");
        Text1 = Text1.Replace("ⓦ", "</color>");

        txt_QS.text = Text1;

        Text1 = "";

        EndDialogue();
    }

    void Fun_Quiz_medium()
    {
        QuizBox.SetActive(true);
        Q_Medium.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");
        Text1 = Text1.Replace("ⓖ", "<color=#62A339>");
        Text1 = Text1.Replace("ⓡ", "<color=#FF0000>");
        Text1 = Text1.Replace("ⓦ", "</color>");

        txt_QM.text = Text1;

        Text1 = "";

        EndDialogue();
    }
}