using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AR1C2_Intro : MonoBehaviour
{
    public GameObject OpeningTitle;

    public Text tx;
    public string writerText = "";
    int Num = 0;

    public GameObject Banner;
    public Text TopText;
    public Text BottomText;

    public GameObject Icons;

    public GameObject img1;
    public GameObject img2;

    public GameObject Intro;
    public GameObject Street;

    public EventTrigger TxtBtn;
    private EventTrigger.Entry entry;

    void OnEnable()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        TxtBtn.triggers.Add(entry);

        AR1_OpenClose.actionF();

        Icons.SetActive(false);

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
        AR1C2_MoveManager.Progress = 0;

        tx.text = "";

        Intro.SetActive(false);

        Banner.SetActive(true);
        Icons.SetActive(true);
        Street.SetActive(true);

        TopText.text = "364. Ǫ�� ������ ���";
        BottomText.text = "������� 4����. �ʺ긮�� �Ÿ�";

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(Text1);
    }

    void Text1(BaseEventData p)
    {
        IntroClick();
        GameObject.Find("AR1C2_STREET").GetComponent<AR1_InteractionController>().Text();
    }

    void IntroClick()
    {
        AR1_OpenClose.actionT();

        OpeningTitle.SetActive(false);
        Banner.SetActive(false);

        entry.callback.RemoveAllListeners();
        TxtBtn.triggers.Remove(entry);
    }

    IEnumerator _typing(string narration)
    {
        bool t_white = false, t_beige = false;
        bool t_ignore = false;

        writerText = "";

        if (Num == 1)
        {
            img1.SetActive(false);
            img2.SetActive(true);
        }

        for (int i = 0; i < narration.Length; i++)
        {
            switch (narration[i])
            {
                case '��': t_white = true; t_beige = false; t_ignore = true; break;
                case '��': t_white = false; t_beige = true; t_ignore = true; break;
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

        yield return new WaitForSeconds(0.45f);
    }

    IEnumerator TextArr()
    {
        yield return StartCoroutine(_typing("������ �繫�ǿ���\n������ ���� �Ͼ�� �ִٴ�\n�����Ũ㸦 ã�� ���̶�."));
        yield return StartCoroutine(_typing("����� ������ ã�� ����\n���˺긮�� �Ÿ���� �̵��ϴµ�..."));
        // yield return StartCoroutine(_typing("0"));
        // yield return StartCoroutine(_typing("1"));
    }
}