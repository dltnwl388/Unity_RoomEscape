using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR2C1_Dia7Move : MonoBehaviour
{
    bool StartMove = false;
    bool MoveCheck = false;

    void Update()
    {
        if (StartMove == true)
        {
            this.transform.position = this.transform.position + new Vector3(0, -1, 0) * Time.deltaTime * 1.5f;

            Invoke("StopDia7Move", 0.6f);
        }
    }

    void OnEnable()
    {
        if (MoveCheck == false)
        {
            StartMove = true;
            MoveCheck = true;
        }
    }

    void StopDia7Move()
    {
        StartMove = false;
    }
}