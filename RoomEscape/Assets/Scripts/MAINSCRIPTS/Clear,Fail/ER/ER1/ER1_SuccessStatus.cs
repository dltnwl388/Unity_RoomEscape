using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ER1_SuccessStatus : MonoBehaviour
{
    [SerializeField] GameObject ICONS;

    [SerializeField] GameObject ED_Success;

    [SerializeField] GameObject ER1C1;
    [SerializeField] GameObject ER1C1_SheepBasket;

    private void OnEnable()
    {
        ICONS.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                // ICONS.SetActive(true);

                if (ER1C1 != null)
                {
                    if (ER1C1.activeSelf == true)
                    {
                        Destroy(ER1C1);
                        Destroy(ER1C1_SheepBasket);

                        Invoke(nameof(Waitback), 1.5f);               
                    }
                }
                else
                {
                    ED_Success.SetActive(true);
                }
            }
        }
    }

    public void Waitback()
    {
        ED_Success.SetActive(false);

        SceneManager.LoadScene(0);
    }
}