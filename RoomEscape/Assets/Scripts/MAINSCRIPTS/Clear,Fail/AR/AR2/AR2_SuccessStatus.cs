using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AR2_SuccessStatus : MonoBehaviour
{
    [SerializeField] GameObject ICONS;

    [SerializeField] GameObject AR_Success;

    [SerializeField] GameObject AR2C1;

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

                if (AR2C1 != null)
                {
                    if (AR2C1.activeSelf == true)
                    {
                        Destroy(AR2C1);

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