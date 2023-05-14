using UnityEngine;

public class StartScene : MonoBehaviour
{
    [SerializeField]
    [Header("最初に表示されているキャンバス")]
    Canvas _start;

    [SerializeField] 
    [Header("操作説明を表示するキャンバス")]
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
