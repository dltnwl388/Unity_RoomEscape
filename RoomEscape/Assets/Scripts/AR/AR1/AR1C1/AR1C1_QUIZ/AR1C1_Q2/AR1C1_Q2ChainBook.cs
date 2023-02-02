using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR1C1_Q2ChainBook : MonoBehaviour
{
    // Main
    public GameObject MCB;
    public GameObject MCG;
    public GameObject MGP;
    public GameObject MGR;
    public GameObject MW1;
    public GameObject MW2;
    public GameObject MW3;
    public GameObject MW4;
    public GameObject MW5;
    public GameObject MW6;

    // Empty
    public GameObject ECB;
    public GameObject ECG;
    public GameObject EW1;

    // Ccase
    public GameObject CGP;
    public GameObject CGR;
    public GameObject CW3;
    public GameObject CW4;
    public GameObject CW5;
    public GameObject CW6;

    // Desk
    public GameObject DCB;
    public GameObject DCG;
    public GameObject DGP;
    public GameObject DGR;
    public GameObject DW1;
    public GameObject DW2;
    public GameObject DW3;
    public GameObject DW4;
    public GameObject DW5;
    public GameObject DW6;

    public void CBClick()
    {
        Destroy(MCB);
        Destroy(ECB);
        Destroy(DCB);
    }

    public void CGClick()
    {
        Destroy(MCG);
        Destroy(ECG);
        Destroy(DCG);
    }

    public void GPClick()
    {
        Destroy(MGP);
        Destroy(CGP);
        Destroy(DGP);
    }

    public void GRClick()
    {
        Destroy(MGR);
        Destroy(CGR);
        Destroy(DGR);
    }

    public void W1Click()
    {
        Destroy(MW1);
        Destroy(EW1);
        Destroy(DW1);
    }

    public void W2Click()
    {
        Destroy(MW2);
        Destroy(DW2);
    }

    public void W3Click()
    {
        Destroy(MW3);
        Destroy(CW3);
        Destroy(DW3);
    }

    public void W4Click()
    {
        Destroy(MW4);
        Destroy(CW4);
        Destroy(DW4);
    }

    public void W5Click()
    {
        Destroy(MW5);
        Destroy(CW5);
        Destroy(DW5);
    }

    public void W6Click()
    {
        Destroy(MW6);
        Destroy(CW6);
        Destroy(DW6);
    }
}