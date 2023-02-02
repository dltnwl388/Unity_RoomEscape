using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AR1_InteractionController : MonoBehaviour
{
    [SerializeField] AR1_DialogueEvent dialogue;

    public static bool isCollide = false;

    AR1_DialogueManager theDM;

    void Start()
    {
        theDM = FindObjectOfType<AR1_DialogueManager>();
    }

    public void Text()
    {
        isCollide = true;
        StartCoroutine(TextClick());
    }

    IEnumerator TextClick()
    {
        yield return new WaitUntil(() => isCollide);
        isCollide = false;
        
        theDM.ShowDialogue(GetDialogue(), dialogue.line.x, dialogue.line.y);
    }

    public AR1_Dialogue[] GetDialogue()
    {
        dialogue.dialogues = AR1_DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);

        return dialogue.dialogues;
    }
}