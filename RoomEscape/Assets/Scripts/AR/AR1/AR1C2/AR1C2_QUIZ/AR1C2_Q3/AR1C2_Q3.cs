using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AR1C2_Q3 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rect;
    private CanvasGroup canvasGroup;

    public GameObject APoint;
    public GameObject APoint_1;
    public GameObject APoint_2;
    public GameObject APoint_3;
    public GameObject APoint_4;
    public GameObject APoint_5;
    public GameObject APoint_6;
    public GameObject APoint_7;
    public GameObject APoint_8;
    public GameObject APoint_9;
    public GameObject APoint_10;
    public GameObject APoint_11;
    public GameObject APoint_12;
    public GameObject APoint_13;
    public GameObject APoint_14;
    public GameObject APoint_15;
    public GameObject APoint_16;
    public GameObject APoint_17;
    public GameObject APoint_18;
    public GameObject APoint_19;
    public GameObject APoint_20;

    public GameObject Point_1;
    public GameObject Point_2;
    public GameObject Point_3;
    public GameObject Point_5;
    public GameObject Point_6;
    public GameObject Point_7;
    public GameObject Point_8;
    public GameObject Point_9;
    public GameObject Point_10;
    public GameObject Point_11;
    public GameObject Point_12;
    public GameObject Point_13;

    public int Answer = 0;

    public static bool StartMove = false;

    void Update()
    {
        if (StartMove == true)
        {
            this.transform.position = new Vector3(2.25f, 3.7f, 0);

            Initialization();
        }
    }

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        Initialization();
    }

    void Initialization()
    {
        StartMove = false;

        Answer = 0;

        APoint.SetActive(true);
        APoint_1.SetActive(false);
        APoint_2.SetActive(false);
        APoint_3.SetActive(false);
        APoint_4.SetActive(false);
        APoint_5.SetActive(false);
        APoint_6.SetActive(false);
        APoint_7.SetActive(false);
        APoint_8.SetActive(false);
        APoint_9.SetActive(false);
        APoint_10.SetActive(false);
        APoint_11.SetActive(false);
        APoint_12.SetActive(false);
        APoint_13.SetActive(false);
        APoint_14.SetActive(false);
        APoint_15.SetActive(false);
        APoint_16.SetActive(false);
        APoint_17.SetActive(false);
        APoint_18.SetActive(false);
        APoint_19.SetActive(false);
        APoint_20.SetActive(true);

        Point_1.SetActive(false);
        Point_2.SetActive(false);
        Point_3.SetActive(false);
        Point_5.SetActive(false);
        Point_6.SetActive(false);
        Point_7.SetActive(false);
        Point_8.SetActive(false);
        Point_9.SetActive(false);
        Point_10.SetActive(false);
        Point_11.SetActive(false);
        Point_12.SetActive(false);
        Point_13.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        StartMove = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Points")
        {
            Answer -= 2;
        }

        if (other.name == "APoint")
        {
            APoint_1.SetActive(true);

            APoint.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (1)")
        {
            APoint_2.SetActive(true);

            APoint_1.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (2)")
        {
            APoint_3.SetActive(true);
            Point_2.SetActive(true);

            APoint_2.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (3)")
        {
            APoint_4.SetActive(true);
            Point_1.SetActive(true);

            APoint_3.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (4)")
        {
            APoint_5.SetActive(true);

            APoint_4.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (5)")
        {
            APoint_6.SetActive(true);
            Point_5.SetActive(true);

            APoint_5.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (6)")
        {
            APoint_7.SetActive(true);
            Point_3.SetActive(true);

            APoint_6.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (7)")
        {
            APoint_8.SetActive(true);

            APoint_7.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (8)")
        {
            APoint_9.SetActive(true);

            APoint_8.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (9)")
        {
            APoint_10.SetActive(true);

            APoint_9.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (10)")
        {
            APoint_11.SetActive(true);

            APoint_10.SetActive(false);
            
            Answer += 1;
        }

        if (other.name == "APoint (11)")
        {
            APoint_12.SetActive(true);
            Point_6.SetActive(true);

            APoint_11.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (12)")
        {
            APoint_13.SetActive(true);

            APoint_12.SetActive(false);
     
            Answer += 1;
        }

        if (other.name == "APoint (13)")
        {
            APoint_14.SetActive(true);

            APoint_13.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (14)")
        {
            APoint_15.SetActive(true);

            APoint_14.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (15)")
        {
            APoint_16.SetActive(true);
            Point_7.SetActive(true);
            Point_8.SetActive(true);

            APoint_15.SetActive(false);

            Answer += 1;
        }

        if (other.name == "APoint (16)")
        {
            APoint_17.SetActive(true);

            APoint_16.SetActive(false);
 
            Answer += 1;
        }

        if (other.name == "APoint (17)")
        {
            APoint_18.SetActive(true);
            Point_10.SetActive(true);
            Point_13.SetActive(true);

            APoint_17.SetActive(false);
 
            Answer += 1;
        }

        if (other.name == "APoint (18)")
        {
            APoint_19.SetActive(true);
            Point_9.SetActive(true);

            APoint_18.SetActive(false);
         
            Answer += 1;
        }

        if (other.name == "APoint (19)")
        {
            Point_11.SetActive(true);

            APoint_19.SetActive(false);
      
            Answer += 1;
        }

        if (other.name == "APoint (20)")
        {
            Point_12.SetActive(true);

            APoint_20.SetActive(false);

            Answer += 1;

            if (Answer == 21)
            {
                StartMove = true;

                AR1C2_MoveManager.instance.Q3Success();
            }
            else
            {
                GameObject.Find("AR1C2_Quiz3").GetComponent<AR1_InteractionController>().Text();
            }
        }
    }
}