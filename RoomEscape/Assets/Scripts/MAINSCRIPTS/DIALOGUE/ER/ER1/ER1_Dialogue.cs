using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ER1_Dialogue
{
    [Tooltip("이름(기능)")]
    public string name;

    [Tooltip("내용")]
    public string[] contexts;

    [Tooltip("이동번호")]
    public string move;

    [Tooltip("멀티챕터")]
    public string multi;

    [Tooltip("싱글챕터")]
    public string single;

    [Tooltip("퀴즈")]
    public string quiz;
}

[System.Serializable]
public class ER1_DialogueEvent
{
    public string name; 

    public Vector2 line; 
    public ER1_Dialogue[] dialogues; 
}