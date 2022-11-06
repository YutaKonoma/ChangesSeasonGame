using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopScene : MonoBehaviour
{
    [SerializeField]public int shop = 0;
    [SerializeField] private TextMeshProUGUI _tokenText;
    [SerializeField] private GameObject Kye;
    void Start()
    {
        var Tokens = TokenScript.Token;
        Kye.SetActive(false);
    }

    private void Update()
    {
        _tokenText.text = ":"+ shop;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Token")
        {
            shop++;
        }
    }
    public void GetItem()
    {
        if (shop >= 1)
        {
            Kye.SetActive(true);
            shop--;
            return;
        }
        else
        {
            Debug.Log("‚¨‹à‚ª‚È‚¢‚æ");
        }
    }
    public void OpenStag()
    {
        if (gameObject.tag == "1-2")
        {
            this.gameObject.name = "1-2";
        }
    }
}
