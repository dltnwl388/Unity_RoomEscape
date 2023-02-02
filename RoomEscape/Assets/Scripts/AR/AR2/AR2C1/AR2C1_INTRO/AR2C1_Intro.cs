using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class AR2C1_Intro : MonoBehaviour
{
    public GameObject OpeningTitle;

    public Text tx;
    public string writerText = "";
    int Num = 0;

    public GameObject Banner;
    public Text TopText;
    public Text BottomText;

    public GameObject Icons;

    public GameObject Q1;

    public EventTrigger TxtBtn;
    private EventTrigger.Entry entry;

    void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        TxtBtn.triggers.Add(entry);

        Icons.SetActive(false);
        Q1.SetActive(false);

        OpeningTitle.SetActive(true);

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
        AR2C1_MoveManager.Progress = 0;

        tx.text = "";

        Banner.SetActive(true);
        Icons.SetActive(true);

        TopText.text = "382. 나탈리스 왕국 상류층 문화 연구";
        BottomText.text = "제 1장. 입양된 공녀를 위한 지침";

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(IntroClick);
    }

    public void IntroClick(BaseEventData p)
    {
        OpeningTitle.SetActive(false);
        Banner.SetActive(false);

        Q1.SetActive(true);

        entry.callback.RemoveAllListeners();
        TxtBtn.triggers.Remove(entry);
    }

    IEnumerator _typing(string narration)
    {
        bool t_white = false, t_beige = false;
        bool t_ignore = false;

        writerText = "";

        for (int i = 0; i < narration.Length; i++)
        {
            switch (narration[i])
            {
                case 'ⓦ': t_white = true; t_beige = false; t_ignore = true; break;
                case 'ⓑ': t_white = false; t_beige = true; t_ignore = true; break;
            }

            string t_letter = narration[i].ToString();

            if (!t_ignore)
            {
                if (t_white) { t_letter = "<color=#FFFFFF>" + t_letter + "</color>"; }
                else if (t_beige) { t_letter = "<color=#E9CDBD>" + t_letter + "</color>"; }

                writerText += t_letter;
                tx.text = writerText;
            }
            t_ignore = false;

            yield return new WaitForSeconds(0.1f);
        }
        Num++;

        yield return new WaitForSeconds(0.8f);
    }

    IEnumerator TextArr()
    {
        yield return StartCoroutine(_typing("ⓑ낯선 방ⓦ에서 눈을 뜬 당신."));
        yield return StartCoroutine(_typing("상황을 파악하고\n그에 맞게 대처해보세요."));
        // yield return StartCoroutine(_typing("0"));
        // yield return StartCoroutine(_typing("1"));
    }
}