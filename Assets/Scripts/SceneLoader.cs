using UnityEngine;
using DG.Tweening;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
    [SerializeField]
    string _sceneName;

    [SerializeField]
    string _scenePath;

    [SerializeField]
    RectTransform[] _fadeObject;

    Vector3 startPos1;
    Vector3 startPos2;
    public bool _isLoading { get; private set; } = false;

    private void Start()
    {
        startPos1 = _fadeObject[0].rect.position;
        startPos2 = _fadeObject[1].rect.position;
    }
    private void LoadScene(string sceneName)
    {
        _sceneName = sceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }

    private void Fade()
    {
        //if (_isLoading) { }
        _fadeObject[0].DOMoveX(450, 1.7f);
        _fadeObject[1].DOMoveX(1600, 1.7f);
    }
}