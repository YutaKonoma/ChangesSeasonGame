using UnityEngine;

public class TimeScript 
{
    private int _minute;
    private float _seconds;

    private bool _player = true;

    private SceneLoader _sceneLoader;

    [SerializeField]
    [Header("�o�ߎ��Ԃ�\������UI")]
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
            //�e�L�X�g��TIME0��seconds�Aminute��ǉ�����
            _timerText.text = _minute.ToString("TIME 0") + ":" + _seconds.ToString("f2");
        }
        else 
        {
            _sceneLoader = SceneLoader.Instance;
            _sceneLoader.LoadScene("StageSelectScene");
        }
    }
}
