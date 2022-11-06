using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSeason : MonoBehaviour
{
    [SerializeField] private Image Spring; //春のアイコン
    [SerializeField] private Image Summer; //夏のアイコン
    [SerializeField] private Image Autumn; //秋のアイコン
    [SerializeField] private Image Winter; //冬のアイコン

    [SerializeField] private GameObject SpringButton; //春のボタン
    [SerializeField] private GameObject SummerButton; //夏のボタン
    [SerializeField] private GameObject AutumnButton; //秋のボタン
    [SerializeField] private GameObject WinterButton; //冬のボタン

    void Start()
    {
        Summer.enabled = false; 
        Autumn.enabled = false;
        Winter.enabled = false;

        SpringButton.SetActive(false);
        SummerButton.SetActive(false);
        AutumnButton.SetActive(false);
        WinterButton.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonUp("Change"))　//チェンジに割り振られたボタンが押された場合
        {
            SpringButton.SetActive(true);
            SummerButton.SetActive(true);
            AutumnButton.SetActive(true);
            WinterButton.SetActive(true);
        }
    }

    public void SeasonButton(int num)
    {
        switch (num)
        {
            case 0:

            Spring.enabled = true;
            Summer.enabled = false;
            Autumn.enabled = false;
            Winter.enabled = false;
            SpringButton.SetActive(false);
            SummerButton.SetActive(false);
            AutumnButton.SetActive(false);
            WinterButton.SetActive(false);

            break;


            case 1:

            Spring.enabled = false;
            Summer.enabled = true;
            Autumn.enabled = false;
            Winter.enabled = false;
            SpringButton.SetActive(false);
            SummerButton.SetActive(false);
            AutumnButton.SetActive(false);
            WinterButton.SetActive(false);

            break;


            case 2:

            Spring.enabled = false;
            Summer.enabled = false;
            Autumn.enabled = true;
            Winter.enabled = false;
            SpringButton.SetActive(false);
            SummerButton.SetActive(false);
            AutumnButton.SetActive(false);
            WinterButton.SetActive(false);

            break;


            case 3:

            Spring.enabled = false;
            Summer.enabled = false;
            Autumn.enabled = false;
            Winter.enabled = true;
            SpringButton.SetActive(false);
            SummerButton.SetActive(false);
            AutumnButton.SetActive(false);
            WinterButton.SetActive(false);

            break;
        }
    }
}
