using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1C1_Intro : MonoBehaviour
{
    public GameObject OpeningTitle;

    public Text tx;
    public string writerText = "";
    int Num = 0;

    public GameObject Banner;
    public Text TopText;
    public Text BottomText;

    public GameObject Icons;

    public GameObject Intro;
    public GameObject BasicbookCase1;

    public EventTrigger TxtBtn;
    private EventTrigger.Entry entry;

    void Start()
    {
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        TxtBtn.triggers.Add(entry);

        AR1_OpenClose.actionF();

        Icons.SetActive(false);
        BasicbookCase1.SetActive(false);

        OpeningTitle.SetActive(true);

        StartCoroutine(TextArr());
    }

    void Update()
    {
        if(Num == 3)
        {
            entry.callback.AddListener(IntroStart);
        }
    }

    void IntroStart(BaseEventData p)
    {
        AR1C1_MoveManager.Progress = 0;

        tx.text = "";

        Intro.SetActive(false);

        Banner.SetActive(true);
        Icons.SetActive(true);
        BasicbookCase1.SetActive(true);

        TopText.text = "364. Ǫ�� ������ ���";
        BottomText.text = "������� 3����. ������ �繫��";

        entry.callback.RemoveAllListeners();
        entry.callback.AddListener(IntroClick);
    }

    void IntroClick(BaseEventData p)
    {
        OpeningTitle.SetActive(false);
        Banner.SetActive(false);

        GameObject.Find("AR1C1_BasicbookCase1").GetComponent<AR1_InteractionController>().Text();

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
        yield return StartCoroutine(_typing("���̶��� ��� �񸮰� �ǽɵǴ�\n����Ƽ�� ���� �����б� �Ҽ�\n ������ �繫�ǿ� �����߽��ϴ�."));
        yield return StartCoroutine(_typing("������ �ٽ� �繫�Ƿ� ���� ������\n �γ��� �ð��� �� 20��.��"));
        yield return StartCoroutine(_typing("���ѵ� �ð� �ȿ� �����Ũ㸦 ã��\n ������ ���� ������������!"));
        // yield return StartCoroutine(_typing("1"));
        // yield return StartCoroutine(_typing("2"));
        // yield return StartCoroutine(_typing("3"));
    }
}