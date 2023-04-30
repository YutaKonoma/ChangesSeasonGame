using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSeason : MonoBehaviour
{
    [SerializeField]
    [Header("季節4つの画像")]
    private Image[] _season;

    [SerializeField]
    [Header("季節を変更するボタン")]
    private GameObject[] _seasonButton;

    void Start()
    {
        _season[1].enabled = false;
        _season[2].enabled = false;
        _season[3].enabled = false;

        _seasonButton[0].SetActive(false);
        _seasonButton[1].SetActive(false);
        _seasonButton[2].SetActive(false);
        _seasonButton[3].SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonUp("Change"))　//チェンジに割り振られたボタンが押された場合
        {
            _seasonButton[0].SetActive(true);
            _seasonButton[1].SetActive(true);
            _seasonButton[2].SetActive(true);
            _seasonButton[3].SetActive(true);
        }
    }

    public void SeasonButton(int num)
    {
        switch (num)
        {
            case 0:
                _season[0].enabled = true;
                _season[1].enabled = false;
                _season[2].enabled = false;
                _season[3].enabled = false;
                _seasonButton[0].SetActive(false);
                _seasonButton[1].SetActive(false);
                _seasonButton[2].SetActive(false);
                _seasonButton[3].SetActive(false);

            break;

            case 1:
                _season[0].enabled = false;
                _season[1].enabled = true;
                _season[2].enabled = false;
                _season[3].enabled = false;
                _seasonButton[0].SetActive(false);
                _seasonButton[1].SetActive(false);
                _seasonButton[2].SetActive(false);
                _seasonButton[3].SetActive(false);

                break;

            case 2:
                _season[0].enabled = false;
                _season[1].enabled = false;
                _season[2].enabled = true;
                _season[3].enabled = false;
                _seasonButton[0].SetActive(false);
                _seasonButton[1].SetActive(false);
                _seasonButton[2].SetActive(false);
                _seasonButton[3].SetActive(false);

                break;

            case 3:
                _season[0].enabled = false;
                _season[1].enabled = false;
                _season[2].enabled = false;
                _season[3].enabled = true;
                _seasonButton[0].SetActive(false);
                _seasonButton[1].SetActive(false);
                _seasonButton[2].SetActive(false);
                _seasonButton[3].SetActive(false);

                break;
        }
    }
}
