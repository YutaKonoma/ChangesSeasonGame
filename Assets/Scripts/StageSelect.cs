using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    [Header("")]
    private string _stage;

    [SerializeField]
    [Header("")]
    private GameObject[] _stageButton;

    private void Start()
    {
        foreach (var chr in _stageButton)
        {
            chr.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        _stage = other.gameObject.name;
        ButtonOn();
    }

    public void ButtonOn()
    {
        switch (_stage) 
        {
            case "1-1":
                _stageButton[0].SetActive(true);
                break;

            case "1-2":
                _stageButton[1].SetActive(true);
                break;

            case "1-3":
                _stageButton[2].SetActive(true); 
                break;

            case "1-4":
                _stageButton[3].SetActive(true); 
                break;

            case "1-5":
                _stageButton[4].SetActive(true);
                break;

            case "1-6":
                _stageButton[5].SetActive(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (var chr in _stageButton)
        {
            chr.SetActive(false);
        }
    }
}