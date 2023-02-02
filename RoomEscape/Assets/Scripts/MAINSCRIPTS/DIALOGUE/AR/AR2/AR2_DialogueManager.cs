using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR2_DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject DialogueBtn;

    [SerializeField] GameObject Textbox;
    [SerializeField] GameObject Choicebox;
    [SerializeField] GameObject ClickBtnBox;
    [SerializeField] GameObject PopupBox;
    [SerializeField] GameObject QuizBox;

    [SerializeField] GameObject AR_Fail;
    [SerializeField] GameObject AR_Success;

    [SerializeField] GameObject Ar;
    [SerializeField] GameObject Maid;
    [SerializeField] GameObject Butler;
    [SerializeField] GameObject Notice;
    [SerializeField] GameObject Etc;
    [SerializeField] GameObject ChoiceOneBtn;
    [SerializeField] GameObject ChoiceTwoBtn;
    [SerializeField] GameObject ClickOneBtn;
    [SerializeField] GameObject PopupTwoBtn;
    [SerializeField] GameObject Q_Small;
    [SerializeField] GameObject Q_Medium;

    [SerializeField] Text txt_Fail;

    [SerializeField] GameObject ArArrow;
    [SerializeField] GameObject MaidArrow;
    [SerializeField] GameObject ButlerArrow;
    [SerializeField] GameObject NoticeArrow;
    [SerializeField] GameObject EtcArrow;

    [SerializeField] Text txt_ARName;
    [SerializeField] Text txt_ARDialogue;
    [SerializeField] GameObject AR_Basic;
    [SerializeField] GameObject AR_Childhood;
    [SerializeField] GameObject AR_Childhood_Sad;
    [SerializeField] GameObject AR_Childhood_Curious;
    [SerializeField] GameObject AR_Pouting;
    [SerializeField] GameObject AR_Curious;

    [SerializeField] GameObject TextBox_Maid;
    [SerializeField] Text txt_MaidName;
    [SerializeField] Text txt_MaidDialogue;
    [SerializeField] GameObject Maid_Basic;
    [SerializeField] GameObject Maid_Basic_Big;
    [SerializeField] GameObject Maid_Smile;
    [SerializeField] GameObject Maid_Smile_Big;

    [SerializeField] GameObject TextBox_Butler;
    [SerializeField] Text txt_ButlerName;
    [SerializeField] Text txt_ButlerDialogue;
    [SerializeField] GameObject Butler_Basic;
    [SerializeField] GameObject Butler_Basic_Big;

    [SerializeField] Text txt_Notice;

    [SerializeField] Text txt_EtcName;
    [SerializeField] Text txt_EtcDialogue;
    [SerializeField] GameObject Boy_Basic;
    [SerializeField] GameObject Boy_Angry;

    [SerializeField] EventTrigger OB_Choice1;
    [SerializeField] Button OB_Choice1_Btn;
    [SerializeField] Text OB_txt_Choice1;

    [SerializeField] EventTrigger TB_Choice1;
    [SerializeField] Button TB_Choice1_Btn;
    [SerializeField] EventTrigger TB_Choice2;
    [SerializeField] Button TB_Choice2_Btn;
    [SerializeField] Text TB_txt_Choice1;
    [SerializeField] Text TB_txt_Choice2;

    [SerializeField] Text OB_txt_Btn1;
    [SerializeField] EventTrigger OB_Btn1;
    [SerializeField] Button OB_Btn1_Btn;
    [SerializeField] Text OB_txt_TextBtn1;

    [SerializeField] Text txt_PT;
    [SerializeField] EventTrigger PT_Choose1;
    [SerializeField] Button PT_Choose1_Btn;
    [SerializeField] Text PT_txt_Choose1;
    [SerializeField] EventTrigger PT_Choose2;
    [SerializeField] Button PT_Choose2_Btn;
    [SerializeField] Text PT_txt_Choose2;

    [SerializeField] Text txt_QS;
    [SerializeField] Text txt_QM;

    AR2_Dialogue[] dialogues;

    [SerializeField] GameObject AR2C1;

    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;

    bool isDialogue = false;
    bool isNext = false;

    int lineCount = 0;
    int contextCount = 0;

    float x = 0, y = 0;

    [Header("텍스트 출력 딜레이")]
    [SerializeField] float textDelay;

    int _StartNum = 0;
    int _Num1 = 0, _Num2 = 0;

    public static int Checknum = 0;

    bool GunAdd = false;

    private void Start()
    {
        entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerClick;

        entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerClick;
    }

    void Update()
    {
        if (isNext)
        {
            if (isDialogue)
            {
                if (AR2_DialogueButton.isBtnUp == true)
                {        
                    isNext = false;
                    ER1_DialogueButton.isBtnUp = false;

                    txt_ARDialogue.text = "";
                    txt_MaidDialogue.text = "";
                    txt_ButlerDialogue.text = "";
                    txt_EtcDialogue.text = "";
                    txt_Notice.text = "";
                    OB_txt_Btn1.text = "";

                    if (++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else if (lineCount + 1 == y)
                    {
                        EndDialogue();
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
                                Fun_ChoiceTwoBtn();
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
                                Fun_Fail();
                            }
                            else if (dialogues[lineCount - 1].move == "Success")
                            {
                                AR_Success.SetActive(true);

                                EndDialogue();
                            }
                            else if (AR2C1 != null)
                            {
                                if (AR2C1.activeSelf == true)
                                {
                                    AR2C1_lineCountIng();
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

                            if (dialogues[lineCount - 1].multi == "AR2_분기점1")
                            {
                                GunAdd = true;
                            }

                            if (dialogues[lineCount - 1].name == "Fail")
                            {
                                Fun_Fail();
                            }
                            else if (dialogues[lineCount - 1].move == "Success")
                            {
                                AR_Success.SetActive(true);

                                EndDialogue();
                            }
                            else if (AR2C1 != null)
                            {
                                if (AR2C1.activeSelf == true)
                                {
                                    AR2C1_lineCountEnd();
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

    void AR2C1_lineCountIng()
    {
        if (dialogues[lineCount - 1].single == "AR2C1_Clover2")
        {
            AR2C1_MoveManager.instance.AR2C1_Clover2();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_Spade5")
        {
            AR2C1_MoveManager.instance.AR2C1_Spade5();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_OldBook")
        {
            AR2C1_MoveManager.instance.AR2C1_OldBook();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].quiz == "AR2C1_QHFail")
        {
            AR2C1_MoveManager.instance.AR2C1_QHFail();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_HallwayA_2")
        {
            AR2C1_MoveManager.instance.AR2C1_HallwayA_2();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_HallwayB_1")
        {
            AR2C1_MoveManager.instance.AR2C1_HallwayB_1();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_EventAB")
        {
            AR2C1_MoveManager.instance.AR2C1_EventAB();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_AdoptDocument")
        {
            AR2C1_MoveManager.instance.AR2C1_AdoptDocument_Closed();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount - 1].single == "AR2C1_Diary")
        {
            AR2C1_MoveManager.instance.AR2C1_Diary();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "AR2C1_IntroRoom")
        {
            AR2C1_MoveManager.instance.AR2C1_IntroRoom();

            StartCoroutine(TypeWriter());
        }
        else
        {
            StartCoroutine(TypeWriter());
        }
    }

    void AR2C1_lineCountEnd()
    {
         if (dialogues[lineCount - 1].single == "AR2C1_C2Add")
         {
             AR2C1_MoveManager.instance.AR2C1_C2Add();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_Letter")
         {
             AR2C1_MoveManager.instance.AR2C1_AddLetter();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_S5Add")
         {
             AR2C1_MoveManager.instance.AR2C1_S5Add();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_BackBtn")
         {
             AR2C1_MoveManager.instance.BackBtnMGT();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_OldBookAdd")
         {
             AR2C1_MoveManager.instance.AR2C1_OldBookAdd();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_H3Add")
         {
             AR2C1_MoveManager.instance.AR2C1_H3Add();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_LampOn")
         {
             AR2C1_MoveManager.instance.AR2C1_LampOn();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_D7Add")
         {
             AR2C1_MoveManager.instance.AR2C1_D7Add();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].quiz == "AR2C1_Q2Event")
         {
             AR2C1_MoveManager.instance.AR2C1_Q2Event();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].quiz == "AR2C1_Q2Event_End")
         {
             AR2C1_MoveManager.instance.AR2C1_Q2Event_End();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_Box")
         {
             AR2C1_MoveManager.instance.AR2C1_Box2();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_EventAB")
         {
             AR2C1_MoveManager.instance.AR2C1_EventAB();

             EndDialogue();
         }
         else if (dialogues[lineCount - 1].single == "AR2C1_DiaryContent")
         {
             AR2C1_MoveManager.instance.AR2C1_DiaryContent();

             EndDialogue();
         }
        else
        {
            EndDialogue();
        }
    }

    public void ShowDialogue(AR2_Dialogue[] p_dialogues, float a, float b)
    {
        isDialogue = true;

        txt_ARDialogue.text = "";
        txt_MaidDialogue.text = "";
        txt_ButlerDialogue.text = "";
        txt_EtcDialogue.text = "";
        txt_Notice.text = "";
        txt_ARName.text = "";
        txt_MaidName.text = "";
        txt_ButlerName.text = "";
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

        if (dialogues[lineCount].quiz == "AR2C1_QHiddenOK")
        {
            AR2C1_MoveManager.instance.BackBtnMGF();
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
        else if (dialogues[lineCount].single == "AR2C1_HallwayA_1")
        {
            AR2C1_MoveManager.instance.AR2C1_HallwayA_1();

            EndDialogue(); 
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

        bool t_white = false, t_red = false, t_beige = false;
        bool t_italic = false;
        bool t_ignore = false;

        for (int i = 0; i < t_ReplaceText.Length; i++)
        {
            isNext = false;

            switch (t_ReplaceText[i])
            {
                case 'ⓡ': t_white = false; t_red = true; t_beige = false; t_italic = false; t_ignore = true; break;
                case 'ⓦ': t_white = true; t_red = false; t_beige = false; t_italic = false; t_ignore = true; break;
                case 'ⓑ': t_white = false; t_red = false; t_beige = true; t_italic = false; t_ignore = true; break;
                case 'ⓘ': t_white = false; t_red = false; t_beige = false; t_italic = true; t_ignore = true; break;
            }

            string t_letter = t_ReplaceText[i].ToString();

            if (!t_ignore)
            {
                if (t_red) { t_letter = "<color=#FF0000>" + t_letter + "</color>"; }
                else if (t_white) { t_letter = "<color=#FFFFFF>" + t_letter + "</color>"; }
                else if (t_beige) { t_letter = "<color=#E9CDBD>" + t_letter + "</color>"; }
                else if (t_italic) { t_letter = "<i>" + t_letter + "</i>"; }

                txt_ARDialogue.text += t_letter;
                txt_MaidDialogue.text += t_letter;
                txt_ButlerDialogue.text += t_letter;
                txt_EtcDialogue.text += t_letter;
                txt_Notice.text += t_letter;
                OB_txt_Btn1.text += t_letter;
            }
            t_ignore = false;

            yield return new WaitForSeconds(textDelay);
        }

        OB_Btn1_Btn.interactable = true;

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
                ArArrow.SetActive(false);
                MaidArrow.SetActive(false);
                ButlerArrow.SetActive(false);
                NoticeArrow.SetActive(false);
                EtcArrow.SetActive(false);
            }
            else
            {
                ArArrow.SetActive(true);
                MaidArrow.SetActive(true);
                ButlerArrow.SetActive(true);
                NoticeArrow.SetActive(true);
                EtcArrow.SetActive(true);

                x += 1;
            }

            if (dialogues[lineCount].name == "")
            {
                Ar.SetActive(false);
                Maid.SetActive(false);
                Butler.SetActive(false);
                Notice.SetActive(true);
                Etc.SetActive(false);

                if (dialogues[lineCount].single == "AR2C1_Hallway")
                {
                    AR2C1_MoveManager.instance.AR2C1_Hallway();
                }

                OnlyTextbox();
            }
            else if (dialogues[lineCount].name == "조연")
            {
                Ar.SetActive(false);
                Maid.SetActive(false);
                Butler.SetActive(false);
                Notice.SetActive(false);
                Etc.SetActive(true);
                Boy_Basic.SetActive(false);
                Boy_Angry.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].multi == "Boy_Basic")
                {
                    Boy_Basic.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "Boy_Angry")
                {
                    Boy_Angry.SetActive(true);
                }

                txt_EtcName.text = dialogues[lineCount].name;
            }
            else if (dialogues[lineCount].name == "아이란")
            {
                Ar.SetActive(true);
                AR_Childhood.SetActive(false);
                AR_Childhood_Sad.SetActive(false);
                AR_Childhood_Curious.SetActive(false);
                AR_Basic.SetActive(false);
                AR_Pouting.SetActive(false);
                AR_Curious.SetActive(false);
                Maid.SetActive(false);
                Butler.SetActive(false);
                Notice.SetActive(false);
                Etc.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].multi == "AR_Childhood")
                {
                    AR_Childhood.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "AR_Childhood_Sad")
                {
                    AR_Childhood_Sad.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "AR_Childhood_Curious")
                {
                    AR_Childhood_Curious.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "AR_Pouting")
                {
                    AR_Basic.SetActive(true);
                    AR_Pouting.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "AR_Curious")
                {
                    AR_Basic.SetActive(true);
                    AR_Curious.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "AR_No")
                {
                    AR_Basic.SetActive(false);
                }
                else
                {
                    AR_Basic.SetActive(true);
                }

                txt_ARName.text = dialogues[lineCount].name;
            }
            else if (dialogues[lineCount].name == "하녀" || dialogues[lineCount].name == "첼리")
            {
                Ar.SetActive(false);
                Maid.SetActive(true);
                Maid_Basic.SetActive(false);
                Maid_Basic_Big.SetActive(false);
                Maid_Smile.SetActive(false);
                Maid_Smile_Big.SetActive(false);
                Butler.SetActive(false);
                Notice.SetActive(false);
                Etc.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].contexts[contextCount] == "__X__")
                {
                    TextBox_Maid.SetActive(false);
                }
                else
                {
                    TextBox_Maid.SetActive(true);
                }

                if (dialogues[lineCount].multi == "Maid_Basic")
                {
                    Maid_Basic.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "Maid_Smile")
                {
                    Maid_Smile.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "Maid_Basic_Big")
                {
                    Maid_Basic_Big.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "Maid_Smile_Big")
                {
                    Maid_Smile_Big.SetActive(true);
                }

                txt_MaidName.text = dialogues[lineCount].name;
            }
            else if (dialogues[lineCount].name == "집사장")
            {
                Ar.SetActive(false);
                Maid.SetActive(false);
                Butler.SetActive(true);
                Butler_Basic.SetActive(false);
                Butler_Basic_Big.SetActive(false);
                Notice.SetActive(false);
                Etc.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].contexts[contextCount] == "__X__")
                {
                    TextBox_Butler.SetActive(false);
                }
                else
                {
                    TextBox_Butler.SetActive(true);
                }

                if (dialogues[lineCount].multi == "Butler_Basic")
                {
                    Butler_Basic.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "Butler_Basic_Big")
                {
                    Butler_Basic_Big.SetActive(true);
                }

                txt_ButlerName.text = dialogues[lineCount].name;
            }
        }
        else if (p_flag == false)
        {
            DialogueBtn.SetActive(false);

            Textbox.SetActive(false);

            Ar.SetActive(false);
            Maid.SetActive(false);
            Butler.SetActive(false);
            Notice.SetActive(false);
            Etc.SetActive(false);

            ArArrow.SetActive(true);
            MaidArrow.SetActive(true);
            ButlerArrow.SetActive(true);
            NoticeArrow.SetActive(true);
            EtcArrow.SetActive(true);
        }
    }

    void Fun_Fail()
    {
        AR_Fail.SetActive(true);

        string Text1 = dialogues[lineCount].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");
        Text1 = Text1.Replace("ⓑ", "<color=#E9CDBD>");
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

        if (dialogues[lineCount].single == "AR2C1_방")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR2C1_Q1Room2);
            OB_Choice1.triggers.Remove(entry1);
            OB_Choice1.triggers.Add(entry1);
        }
        else if(dialogues[lineCount].single == "AR2C1_EventB_1")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR2C1_EventB_1);
            OB_Choice1.triggers.Remove(entry1);
            OB_Choice1.triggers.Add(entry1);
        }
        else
        {
            entry1.callback.RemoveAllListeners();
            OB_Choice1.triggers.Remove(entry1);
        }

        EndDialogue();
    }

    void AR2C1_Q1Room2(BaseEventData p)
    {
        AR2C1_MoveManager.instance.AR2C1_Q1Room2();
    }

    void AR2C1_EventB_1(BaseEventData p)
    {
        AR2C1_MoveManager.instance.AR2C1_EventB_1();
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

        if (dialogues[lineCount].multi == "Text")
        {
            _Num1 = int.Parse(dialogues[lineCount].move);
            _Num2 = int.Parse(dialogues[lineCount + 1].move);

            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(TextOpen_TBChoice1);
            TB_Choice1.triggers.Remove(entry1);
            TB_Choice1.triggers.Add(entry1);


            entry2.callback.RemoveAllListeners();
            entry2.callback.AddListener(TextOpen_TBChoice2);
            TB_Choice2.triggers.Remove(entry2);
            TB_Choice2.triggers.Add(entry2);
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

    void Fun_ClickOneBtn()
    {
        ClickBtnBox.SetActive(true);
        ClickOneBtn.SetActive(true);

        OB_Btn1_Btn.interactable = false;

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
        Text1 = Text1.Replace("ⓑ", "<color=#E9CDBD>");
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

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(PT_Back);

        if (dialogues[lineCount + 1].contexts[contextCount] == "돌아가기")
        {
            PT_Choose2.triggers.Remove(entry1);
            PT_Choose2.triggers.Add(entry1);
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
        Text1 = Text1.Replace("ⓑ", "<color=#E9CDBD>");
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
        Text1 = Text1.Replace("ⓑ", "<color=#E9CDBD>");
        Text1 = Text1.Replace("ⓡ", "<color=#FF0000>");
        Text1 = Text1.Replace("ⓦ", "</color>");

        txt_QM.text = Text1;

        Text1 = "";

        EndDialogue();
    }
}