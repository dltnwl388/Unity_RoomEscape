using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AR1_SuccessStatus : MonoBehaviour
{
    [SerializeField] GameObject ICONS;

    [SerializeField] GameObject AR_Success;

    [SerializeField] GameObject AR1C1;
    [SerializeField] GameObject AR1C2;

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
                if (AR1C1 != null)
                {
                    if (AR1C1.activeSelf == true)
                    {
                        AR1_Inventory.action();

                        Destroy(AR1C1);

                        AR_Success.SetActive(false);

                        AR1C2.SetActive(true);
                        ICONS.SetActive(true);
                    }
                }
                else if (AR1C2 != null)
                {
                    if (AR1C2.activeSelf == true)
                    {
                        Destroy(AR1C2);

                        Invoke(nameof(Waitback), 1.5f);
                    }
                }
                else
                {
                    AR_Success.SetActive(true);
                }
            }
                
        }
    }
    public void Waitback()
    {
        AR_Success.SetActive(false);
                    
        SceneManager.LoadScene(0);
    }
}