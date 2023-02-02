using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1_DialogueManager : MonoBehaviour
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
    [SerializeField] GameObject NoticeArrow;
    [SerializeField] GameObject EtcArrow;

    [SerializeField] Text txt_ARName;
    [SerializeField] Text txt_ARDialogue;
    [SerializeField] GameObject AR_Basic;
    [SerializeField] GameObject AR_Pouting;
    [SerializeField] GameObject AR_Curious;

    [SerializeField] Text txt_Notice;

    [SerializeField] Text txt_EtcName;
    [SerializeField] Text txt_EtcDialogue;
    [SerializeField] GameObject witness_basic;
    [SerializeField] GameObject witness_worry;

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
    [SerializeField] GameObject OB_Btn1_Btn;
    [SerializeField] EventTrigger OB_Btn1;
    [SerializeField] GameObject OB_Btn1_Btn_F;
    [SerializeField] Text OB_txt_TextBtn1;
    [SerializeField] Text OB_txt_TextBtn1_F;
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

    AR1_Dialogue[] dialogues;

    [SerializeField] GameObject AR1C1;
    [SerializeField] GameObject AR1C2;

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

    private void Start()
    {
        entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerClick;

        entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerClick;
    }

    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (AR1_DialogueButton.isBtnUp == true)
                {
                    isNext = false;
                    ER1_DialogueButton.isBtnUp = false;

                    txt_ARDialogue.text = "";
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
                                AR_Success.SetActive(true);

                                EndDialogue();
                            }
                            else if (AR1C1 != null)
                            {
                                if (AR1C1.activeSelf == true)
                                {
                                    AR1C1_lineCountEnd();
                                }
                            }
                            else if (AR1C2 != null)
                            {
                                if (AR1C2.activeSelf == true)
                                {
                                    AR1C2_lineCountEnd();
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

   void AR1C1_lineCountEnd()
    {
        if (dialogues[lineCount - 1].single == "AR1C1_BackBtn")
        {
            AR1C1_MoveManager.instance.AR1C1_BackBtnMGT();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR1C1_InventoryUnLock")
        {
            AR1C1_MoveManager.instance.AR1C1_InventoryUnLock();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C1_Q1_Check")
        {
            AR1C1_MoveManager.instance.AR1C1_Q1_Check();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR1C1_JustOneText")
        {
            AR1C1_MoveManager.instance.AR1C1_JustOneText();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C1_Q2")
        {
            AR1C1_MoveManager.instance.AR1C1_Q2();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR1C1_Calendar")
        {
            AR1C1_MoveManager.instance.AR1C1_Calendar();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR1C1_Paper")
        {
            AR1C1_MoveManager.instance.AR1C1_Paper();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR1C1_Confidential")
        {
            AR1C1_MoveManager.instance.AR1C1_Confidential();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C1_Q4Success")
        {
            AR1C1_MoveManager.instance.AR1C1_Q4Success();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C1_Q5")
        {
            AR1C1_MoveManager.instance.AR1C1_Q5();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C1_Q5Text")
        {
            AR1C1_MoveManager.instance.AR1C1_Q5Text();

            EndDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    void AR1C2_lineCountEnd()
    {
        if (dialogues[lineCount - 1].single == "AR1C2_ARSkill2_Add")
        {
            AR1C2_MoveManager.instance.AR1C2_ARSkill2_Add();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].single == "AR1C2_ARSkill3_Add")
        {
            AR1C2_MoveManager.instance.AR1C2_ARSkill3_Add();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C2_Q3")
        {
            AR1C2_MoveManager.instance.AR1C2_Q3();

            EndDialogue();
        }
        else if (dialogues[lineCount - 1].quiz == "AR1C2_Q4")
        {
            AR1C2_MoveManager.instance.AR1C2_Q4();

            EndDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    public void ShowDialogue(AR1_Dialogue[] p_dialogues, float a, float b)
    {
        isDialogue = true;

        txt_ARDialogue.text = "";
        txt_EtcDialogue.text = "";
        txt_Notice.text = "";
        txt_ARName.text = "";
        txt_EtcName.text = "";
        OB_txt_Choice1.text = "";
        TB_txt_Choice1.text = "";
        TB_txt_Choice2.text = "";
        OB_txt_Btn1.text = "";
        OB_txt_TextBtn1.text = "";
        OB_txt_TextBtn1_F.text = "";
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

        if (dialogues[lineCount].single == "ARSeated_Shadow")
        {
            AR1C2_MoveManager.instance.AR1C2_state(false, true);
        }

        if (dialogues[lineCount].move == "Success")
        {
            AR_Success.SetActive(true);

            EndDialogue();
        }
        else if (dialogues[lineCount].name == "Fail")
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
        else if (AR1C1 != null)
        {
            if (AR1C1.activeSelf == true)
            {
                AR1C1_ShowDialogue();
            }
        }
        else
        {
            StartCoroutine(TypeWriter());
        }
    }

    void AR1C1_ShowDialogue()
    {
        if (dialogues[lineCount].quiz == "AR1C1_Q1_Key")
        {
            AR1C1_MoveManager.instance.AR1C1_Q1_Key();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].quiz == "AR1C1_Q1_Paper")
        {
            AR1C1_MoveManager.instance.AR1C1_Q1_Paper();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "AR1C1_ToBanana")
        {
            AR1C1_MoveManager.instance.AR1C1_ToBanana();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "AR1C1_ToCream")
        {
            AR1C1_MoveManager.instance.AR1C1_ToCream();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "AR1C1_ToDoughnut")
        {
            AR1C1_MoveManager.instance.AR1C1_ToDoughnut();

            StartCoroutine(TypeWriter());
        }
        else if (dialogues[lineCount].single == "AR1C1_ToApple")
        {
            AR1C1_MoveManager.instance.AR1C1_ToApple();

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
                txt_EtcDialogue.text += t_letter;
                txt_Notice.text += t_letter;
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

        OB_Btn1_Btn_F.SetActive(false);
        OB_Btn1_Btn.SetActive(true);

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

            SettingItem();

            if (x >= y)
            {
                ArArrow.SetActive(false);
                NoticeArrow.SetActive(false);
                EtcArrow.SetActive(false);
            }
            else
            {
                ArArrow.SetActive(true);
                NoticeArrow.SetActive(true);
                EtcArrow.SetActive(true);

                x += 1;
            }

            if (dialogues[lineCount].name == "")
            {
                Ar.SetActive(false);
                Notice.SetActive(true);
                Etc.SetActive(false);

                OnlyTextbox();
            }
            else if (dialogues[lineCount].name == "직원" || dialogues[lineCount].name == "남자" || dialogues[lineCount].name == "여자" || dialogues[lineCount].name == "증인" || dialogues[lineCount].name == "진범")
            {
                Ar.SetActive(false);
                Notice.SetActive(false);
                Etc.SetActive(true);
                witness_basic.SetActive(false);
                witness_worry.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].multi == "witness_basic")
                {
                    witness_basic.SetActive(true);
                }
                else if (dialogues[lineCount].multi == "witness_worry")
                {
                    witness_worry.SetActive(true);
                }

                txt_EtcName.text = dialogues[lineCount].name;
            }
            else if (dialogues[lineCount].name == "아이란")
            {
                Ar.SetActive(true);
                AR_Basic.SetActive(false);
                AR_Pouting.SetActive(false);
                AR_Curious.SetActive(false);
                Notice.SetActive(false);
                Etc.SetActive(false);

                OnlyTextbox();

                if (dialogues[lineCount].multi == "AR_Pouting")
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

            if (dialogues[lineCount].single == "AR1C2_ARSkill_Shot")
            {
                AR1C2_MoveManager.instance.AR1C2_ARSkill_Shot();
            }
        }
        else if (p_flag == false)
        {
            DialogueBtn.SetActive(false);

            Textbox.SetActive(false);

            Ar.SetActive(false);
            Notice.SetActive(false);
            Etc.SetActive(false);

            ArArrow.SetActive(true);
            NoticeArrow.SetActive(true);
            EtcArrow.SetActive(true);
        }
    }

    public void SettingItem()
    {
        if (dialogues[lineCount].single == "AR1C2_ARShadow")
        {
            AR1C2_MoveManager.instance.AR1C2_state(false, true);
        }
        else if (dialogues[lineCount].single == "AR1C2_ARSeated")
        {
            AR1C2_MoveManager.instance.AR1C2_state(true, false);
        }
        else if (dialogues[lineCount].single == "AR1C2_ARShadow&Lipstic")
        {
            AR1C2_MoveManager.instance.AR1C2_state(false, true);

            AR1C2_MoveManager.instance.AR1C2_Lipstic_state(true);
        }
        else if (dialogues[lineCount].single == "AR1C2_ARSeated&NoLipstic")
        {
            AR1C2_MoveManager.instance.AR1C2_state(true, false);

            AR1C2_MoveManager.instance.AR1C2_Lipstic_state(false);
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

        if (dialogues[lineCount].single == "AR1C2_정보상이동")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C2_Move);
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

    void AR1C2_Move(BaseEventData p)
    {
        AR1C2_MoveManager.instance.AR1C2_StreetClick();
        GameObject.Find("AR1C2_INFO").GetComponent<AR1_InteractionController>().Text();
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

        OB_Btn1_Btn.SetActive(false);
        OB_Btn1_Btn_F.SetActive(true);

        string Text1 = dialogues[lineCount + 1].contexts[contextCount];
        Text1 = Text1.Replace("@", ",");
        Text1 = Text1.Replace("\\n", "\n");
        Text1 = Text1.Replace("\"", "");

        OB_txt_TextBtn1.text = Text1;
        OB_txt_TextBtn1_F.text = Text1;

        Text1 = "";
        OB_txt_Btn1.text = "";

        StartCoroutine(TypeWriter());
        SettingUI(false);

        if (dialogues[lineCount].single == "AR1C1_Popup")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C1_Popup);
            OB_Btn1.triggers.Remove(entry1);
            OB_Btn1.triggers.Add(entry1);
        }
        else if(dialogues[lineCount].quiz == "AR1C1_Q3")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C1_Q3);
            OB_Btn1.triggers.Remove(entry1);
            OB_Btn1.triggers.Add(entry1);
        }
        else if (dialogues[lineCount].quiz == "AR1C1_Q4")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C1_Q4);
            OB_Btn1.triggers.Remove(entry1);
            OB_Btn1.triggers.Add(entry1);
        }
        else if (dialogues[lineCount].quiz == "AR1C2_Q1")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C2_Q1);
            OB_Btn1.triggers.Remove(entry1);
            OB_Btn1.triggers.Add(entry1);
        }
        else if (dialogues[lineCount].quiz == "AR1C2_Q1End")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C2_Q1End);
            OB_Btn1.triggers.Remove(entry1);
            OB_Btn1.triggers.Add(entry1);
        }
        else
        {
            entry1.callback.RemoveAllListeners();
            OB_Btn1.triggers.Remove(entry1);
        }
    }

    void AR1C1_Popup(BaseEventData p)
    {
        AR1C1_MoveManager.instance.AR1C1_Popup();
    }

    void AR1C1_Q3(BaseEventData p)
    {
        AR1C1_MoveManager.instance.AR1C1_Q3();
    }

    void AR1C1_Q4(BaseEventData p)
    {
        AR1C1_MoveManager.instance.AR1C1_Q4();
    }

    void AR1C2_Q1(BaseEventData p)
    {
        AR1C2_MoveManager.instance.AR1C2_Q1();
    }

    void AR1C2_Q1End(BaseEventData p)
    {
        GameObject.Find("AR1C2_Quiz1").GetComponent<AR1C2_Q1>().NextNotice1();
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


        if (dialogues[lineCount].quiz == "AR1C1_Q5Result")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C1_Q5Result);
            PT_Choose1.triggers.Remove(entry1);
            PT_Choose1.triggers.Add(entry1);
        }
        else if (dialogues[lineCount].quiz == "AR1C2_Q5Door")
        {
            entry1.callback.RemoveAllListeners();
            entry1.callback.AddListener(AR1C2_Q5Door);
            PT_Choose1.triggers.Remove(entry1);
            PT_Choose1.triggers.Add(entry1);
        }
        else
        {
            entry1.callback.RemoveAllListeners();
            PT_Choose1.triggers.Remove(entry1);
        }


        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(PT_Back_Trigger);

        if (dialogues[lineCount + 1].contexts[contextCount] == "돌아가기")
        {
            PT_Choose2.triggers.Remove(entry2);
            PT_Choose2.triggers.Add(entry2);
        }

        EndDialogue();
    }

    void AR1C1_Q5Result(BaseEventData p)
    {
        AR1C1_MoveManager.instance.AR1C1_Q5Result();
    }

    void AR1C2_Q5Door(BaseEventData p)
    {
        AR1C2_MoveManager.instance.AR1C2_Q5Result();
    }

    public void Fun_PopupTwoBtn_Text(string a)
    {
        txt_PT.text = a;
    }

    public void PT_Back( )
    {
        if (AR1C1 != null)
        {
            if (AR1C1.activeSelf == true)
            {
                AR1C1_MoveManager.instance.AR1C1_Q5Cancle();
            }
        }
        else if (AR1C2 != null)
        {
            AR1C2_MoveManager.instance.AR1C2_Q5();
        }
   
        PopupBox.SetActive(false);
        PopupTwoBtn.SetActive(false);
    }

    public void PT_Back_Trigger(BaseEventData p)
    {
        if (AR1C1 != null)
        {
            if (AR1C1.activeSelf == true)
            {
                AR1C1_MoveManager.instance.AR1C1_Q5Cancle();
            }
        }
        else if (AR1C2 != null)
        {
            AR1C2_MoveManager.instance.AR1C2_Q5();
        }

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

         if (dialogues[lineCount].quiz == "AR1C1_Q1")
         {
            AR1C1_MoveManager.instance.AR1C1_Q1();
         }
         else if (dialogues[lineCount].quiz == "AR1C2_Q2")
         {
             AR1C2_MoveManager.instance.AR1C2_Q2();
         }
         else if (dialogues[lineCount].quiz == "AR1C2_Q5")
         {
             AR1C2_MoveManager.instance.AR1C2_Q5();
         }

         EndDialogue();
    }
}