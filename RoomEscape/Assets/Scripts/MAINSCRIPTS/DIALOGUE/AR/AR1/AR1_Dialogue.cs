using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AR1_Dialogue
{
    [Tooltip("�̸�(���)")]
    public string name;

    [Tooltip("����")]
    public string[] contexts;

    [Tooltip("�̵���ȣ")]
    public string move;

    [Tooltip("��Ƽé��")]
    public string multi;

    [Tooltip("�̱�é��")]
    public string single;

    [Tooltip("����")]
    public string quiz;
}

[System.Serializable]
public class AR1_DialogueEvent
{
    public string name; 

    public Vector2 line; 
    public AR1_Dialogue[] dialogues; 
}