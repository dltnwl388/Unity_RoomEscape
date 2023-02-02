using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AR2_Dialogue
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
public class AR2_DialogueEvent
{
    public string name; 

    public Vector2 line; 
    public AR2_Dialogue[] dialogues; 
}