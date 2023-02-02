using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR2_Close : MonoBehaviour
{
    public GameObject I_E;
    public GameObject I_Diary;
    public GameObject I_Text;
    public GameObject I_explain;
    public GameObject I_X;

    public void ClickClose()
    {
        I_E.SetActive(false);
    }

    public void Clicktodiary()
    {
        I_Diary.SetActive(true);
        I_Text.SetActive(false);
        I_explain.SetActive(false);
        I_X.SetActive(false);
    }

    public void ClickDiary()
    {
        I_Diary.SetActive(false);
        I_Text.SetActive(true);
        I_explain.SetActive(true);
        I_X.SetActive(true);
    }
}