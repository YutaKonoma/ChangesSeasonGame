using UnityEngine;

public class TimeScript 
{
    private int _minute;
    private float _seconds;

    private bool _player = true;

    private SceneLoader _sceneLoader;

    [SerializeField]
    [Header("経過時間を表示するUI")]
    private UnityEngine.UI.Text _timerText;

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
            //テキストにTIME0とseconds、minuteを追加する
            _timerText.text = _minute.ToString("TIME 0") + ":" + _seconds.ToString("f2");
        }
        else 
        {
            _sceneLoader = SceneLoader.Instance;
            _sceneLoader.LoadScene("StageSelectScene");
        }
    }
}
