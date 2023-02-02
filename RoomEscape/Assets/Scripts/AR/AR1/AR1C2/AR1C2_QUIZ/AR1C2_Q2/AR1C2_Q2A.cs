using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR1C2_Q2A : MonoBehaviour
{
    public Toggle Woman;

    public static bool AR1C2_Q2ACheck = false;

    public void OnDisable()
    {
        Woman.isOn = false;
    }

    public void ToggleClick(Toggle toggle)
    {
        if (toggle.isOn == true)
        {
            AR1C2_Q2ACheck = true;
        }
        else
        {
            AR1C2_Q2ACheck = false;
        }
    }
}