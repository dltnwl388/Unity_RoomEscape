using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1C1_Q2Put : MonoBehaviour
{
    public GameObject One_CB;
    public GameObject One_CG;
    public GameObject One_CP;
    public GameObject One_CR;
    public GameObject One_W1;
    public GameObject One_W2;
    public GameObject One_W3;
    public GameObject One_W4;
    public GameObject One_W5;
    public GameObject One_W6;

    public GameObject Two_CB;
    public GameObject Two_CG;
    public GameObject Two_CP;
    public GameObject Two_CR;
    public GameObject Two_W1;
    public GameObject Two_W2;
    public GameObject Two_W3;
    public GameObject Two_W4;
    public GameObject Two_W5;
    public GameObject Two_W6;

    public GameObject Three_CB;
    public GameObject Three_CG;
    public GameObject Three_CP;
    public GameObject Three_CR;
    public GameObject Three_W1;
    public GameObject Three_W2;
    public GameObject Three_W3;
    public GameObject Three_W4;
    public GameObject Three_W5;
    public GameObject Three_W6;

    public GameObject Fore_CB;
    public GameObject Fore_CG;
    public GameObject Fore_CP;
    public GameObject Fore_CR;
    public GameObject Fore_W1;
    public GameObject Fore_W2;
    public GameObject Fore_W3;
    public GameObject Fore_W4;
    public GameObject Fore_W5;
    public GameObject Fore_W6;

    public GameObject BookCase1;
    public GameObject BookCase2;
    public GameObject BookCase3;
    public GameObject BookCase4;

    public GameObject ItemCase1;
    public GameObject ItemCase2;
    public GameObject ItemCase3;
    public GameObject ItemCase4;

    public GameObject Block2;
    public GameObject Block3;
    public GameObject Block4;
    public GameObject Block5;
    public GameObject Block6;
    public GameObject Block7;
    public GameObject Block8;
    public GameObject Block9;
    public GameObject Block10;
    public GameObject Block11;

    public GameObject FPutBtn;
    public GameObject CPut;
    public GameObject FPutBtn_F;

    public GameObject Fail;
    public EventTrigger Again;

    bool a = true, b = true, c = true, d = true, e = true, f = true, g = true, h = true, i = true, j = true;

    public static Action action1;

    private EventTrigger.Entry entry;

    public void Awake()
    {
        action1 = () => { CancelBtn(); };
    }

    private void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
    }

    private void Update()
    {
        if (One_CP.activeSelf == true && Two_CG.activeSelf == true && Three_CB.activeSelf == true && Fore_CR.activeSelf == true)
        {
            CPut.SetActive(true);
            FPutBtn.SetActive(false);
            FPutBtn_F.SetActive(false);
        }
        else if (BookCase1.activeSelf == false && BookCase2.activeSelf == false && BookCase3.activeSelf == false && BookCase4.activeSelf == false)
        {
            CPut.SetActive(false);
            FPutBtn.SetActive(true);
            FPutBtn_F.SetActive(false);

            if (Fail.activeSelf == true)
            {
                entry.callback.RemoveAllListeners();
                entry.callback.AddListener(CancelBtn_Triggers);
                Again.triggers.Remove(entry);
                Again.triggers.Add(entry);
            }
        }
        else
        {
            CPut.SetActive(false);
            FPutBtn.SetActive(false);
            FPutBtn_F.SetActive(true);
        }
    }

    public void FindBookNum(string name)
    {
        int num = AR1_Inventory.FindIndex(name);

        if (num == 2 || a == false)
        {
            Block2.SetActive(true);

            a = false;
        }
        if (num == 3 || b == false)
        {
            Block3.SetActive(true);

            b = false;
        }
        if (num == 4 || c == false)
        {
            Block4.SetActive(true);

            c = false;
        }
        if (num == 5 || d == false)
        {
            Block5.SetActive(true);

            d = false;
        }
        if (num == 6 || e == false)
        {
            Block6.SetActive(true);

            e = false;
        }
        if (num == 7 || f == false)
        {
            Block7.SetActive(true);

            f = false;
        }
        if (num == 8 || g == false)
        {
            Block8.SetActive(true);

            g = false;
        }
        if (num == 9 || h == false)
        {
            Block9.SetActive(true);

            h = false;
        }
        if (num == 10 || i == false)
        {
            Block10.SetActive(true);

            i = false;
        }
        if (num == 11 || j == false)
        {
            Block11.SetActive(true);

            j = false;
        }
    }

    public void PutBook()
    {
        int num = AR1_Slot.Putnum;

        AR1_OpenClose.actionT();

        AR1C1_MoveManager.instance.AR1C1_BackBtnAT();

        if (ItemCase1.activeSelf == false)
        {
            if (num == 1)
            {
                One_CB.SetActive(true); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectBlue");
            }
            if (num == 2)
            {
                One_CB.SetActive(false); One_CG.SetActive(true); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectGreen");
            }
            if (num == 3)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(true); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectPurple");
            }
            if (num == 4)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(true);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectRed");
            }
            if (num == 5)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(true); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong1");
            }
            if (num == 6)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(true); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong2");
            }
            if (num == 7)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(true); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong3");
            }
            if (num == 8)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(true); One_W5.SetActive(false); One_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong4");
            }
            if (num == 9)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(true); One_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong5");
            }
            if (num == 10)
            {
                One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
                One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(true);

                FindBookNum("AR1C1_Wrong6");
            }
            BookCase1.SetActive(false);
            ItemCase1.SetActive(true);
        }

        if (ItemCase2.activeSelf == false)
        {
            if (num == 1)
            {
                Two_CB.SetActive(true); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectBlue");
            }
            if (num == 2)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(true); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectGreen");
            }
            if (num == 3)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(true); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectPurple");
            }
            if (num == 4)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(true);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectRed");
            }
            if (num == 5)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(true); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong1");
            }
            if (num == 6)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(true); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong2");
            }
            if (num == 7)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(true); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong3");
            }
            if (num == 8)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(true); Two_W5.SetActive(false); Two_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong4");
            }
            if (num == 9)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(true); Two_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong5");
            }
            if (num == 10)
            {
                Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
                Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(true);

                FindBookNum("AR1C1_Wrong6");
            }
            BookCase2.SetActive(false);
            ItemCase2.SetActive(true);
        }

        if (ItemCase3.activeSelf == false)
        {
            if (num == 1)
            {
                Three_CB.SetActive(true); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectBlue");
            }
            if (num == 2)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(true); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectGreen");
            }
            if (num == 3)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(true); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectPurple");
            }
            if (num == 4)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(true);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectRed");
            }
            if (num == 5)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(true); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong1");
            }
            if (num == 6)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(true); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong2");
            }
            if (num == 7)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(true); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong3");
            }
            if (num == 8)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(true); Three_W5.SetActive(false); Three_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong4");
            }
            if (num == 9)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(true); Three_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong5");
            }
            if (num == 10)
            {
                Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
                Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(true);

                FindBookNum("AR1C1_Wrong6");
            }
            BookCase3.SetActive(false);
            ItemCase3.SetActive(true);
        }

        if (ItemCase4.activeSelf == false)
        {
            if (num == 1)
            {
                Fore_CB.SetActive(true); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectBlue");
            }
            if (num == 2)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(true); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectGreen");
            }
            if (num == 3)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(true); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectPurple");
            }
            if (num == 4)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(true);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_CorrectRed");
            }
            if (num == 5)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(true); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong1");
            }
            if (num == 6)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(true); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong2");
            }
            if (num == 7)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(true); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong3");
            }
            if (num == 8)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(true); Fore_W5.SetActive(false); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong4");
            }
            if (num == 9)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(true); Fore_W6.SetActive(false);

                FindBookNum("AR1C1_Wrong5");
            }
            if (num == 10)
            {
                Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
                Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(true);

                FindBookNum("AR1C1_Wrong6");
            }
            BookCase4.SetActive(false);
            ItemCase4.SetActive(true);
        }
    }

    public void BookCase1Click()
    {
        ItemCase1.SetActive(false);
    }

    public void BookCase2Click()
    {
        ItemCase2.SetActive(false);
    }

    public void BookCase3Click()
    {
        ItemCase3.SetActive(false);
    }

    public void BookCase4Click()
    {
        ItemCase4.SetActive(false);
    }

    public void CancelBtn()
    {
        One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
        One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);
        BookCase1.SetActive(true); ItemCase1.SetActive(true);

        Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
        Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);
        BookCase2.SetActive(true); ItemCase2.SetActive(true);

        Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
        Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);
        BookCase3.SetActive(true); ItemCase3.SetActive(true);

        Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
        Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);
        BookCase4.SetActive(true); ItemCase4.SetActive(true);

        Block2.SetActive(false); Block3.SetActive(false); Block4.SetActive(false); Block5.SetActive(false); Block6.SetActive(false); 
        Block7.SetActive(false); Block8.SetActive(false); Block9.SetActive(false); Block10.SetActive(false);Block11.SetActive(false);

        a = true; b = true; c = true; d = true; e = true; f = true; g = true; h = true; i = true; j = true;

        AR1_OpenClose.actionT();

        AR1C1_MoveManager.instance.AR1C1_BackBtnMGT();

        entry.callback.RemoveAllListeners();
        Again.triggers.Remove(entry);
    }

    public void CancelBtn_Triggers(BaseEventData p)
    {
        One_CB.SetActive(false); One_CG.SetActive(false); One_CP.SetActive(false); One_CR.SetActive(false);
        One_W1.SetActive(false); One_W2.SetActive(false); One_W3.SetActive(false); One_W4.SetActive(false); One_W5.SetActive(false); One_W6.SetActive(false);
        BookCase1.SetActive(true); ItemCase1.SetActive(true);

        Two_CB.SetActive(false); Two_CG.SetActive(false); Two_CP.SetActive(false); Two_CR.SetActive(false);
        Two_W1.SetActive(false); Two_W2.SetActive(false); Two_W3.SetActive(false); Two_W4.SetActive(false); Two_W5.SetActive(false); Two_W6.SetActive(false);
        BookCase2.SetActive(true); ItemCase2.SetActive(true);

        Three_CB.SetActive(false); Three_CG.SetActive(false); Three_CP.SetActive(false); Three_CR.SetActive(false);
        Three_W1.SetActive(false); Three_W2.SetActive(false); Three_W3.SetActive(false); Three_W4.SetActive(false); Three_W5.SetActive(false); Three_W6.SetActive(false);
        BookCase3.SetActive(true); ItemCase3.SetActive(true);

        Fore_CB.SetActive(false); Fore_CG.SetActive(false); Fore_CP.SetActive(false); Fore_CR.SetActive(false);
        Fore_W1.SetActive(false); Fore_W2.SetActive(false); Fore_W3.SetActive(false); Fore_W4.SetActive(false); Fore_W5.SetActive(false); Fore_W6.SetActive(false);
        BookCase4.SetActive(true); ItemCase4.SetActive(true);

        Block2.SetActive(false); Block3.SetActive(false); Block4.SetActive(false); Block5.SetActive(false); Block6.SetActive(false);
        Block7.SetActive(false); Block8.SetActive(false); Block9.SetActive(false); Block10.SetActive(false); Block11.SetActive(false);

        a = true; b = true; c = true; d = true; e = true; f = true; g = true; h = true; i = true; j = true;

        AR1_OpenClose.actionT();

        AR1C1_MoveManager.instance.AR1C1_BackBtnMGT();

        entry.callback.RemoveAllListeners();
        Again.triggers.Remove(entry);
    }
}