using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    [Header("�ŏ��ɕ\������Ă���L�����o�X")]
    Canvas _start;

    [SerializeField] 
    [Header("���������\������L�����o�X")]
    Canvas _explanation;

    [SerializeField]
    SceneLoader _sceneLoader;

    void Awake()
    {
        _explanation.enabled = false;
    }

    public void StartGame()
    {
        _sceneLoader.Fade("SelectScene");
    }

    public void OnButton()
    {
        _explanation.enabled = true;
        _start.enabled = false;
    }

    public void Return()
    {
        _explanation.enabled = false;
        _start.enabled = true;
    }
}
