using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ER1_DialogueButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static bool isBtnUp = false;

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnUp = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnUp = true;
    }

    public void OnDisable()
    {
        isBtnUp = false;
    }
}