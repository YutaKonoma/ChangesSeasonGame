using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeScript : MonoBehaviour
{
    [SerializeField] private int minute;
    [SerializeField] private float seconds;
    [SerializeField] private TextMeshProUGUI timertext;
    private bool Player;
    void Start()
    {
        Player = false;
    }

    void Update()
    {
        if (Player == false)
        {
            seconds += Time.deltaTime;

            if (seconds > 60f)
            {
                minute += 1;
                seconds = 0;
            }
            /// <summary> テキストにTIME　0とseconds、minuteを追加する
            timertext.text = minute.ToString("TIME 0") + ":" + seconds.ToString("f2");
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag =="Goal" )
        {
            Player = true;
            Invoke(nameof(Load), 3.5f);
            Debug.Log("Goal");
        }
    }

    private void Load()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
