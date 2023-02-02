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
                Title.text = "Ʈ���� ī��" + System.Environment.NewLine + "Ŭ�ι� 2";
                Explain.text = "�������� �Ǽ���, �Ǵ� ���Ƿ� �Ҿ���� ī�� �� ��.";

                I_clover2.SetActive(true);
            }
            else if (item.itemName == "DIA7")
            {
                Title.text = "Ʈ���� ī��" + System.Environment.NewLine + "���̾� 7";
                Explain.text = "�������� �Ǽ���, �Ǵ� ���Ƿ� �Ҿ���� ī�� �� ��.";

                I_dia7.SetActive(true);
            }
            else if (item.itemName == "DIARY")
            {
                Title.text = "���̶��� �ϱ���";
                Explain.text = "���̶��� �ն��� ���� �ϱ���.";

                I_diary.SetActive(true);
                I_click.SetActive(true);
            }
            else if (item.itemName == "GUN")
            {
                Title.text = "�����ϰ� ������ ����";
                Explain.text = "�и� ���� ���� ���ڿ� ��� �־��µ���" + System.Environment.NewLine + "��û���� �����ϰ� �� ���ǰ��� ����.";

                I_gun.SetActive(true);
            }
            else if (item.itemName == "HEART3")
            {
                Title.text = "Ʈ���� ī��" + System.Environment.NewLine + "��Ʈ 3";
                Explain.text = "�������� �Ǽ���, �Ǵ� ���Ƿ� �Ҿ���� ī�� �� ��.";

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
                    Title.text = "����";
                    Explain.text = "�������� �߰��� ����.";
                }
                

                I_key.SetActive(true);
            }
            else if (item.itemName == "OLD")
            {
                Title.text = "���� ���� ������";
                Explain.text = "��Ż���� �ձ��� �����̶�� ������ ���Ѿ� �� �������� ���� �ִ� ������." + System.Environment.NewLine + "�ϵ� ���Ƽ� �ֽ� �������� ���� �ǽɽ�����." + System.Environment.NewLine + "Ȯ���ؾ� �Ѵ�.";

                I_old.SetActive(true);
            }
            else if (item.itemName == "SPADE5")
            {
                Title.text = "Ʈ���� ī��" + System.Environment.NewLine + "�����̵� 5";
                Explain.text = "�������� �Ǽ���, �Ǵ� ���Ƿ� �Ҿ���� ī�� �� ��.";

                I_spade5.SetActive(true);
            }
            else if (item.itemName == "ADOPT")
            {
                Title.text = "���̶��� �Ծ� ����";
                Explain.text = "���̶��� �Ծ�Ǿ��� �� �ۼ��� ����." + System.Environment.NewLine + "��ũ�� �տ� ���� �ʰ� ��������.";

                I_adopt.SetActive(true);
            }

        }
    }
}