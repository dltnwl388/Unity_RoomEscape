using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR2_DatabaseManager : MonoBehaviour
{
    public static AR2_DatabaseManager instance;

    [SerializeField] string csv_FileName;

    Dictionary<int, AR2_Dialogue> dialogueDic = new Dictionary<int, AR2_Dialogue>();

    public static bool isFinish = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            AR2_DialogueParser theParser = GetComponent<AR2_DialogueParser>();
            AR2_Dialogue[] dialogues = theParser.Parse(csv_FileName);

            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }

    public AR2_Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<AR2_Dialogue> dialogueList = new List<AR2_Dialogue>();

        for(int i = 0; i <= _EndNum - _StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum + i]);
        }
        return dialogueList.ToArray();
    }
}