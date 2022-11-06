using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSeason : MonoBehaviour
{
    [SerializeField] private Image Spring; //�t�̃A�C�R��
    [SerializeField] private Image Summer; //�ẴA�C�R��
    [SerializeField] private Image Autumn; //�H�̃A�C�R��
    [SerializeField] private Image Winter; //�~�̃A�C�R��

    [SerializeField] private GameObject SpringButton; //�t�̃{�^��
    [SerializeField] private GameObject SummerButton; //�Ẵ{�^��
    [SerializeField] private GameObject AutumnButton; //�H�̃{�^��
    [SerializeField] private GameObject WinterButton; //�~�̃{�^��

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
        if (Input.GetButtonUp("Change"))�@//�`�F���W�Ɋ���U��ꂽ�{�^���������ꂽ�ꍇ
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
