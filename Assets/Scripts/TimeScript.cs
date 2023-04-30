using UnityEngine;

public class TimeScript : MonoBehaviour
{
    private int _minute;
    private float _seconds;

    private bool _player = true;

    [SerializeField]
    private TMPro.TextMeshProUGUI _timerText;
    void Update()
    {
        if (_player == true)
        {
            _seconds += Time.deltaTime;

            if (_seconds > 60f)
            {
                _minute += 1;
                _seconds = 0;
            }
            //テキストにTIME　0とseconds、minuteを追加する
            _timerText.text = _minute.ToString("TIME 0") + ":" + _seconds.ToString("f2");
        }
    }

    void StageClear()
    {
        _player = false;
        Invoke(nameof(Load), 3.5f);
    }

    private void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectScene");
    }
}
