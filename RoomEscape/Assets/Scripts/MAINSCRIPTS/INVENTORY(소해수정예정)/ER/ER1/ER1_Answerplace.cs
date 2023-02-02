using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ER1_Answerplace : MonoBehaviour, IDropHandler
{
    Vector2 position = new(36, 333);

    public static bool isusedladder = false;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = position;
            isusedladder = true;
        }
    }
}