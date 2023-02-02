using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR1C2_Q2B : MonoBehaviour
{
    public Toggle man;

    public static bool AR1C2_Q2BCheck = false;

    public void OnDisable()
    {
        man.isOn = false;
    }

    public void ToggleClick(Toggle toggle)
    {
        if (toggle.isOn == true)
        {
            AR1C2_Q2BCheck = true;
        }
        else
        {
            AR1C2_Q2BCheck = false;
        }
    }
}