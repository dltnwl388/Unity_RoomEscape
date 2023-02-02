using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ER1_FailStatus : MonoBehaviour
{
    [SerializeField] GameObject ICONS;
    [SerializeField] GameObject ED_Fail;
    [SerializeField] EventTrigger Again;

    [SerializeField] GameObject ER1C1;

    [SerializeField] GameObject PastureLand_PM;
    [SerializeField] GameObject ER1C1_ToBird;
    [SerializeField] GameObject ER1C1_Cave;
    [SerializeField] GameObject ER1C1_Cliff;

    private EventTrigger.Entry entry;

    public static bool reset = false;

    private void OnEnable()
    {
        ICONS.SetActive(false);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback.AddListener(Fail);
        Again.triggers.Remove(entry);
        Again.triggers.Add(entry);

        if (ER1C1 != null)
        {
            ER1C1_DoorMove.BackMove = true;
        }
    }

    void Fail(BaseEventData p)
    {
        ICONS.SetActive(true);
        ED_Fail.SetActive(false);

        if (ER1C1 != null)
        {
            if (ER1C1.activeSelf == true)
            {
                ER1C1_Quizs();
            }
        }

        entry.callback.RemoveAllListeners();
    }

    void ER1C1_Quizs()
    {
        if (ER1C1_ToBird.activeSelf == true)
        {
            GameObject.Find("ER1C1_ToBird").GetComponent<ER1_InteractionController>().Text();
        }
        else if (ER1C1_Cave.activeSelf == true)
        {
            if (ER1C1_MoveManager.JustFail == true)
            {
                GameObject.Find("ER1C1_Cave").GetComponent<ER1_InteractionController>().Text();
            }
            else
            {
                if (!ER1C1_MoveManager.AllBack)
                {
                    ER1C1_MoveManager.instance.Restore_NoHoney();
                }
            }
        }
        else if (PastureLand_PM.activeSelf == true)
        {
            ER1C1_MoveManager.instance.All_Restore();
        }
        else if (ER1C1_Cliff.activeSelf == true)
        {
            reset = true;

            ER1C1_QuizAnswer.forfailwolfsheep = false;
            ER1C1_QuizAnswer.forfailsheepgrass = false;
            ER1C1_QuizDragAndDrop.GameOverCheck = false;

            ER1C1_MoveManager.instance.ER1C1_Cliff();
            ER1C1_QuizDragAndDrop.action2();
        }
    }
}