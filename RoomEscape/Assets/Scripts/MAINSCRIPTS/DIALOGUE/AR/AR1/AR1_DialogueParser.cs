using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR1_DialogueParser : MonoBehaviour
{
    public AR1_Dialogue[] Parse(string _CSVFileName)
    {
        List<AR1_Dialogue> dialogueList = new List<AR1_Dialogue>(); 
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName);

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            AR1_Dialogue dialogue = new AR1_Dialogue(); 
            
            dialogue.name = row[1];
            dialogue.move = row[3];
            dialogue.multi = row[4];
            dialogue.single = row[5];
            dialogue.quiz = row[6];
            List<string> contextList = new List<string>();

            do
            {
                contextList.Add(row[2]);

                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            }while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }
        return dialogueList.ToArray();
    }
}