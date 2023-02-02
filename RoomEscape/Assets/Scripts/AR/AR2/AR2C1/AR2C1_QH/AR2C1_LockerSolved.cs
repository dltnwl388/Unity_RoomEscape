using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR2C1_LockerSolved : MonoBehaviour
{
    public GameObject Clover2;
    public GameObject Heart3;
    public GameObject Dia7;
    public GameObject Spade5;

    public GameObject Locker;      
    public GameObject Upperlocker; 
    public GameObject OpenLocker;  

    private RectTransform lockerbody;
    private RectTransform upperloc;

    void Awake()
    {
        upperloc = Upperlocker.GetComponent<RectTransform>();
        lockerbody = Locker.GetComponent<RectTransform>();
    }

    public void OnClickUpperLocker()
    {
        StartCoroutine(clickupper());

        if (Clover2.activeSelf && Heart3.activeSelf && Dia7.activeSelf && Spade5.activeSelf == true)
        {
            StartCoroutine(forlockeranswer());
        }
        else
        {
            StartCoroutine(forlockerwrong());
        }
    }

    IEnumerator clickupper()
    {
        upperloc.position = new Vector3(upperloc.position.x, upperloc.position.y - 0.4f, upperloc.position.z);

        yield return new WaitForSeconds(0.3f);

        upperloc.position = new Vector3(upperloc.position.x, upperloc.position.y + 0.4f, upperloc.position.z);
    }

    IEnumerator forlockeranswer()
    {
        yield return new WaitForSeconds(0.7f);

        Upperlocker.SetActive(false);
        OpenLocker.SetActive(true);

        yield return new WaitForSeconds(1f);

        AR2C1_MoveManager.instance.AR2C1_QHSuccess();
    }

    IEnumerator forlockerwrong()
    {
        yield return new WaitForSeconds(0.5f);

        upperloc.position = new Vector3(upperloc.position.x - 0.1f, upperloc.position.y, upperloc.position.z);
        lockerbody.position = new Vector3(lockerbody.position.x - 0.1f, lockerbody.position.y, lockerbody.position.z);

        yield return new WaitForSeconds(0.1f);

        upperloc.position = new Vector3(upperloc.position.x + 0.2f, upperloc.position.y, upperloc.position.z);
        lockerbody.position = new Vector3(lockerbody.position.x + 0.2f, lockerbody.position.y, lockerbody.position.z);

        yield return new WaitForSeconds(0.1f);

        upperloc.position = new Vector3(upperloc.position.x - 0.2f, upperloc.position.y, upperloc.position.z);
        lockerbody.position = new Vector3(lockerbody.position.x - 0.2f, lockerbody.position.y, lockerbody.position.z);

        yield return new WaitForSeconds(0.1f);

        upperloc.position = new Vector3(upperloc.position.x + 0.1f, upperloc.position.y, upperloc.position.z);
        lockerbody.position = new Vector3(lockerbody.position.x + 0.1f, lockerbody.position.y, lockerbody.position.z);

        yield return new WaitForSeconds(0.5f);

        GameObject.Find("AR2C1_QHFail").GetComponent<AR2_InteractionController>().Text();
    }
}