using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ER1C1_Intro : MonoBehaviour
{
    public GameObject OpeningTitle;

    public GameObject Txt;
    public Text tx;
    public string writerText = "";

    public GameObject Banner;
    public Text TopText;
    public Text BottomText;

    public GameObject PastureLand;
    public GameObject Hill;
    public GameObject SheepBasket_0;

    public EventTrigger TxtBtn;
    private EventTrigger.Entry entry;

    int Num = 0;

    void OnEnable()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        TxtBtn.triggers.Add(entry);

        OpeningTitle.SetActive(true);
        Txt.SetActive(true);

        StartCoroutine(TextArr());
    }

    void Update()
    {
        if (Num == 2)
        {
            entry.callback.AddListener(IntroStart);
        }
    }

    void IntroStart(BaseEventData p)
    {
        tx.text = "";

        Banner.SetActive(true);

        TopText.text = "840. 모험의 시작";
        BottomText.text = "마을에 양이 떠다닌다!?";

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(IntroClick);
    }

    void IntroClick(BaseEventData p)
    {
        ER1C1_MoveManager.Progress = 1;
        ER1C1_MoveManager.SheepBasket = 0;

        OpeningTitle.SetActive(false);
        Txt.SetActive(false);
        Banner.SetActive(false);

        PastureLand.SetActive(false);

        Hill.SetActive(true);
        SheepBasket_0.SetActive(true);

        entry.callback.RemoveAllListeners();
        TxtBtn.triggers.Remove(entry);
    }

    IEnumerator _typing(string narration)
    {
        bool t_white = false, t_green = false;
        bool t_ignore = false;

        writerText = "";

        for (int i = 0; i < narration.Length; i++)
        {
            switch (narration[i])
            {
                case 'ⓦ': t_white = true; t_green = false; t_ignore = true; break;
                case 'ⓖ': t_white = false; t_green = true; t_ignore = true; break;
            }

            string t_letter = narration[i].ToString();

            if (!t_ignore)
            {
                if (t_white) { t_letter = "<color=#FFFFFF>" + t_letter + "</color>"; }
                else if (t_green) { t_letter = "<color=#62A339>" + t_letter + "</color>"; }

                writerText += t_letter;
                tx.text = writerText;
            }
            t_ignore = false;

            yield return new WaitForSeconds(0.1f);
        }
        Num++;

        yield return new WaitForSeconds(0.7f);
    }

    IEnumerator TextArr()
    {
        yield return StartCoroutine(_typing("그런데 양들이... 사라졌다?"));
        yield return StartCoroutine(_typing("해가 지면 아주머니가 돌아옵니다.\n그 전까지 ⓖ양 8마리ⓦ를\n모두 찾아야 합니다!"));
        // yield return StartCoroutine(_typing("1"));
        // yield return StartCoroutine(_typing("2"));
    }
}