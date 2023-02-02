using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class AR2C1_Drop : MonoBehaviour, IDropHandler
{
    Vector2 position = new(-860, 295);
    public static bool isusedkey = false;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().localPosition = position;
            isusedkey = true;
        }
    }
}