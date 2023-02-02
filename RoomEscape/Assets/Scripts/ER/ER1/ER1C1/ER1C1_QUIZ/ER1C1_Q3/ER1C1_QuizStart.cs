using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ER1C1_QuizStart : MonoBehaviour, IDropHandler
{
    Vector2 position;

    public GameObject erden;

    public GameObject sheep;
    public GameObject wolf;
    public GameObject grass;

    public static int erdenatstart = 1;

    void Awake()
    {
        position = erden.transform.localPosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = position;

            erdenatstart = 1;

            if (ER1C1_QuizDragAndDrop.sh == 4)
            {
                ER1C1_QuizDragAndDrop.sh = 2;

                sheep.transform.localPosition = new Vector2(330, 147);

                ER1C1_QuizAnswer.ss = false;
            }
            else if (ER1C1_QuizDragAndDrop.sh == 0)
            {
                sheep.transform.localPosition = new Vector2(245, 37);
            }

            if (ER1C1_QuizDragAndDrop.wo == 4)
            {
                ER1C1_QuizDragAndDrop.wo = 2;

                wolf.transform.localPosition = new Vector2(336, 140);

                ER1C1_QuizAnswer.ww = false;
            }

            if (ER1C1_QuizDragAndDrop.gr == 4)
            {
                ER1C1_QuizDragAndDrop.gr = 2;

                grass.transform.localPosition = new Vector2(324, 137);

                ER1C1_QuizAnswer.gg = false;
            }
        }
        else
        {
            erdenatstart = 0;
        }
    }
}