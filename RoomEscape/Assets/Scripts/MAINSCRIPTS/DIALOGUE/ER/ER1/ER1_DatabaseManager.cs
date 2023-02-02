using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER1_DatabaseManager : MonoBehaviour
{
    public static ER1_DatabaseManager instance;

    [SerializeField] string csv_FileName;

    Dictionary<int, ER1_Dialogue> dialogueDic = new Dictionary<int, ER1_Dialogue>();

    public static bool isFinish = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ER1_DialogueParser theParser = GetComponent<ER1_DialogueParser>();
            ER1_Dialogue[] dialogues = theParser.Parse(csv_FileName);

            for(int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(i + 1, dialogues[i]);
            }
            isFinish = true;
        }
    }

    public ER1_Dialogue[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<ER1_Dialogue> dialogueList = new List<ER1_Dialogue>();

        for(int i = 0; i <= _EndNum - _StartNum; i++)
        {
            dialogueList.Add(dialogueDic[_StartNum + i]);
        }
        return dialogueList.ToArray();
    }
}