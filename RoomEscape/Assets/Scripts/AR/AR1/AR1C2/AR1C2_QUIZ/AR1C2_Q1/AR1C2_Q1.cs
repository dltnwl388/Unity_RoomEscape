using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class AR1C2_Q1 : MonoBehaviour
{
    public GameObject ClickBtnBox;
    public GameObject ClickOneBtn;

    public GameObject Q1NoticeBox;
    public EventTrigger Q1Notice;
    public Text Q1NoticeText;

    public GameObject Houses;

    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;

    void Start()
    {
        entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerClick;

        entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerClick;

        Q1NoticeText.text = "핌브리아가 9번지에는\n다음과 같은 8개의 집이 있다."
                            + "\n\n잘못된 집에 찾아가 소란을 피우면\n"
                            + "무언가 눈치챈 범인이 도주할 우려가 있기에,\n"
                            + "범인이 있는 집을 곧장 찾아가야 한다.";

        Houses.SetActive(false);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(NextNotice2);
        Q1Notice.triggers.Remove(entry1);
        Q1Notice.triggers.Add(entry1);
    }

    public void NextNotice1()
    {
        Q1NoticeText.text = "핌브리아가 9번지에는\n다음과 같은 8개의 집이 있다."
                            + "\n\n잘못된 집에 찾아가 소란을 피우면\n"
                            + "무언가 눈치챈 범인이 도주할 우려가 있기에,\n"
                            + "범인이 있는 집을 곧장 찾아가야 한다.";

        Q1NoticeBox.SetActive(true);
        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);

        Houses.SetActive(false);

        entry2.callback.RemoveAllListeners();
        entry2.callback.AddListener(NextNotice3);
        Q1Notice.triggers.Remove(entry2);
        Q1Notice.triggers.Add(entry2);
    }

    void NextNotice2(BaseEventData p)
    {
        Q1NoticeText.text = "핌브리아 가의 북쪽 편에 술집이 하나 있다.\n"
                            + "그 맞은편은 리본 상인의 집이다.\n\n"
                            + "팜브리아 가의 집들 중,\n아이란이 찾고 있는 빈집은\n"
                            + "존스티나 공작가의 정보상이 살고 있는\n"
                            + "하숙집과 가장 멀리 떨어져 있다.\n\n"
                            + "그 하숙집은 리본 상인의 집의 서쪽에 위치해 있다.\n"
                            + "문제의 빈집은 핌브리아 가의 몇 번째 집일까?";

        AR1C2_MoveManager.instance.Q1NextNotice2();
    }

    void NextNotice3(BaseEventData p)
    {
        Q1NoticeText.text = "핌브리아 가의 북쪽 편에 술집이 하나 있다.\n"
                            + "그 맞은편은 리본 상인의 집이다.\n\n"
                            + "팜브리아 가의 집들 중,\n아이란이 찾고 있는 빈집은\n"
                            + "존스티나 공작가의 정보상이 살고 있는\n"
                            + "하숙집과 가장 멀리 떨어져 있다.\n\n"
                            + "그 하숙집은 리본 상인의 집의 서쪽에 위치해 있다.\n"
                            + "문제의 빈집은 핌브리아 가의 몇 번째 집일까?";

        Q1NoticeBox.SetActive(true);
        ClickBtnBox.SetActive(false);
        ClickOneBtn.SetActive(false);

        Houses.SetActive(false);

        entry1.callback.RemoveAllListeners();
        entry1.callback.AddListener(Text1);
        Q1Notice.triggers.Remove(entry1);
        Q1Notice.triggers.Add(entry1);
    }

    void Text1(BaseEventData p)
    {
        AR1C2_MoveManager.instance.Q1NextNotice2();
    }
}