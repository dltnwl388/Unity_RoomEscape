using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ER1C1_QuizDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rect;
    private CanvasGroup canvasgroup;

    public GameObject sheep;
    public GameObject wolf;
    public GameObject grass;
    public GameObject erden;

    public Sprite erdensmile;

    Vector2 sheepposition;
    Vector2 wolfposition;
    Vector2 grassposition;
    Vector2 erdenposition;

    public bool ismoving = false;

    public static int sh, wo, gr, failgame = 0;
    public int shs, wos, grs, success, wolfsheep, sheepgrass = 0;

    Vector2 erdenshpos;
    Vector2 erdenshpos2;
    Vector2 erdenwopos;
    Vector2 erdenwopos2;
    Vector2 erdengrpos;
    Vector2 erdengrpos2;

    public static bool GameOverCheck = false;

    public static Action action2;

    void Awake()
    {
        sheepposition = sheep.transform.localPosition;
        wolfposition = wolf.transform.localPosition;
        grassposition = grass.transform.localPosition;
        erdenposition = erden.transform.localPosition;

        rect = GetComponent<RectTransform>();
        canvasgroup = GetComponent<CanvasGroup>();

        action2 = () => { ResetGame(); };
    }

    void Update()
    {
        if (sh == 1)
        {
            erdenshpos = sheep.transform.position - erden.transform.position;

            sh = 2;
        }

        if (sh == 3)
        {
            erdenshpos2 = sheep.transform.position - erden.transform.position;

            sh = 4;
        }

        if (ismoving == true && sh == 2)
        {
            Vector2 shpos = new Vector2(erden.transform.position.x, erden.transform.position.y);

            sheep.transform.position = shpos + erdenshpos;
        }

        if (ismoving == true && sh == 4)
        {
            Vector2 shpos = new Vector2(erden.transform.position.x, erden.transform.position.y);

            sheep.transform.position = shpos + erdenshpos;
        }

        if (wo == 1)
        {
            erdenwopos = wolf.transform.position - erden.transform.position;

            wo = 2;
        }

        if (wo == 3)
        {
            erdenwopos2 = wolf.transform.position - erden.transform.position;

            wo = 4;
        }

        if (ismoving == true && wo == 2)
        {
            Vector2 shpos = new Vector2(erden.transform.position.x, erden.transform.position.y);

            wolf.transform.position = shpos + erdenwopos;
        }

        if (ismoving == true && wo == 4)
        {
            Vector2 shpos = new Vector2(erden.transform.position.x, erden.transform.position.y);

            wolf.transform.position = shpos + erdenwopos2;
        }

        if (gr == 1)
        {
            erdengrpos = grass.transform.position - erden.transform.position;

            gr = 2;
        }

        if (gr == 3)
        {
            erdengrpos2 = grass.transform.position - erden.transform.position;

            gr = 4;
        }

        if (ismoving == true && gr == 2)
        {
            Vector2 shpos = new Vector2(erden.transform.position.x, erden.transform.position.y);

            grass.transform.position = shpos + erdengrpos;
        }

        if (ismoving == true && gr == 4)
        {
            Vector2 shpos = new Vector2(erden.transform.position.x, erden.transform.position.y);

            grass.transform.position = shpos + erdengrpos2;
        }

        if (GameOverCheck == false)
        {
            if ((gr == 5 || gr == 4) && (wo == 5 || wo == 4) && (sh == 5 || sh == 4))
            {
                GameOverCheck = true;
                success = 1;

                erden.GetComponent<Image>().sprite = erdensmile;

                Invoke(nameof(GameOver), 1.0f);
            }
            else if (ER1C1_QuizAnswer.forfailwolfsheep == true)
            {
                GameOverCheck = true;
                wolfsheep = 1;

                Invoke(nameof(GameOver), 0.5f);
                
                Debug.Log("´Á´ë°¡ ¾ç ÃÄ¸Ô¾ú³×");
            }
            else if (ER1C1_QuizAnswer.forfailsheepgrass == true)
            {
                GameOverCheck = true;
                sheepgrass = 1;

                Invoke(nameof(GameOver), 0.5f);

                Debug.Log("¾çÀÌ Ç®À» ÃÄ¸Ô¾ú³×");
            }
        }
    }

    void ResetGame()
    {
        ismoving = false;

        sh = 0;
        wo = 0;
        gr = 0;

        failgame = 0;

        shs = 0;
        wos = 0;
        grs = 0;

        success = 0;

        wolfsheep = 0;
        sheepgrass = 0;

        wolf.transform.localPosition = wolfposition;
        sheep.transform.localPosition = sheepposition;
        grass.transform.localPosition = grassposition;
        erden.transform.localPosition = erdenposition;
    }

    public void GameOver()
    {
        if (success == 1)
        {
            ER1C1_MoveManager.instance.ER1C1_QSuccess();
        }
        else if (wolfsheep == 1)
        {
            ER1C1_MoveManager.instance.ER1C1_WSFail();
        }
        else if (sheepgrass == 1)
        {
            ER1C1_MoveManager.instance.ER1C1_SGFail();
        }
    }

    public void OnClicktoSelectsheep()
    {
        if (wo == 0 && sh == 0 && gr == 0)
        {
            if (ER1C1_QuizStart.erdenatstart == 0)
            {

            }
            else
            {
                sheep.transform.localPosition = new Vector2(330, 147);
                sh = 1;
            }
        }
        else if (sh == 2)
        {
            sheep.transform.localPosition = sheepposition;

            sh = 0;
        }
        else if (sh == 4)
        {
            sheep.transform.localPosition = new Vector2(-271, 29);

            sh = 5;
            shs = 1;
        }
        else if (sh == 5)
        {
            if (ER1C1_QuizStart.erdenatstart == 1 || wo == 4 || gr == 4)
            {

            }
            else
            {
                sheep.transform.localPosition = new Vector2(-276, 121);

                sh = 4;
                shs = 0;
            }
        }
        else if (ER1C1_QuizStart.erdenatstart == 1 && ((wos == 1 && grs == 1) || (wos == 1 && gr == 0) || (grs == 1 && wo == 0) || (wo == 0 && gr == 0)))
        {
            sheep.transform.localPosition = new Vector2(330, 147);

            sh = 1;
        }
    }

    public void OnClicktoSelectwolf()
    {
        if (wo == 0 && sh == 0 && gr == 0)
        {
            if (ER1C1_QuizStart.erdenatstart == 0)
            {

            }
            else
            {
                wolf.transform.localPosition = new Vector2(336, 140);
                wo = 1;
            }

        }
        else if (wo == 2)
        {
            wolf.transform.localPosition = wolfposition;

            wo = 0;
        }
        else if (wo == 4)
        {
            wolf.transform.localPosition = new Vector2(-379, 43);

            wo = 5;
            wos = 1;
        }
        else if (wo == 5)
        {
            if (ER1C1_QuizStart.erdenatstart == 1 || sh == 4 || gr == 4)
            {

            }
            else
            {
                wolf.transform.localPosition = new Vector2(-280, 135);

                wo = 4;
                wos = 0;
            }
        }
        else if (ER1C1_QuizStart.erdenatstart == 1 && ((grs == 1 && shs == 1) || (shs == 1 && gr == 0) || (gr == 0 && sh == 0) || (grs == 1 && sh == 0)))
        {
            wolf.transform.localPosition = new Vector2(336, 140);

            wo = 1;
        }
    }

    public void OnClicktoSelectgrass()
    {
        if (wo == 0 && sh == 0 && gr == 0)
        {
            if (ER1C1_QuizStart.erdenatstart == 0)
            {

            }
            else
            {
                grass.transform.localPosition = new Vector2(324, 137);
                gr = 1;
            }
        }
        else if (gr == 2)
        {
            grass.transform.localPosition = grassposition;

            gr = 0;
        }
        else if (gr == 4)
        {
            grass.transform.localPosition = new Vector2(-478, 40);

            gr = 5;
            grs = 1;
        }
        else if (gr == 5)
        {
            if (ER1C1_QuizStart.erdenatstart == 1 || wo == 4 || sh == 4)
            {

            }
            else
            {
                grass.transform.localPosition = new Vector2(-275, 132);

                gr = 4;
                grs = 0;
            }
        }
        else if (ER1C1_QuizStart.erdenatstart == 1 && ((wos == 1 && shs == 1) || (wos == 1 && sh == 0) || (shs == 1 && wo == 0) || (wo == 0 && sh == 0)))
        {
            grass.transform.localPosition = new Vector2(324, 137);

            gr = 1;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasgroup.blocksRaycasts = false;
        ismoving = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasgroup.blocksRaycasts = true;
        Invoke(nameof(iismv), 0.1f);
    }

    public void iismv()
    {
        ismoving = false;
    }
}