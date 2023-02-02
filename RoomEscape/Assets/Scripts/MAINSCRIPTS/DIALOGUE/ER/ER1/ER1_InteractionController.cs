using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ER1_InteractionController : MonoBehaviour
{
    [SerializeField] ER1_DialogueEvent dialogue;

    public static bool isCollide = false;

    ER1_DialogueManager theDM;

    void Start()
    {
        theDM = FindObjectOfType<ER1_DialogueManager>();
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

    public ER1_Dialogue[] GetDialogue()
    {
        dialogue.dialogues = ER1_DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);

        return dialogue.dialogues;
    }
}