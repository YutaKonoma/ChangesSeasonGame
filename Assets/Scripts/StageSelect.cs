using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    [SerializeField] private string stage;

    [SerializeField] private Canvas shop;

    [SerializeField] private GameObject stage1Button;
    [SerializeField] private GameObject stage2Button;
    [SerializeField] private GameObject stage3Button;
    [SerializeField] private GameObject stage4Button;
    [SerializeField] private GameObject stage5Button;
    [SerializeField] private GameObject stage6Button;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject OpenButton;

    private void Start()
    {
        shop.enabled = false;

        stage1Button.SetActive(false);
        stage2Button.SetActive(false);
        stage3Button.SetActive(false);
        stage4Button.SetActive(false);
        stage5Button.SetActive(false);
        stage6Button.SetActive(false);
        shopButton.SetActive(false);
        OpenButton.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        stage = collider.gameObject.name;

        if (stage == "1-1")
        {
            stage1Button.SetActive(true);
        }

        if (stage == "1-2")
        {
            stage2Button.SetActive(true);
        }
        if (stage == "1-3")
        {
            stage3Button.SetActive(true);
        }
        if (stage == "1-4")
        {
            stage4Button.SetActive(true);
        }
        if (stage == "1-5")
        {
            stage5Button.SetActive(true);
        }
        if (stage == "1-6")
        {
            stage6Button.SetActive(true);
        }
        if (stage == "shop" )
        {
            shopButton.SetActive(true);
        }
        if (stage == "()")
        {
            OpenButton.SetActive(true);
        }
    }
    public void ButtonOn()
    {
        if (stage == "1-1")
        {
            SceneManager.LoadScene("Map1_Scene");
            Debug.Log("Map1_Scene");
        }

        if (stage == "1-2")
        {
            SceneManager.LoadScene("Map2_Scene");
            Debug.Log("Map2_Scene");
        }

        if (stage == "1-3")
        {
            SceneManager.LoadScene("Map3_Scene");
            Debug.Log("Map3_Scene");
        }

        if (stage == "1-4")
        {
            SceneManager.LoadScene("Map4_Scene");
            Debug.Log("Map4_Scene");
        }

        if (stage == "1-5")
        {
            SceneManager.LoadScene("Map5_Scene");
            Debug.Log("Map5_Scene");
        }

        if (stage == "1-6")
        {
            SceneManager.LoadScene("Map6_Scene");
            Debug.Log("Map6_Scene");
        }

        if (stage == "shop")
        {
            shop.enabled = true;
            Debug.Log("shop");
        }
        if (stage == "()")
        {
            if (gameObject.tag == "1-2")
            {
                this.gameObject.name = "1-2";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        stage1Button.SetActive(false);
        stage2Button.SetActive(false);
        stage3Button.SetActive(false);
        stage4Button.SetActive(false);
        stage5Button.SetActive(false);
        stage6Button.SetActive(false);
        shopButton.SetActive(false);
        shop.enabled = false;
        OpenButton.SetActive(false);
    }
}