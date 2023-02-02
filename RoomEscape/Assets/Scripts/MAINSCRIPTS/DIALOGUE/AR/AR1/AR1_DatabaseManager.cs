using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR1_DatabaseManager : MonoBehaviour
{
    public static AR1_DatabaseManager instance;

    [SerializeField] string csv_FileName;

    Dictionary<int, AR1_Dialogue> dialogueDic = new Dictionary<int, AR1_Dialogue>();

    public static bool isFinish = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            AR1_DialogueParser theParser = GetComponent<AR1_DialogueParser>();
            AR1_Dialogue[] dialogues = theParser.Parse(csv_FileName);

            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }

    public AR1_Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<AR1_Dialogue> dialogueList = new List<AR1_Dialogue>();

        for(int i = 0; i <= _EndNum - _StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum + i]);
        }
        return dialogueList.ToArray();
    }
}