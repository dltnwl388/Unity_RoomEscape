using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER1C1_DoorMove : MonoBehaviour
{
    public GameObject BearDoor;

    public static bool StartMove = false;
    public static bool BackMove = false;

    void Update()
    {
        if (StartMove == true)
        {
            this.transform.position = this.transform.position + new Vector3(-5.15f, 0, 0) * Time.deltaTime * 1.2f;

            Invoke("StopMove1", 0.6f);
        }

        if (BackMove == true)
        {
            this.transform.position = new Vector3(5, 0, 0);

            StopMove2();
        }
    }

    void StopMove1()
    {
        StartMove = false;
    }

    void StopMove2()
    {
        BackMove = false;
    }
}