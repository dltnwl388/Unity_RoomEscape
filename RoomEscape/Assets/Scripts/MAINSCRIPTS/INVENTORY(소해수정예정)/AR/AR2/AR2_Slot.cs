using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AR2_Slot : MonoBehaviour
{
    [SerializeField] Image image;

    private AR2_Item _item;
    
    public GameObject I_E;
    public GameObject I_heart3;
    public GameObject I_dia7;
    public GameObject I_clover2;
    public GameObject I_diary;
    public GameObject I_gun;
    public GameObject I_key;
    public GameObject I_old;
    public GameObject I_spade5;
    public GameObject I_click;
    public GameObject I_diarycontents;
    public GameObject I_adopt;
    public GameObject I_forkey;
    public GameObject I_puthere;

    public Text Title;
    public Text Explain;

    public static bool keyused = false;
    
    public AR2_Item item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
    void Awake()
    {
        I_forkey.SetActive(false);
        I_puthere.SetActive(false);
    }
    public void Onclickslot()
    {
        if (_item != null)
        {
            I_E.SetActive(true);
            I_heart3.SetActive(false);
            I_dia7.SetActive(false);
            I_clover2.SetActive(false);
            I_spade5.SetActive(false);
            I_diary.SetActive(false);
            I_old.SetActive(false);
            I_key.SetActive(false);
            I_gun.SetActive(false);
            I_click.SetActive(false);
            I_diarycontents.SetActive(false);
            I_adopt.SetActive(false);

            if (item.itemName == "CLOVER2")
            {
                Title.text = "트럼프 카드" + System.Environment.NewLine + "클로버 2";
                Explain.text = "누군가가 실수로, 또는 고의로 잃어버린 카드 한 장.";

                I_clover2.SetActive(true);
            }
            else if (item.itemName == "DIA7")
            {
                Title.text = "트럼프 카드" + System.Environment.NewLine + "다이아 7";
                Explain.text = "누군가가 실수로, 또는 고의로 잃어버린 카드 한 장.";

                I_dia7.SetActive(true);
            }
            else if (item.itemName == "DIARY")
            {
                Title.text = "아이란의 일기장";
                Explain.text = "아이란의 손때가 묻은 일기장.";

                I_diary.SetActive(true);
                I_click.SetActive(true);
            }
            else if (item.itemName == "GUN")
            {
                Title.text = "수상하게 깨끗한 장총";
                Explain.text = "분명 낡은 나무 상자에 들어 있었는데도" + System.Environment.NewLine + "엄청나게 깨끗하고 새 물건같은 장총.";

                I_gun.SetActive(true);
            }
            else if (item.itemName == "HEART3")
            {
                Title.text = "트럼프 카드" + System.Environment.NewLine + "하트 3";
                Explain.text = "누군가가 실수로, 또는 고의로 잃어버린 카드 한 장.";

                I_heart3.SetActive(true);
            }
            else if (item.itemName == "KEY")
            {
                if (AR2C1_MoveManager.forkey == true)
                {
                    I_E.SetActive(false);
                    image.color = new Color(1, 1, 1, 0);
                    keyused = true;
                    I_forkey.SetActive(true);
                    I_puthere.SetActive(true);
                    I_forkey.transform.localPosition = new Vector2(-520, 160);
                }
                else
                {
                    Title.text = "열쇠";
                    Explain.text = "램프에서 발견한 열쇠.";
                }
                

                I_key.SetActive(true);
            }
            else if (item.itemName == "OLD")
            {
                Title.text = "아주 낡은 예법서";
                Explain.text = "나탈리스 왕국의 귀족이라면 모름지기 지켜야 할 예법들이 적혀 있는 예법서." + System.Environment.NewLine + "하도 낡아서 최신 내용인지 조금 의심스럽다." + System.Environment.NewLine + "확인해야 한다.";

                I_old.SetActive(true);
            }
            else if (item.itemName == "SPADE5")
            {
                Title.text = "트럼프 카드" + System.Environment.NewLine + "스페이드 5";
                Explain.text = "누군가가 실수로, 또는 고의로 잃어버린 카드 한 장.";

                I_spade5.SetActive(true);
            }
            else if (item.itemName == "ADOPT")
            {
                Title.text = "아이란의 입양 문서";
                Explain.text = "아이란이 입양되었을 때 작성된 문서." + System.Environment.NewLine + "잉크가 손에 묻지 않게 조심하자.";

                I_adopt.SetActive(true);
            }

        }
    }
}