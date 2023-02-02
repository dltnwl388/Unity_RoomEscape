using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AR2_InteractionController : MonoBehaviour
{
    [SerializeField] AR2_DialogueEvent dialogue;

    public static bool isCollide = false;

    AR2_DialogueManager theDM;

    void Start()
    {
        theDM = FindObjectOfType<AR2_DialogueManager>();
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

    public AR2_Dialogue[] GetDialogue()
    {
        dialogue.dialogues = AR2_DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);

        return dialogue.dialogues;
    }
}