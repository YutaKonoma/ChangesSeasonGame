using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
{
    [SerializeField]
    string _sceneName;

    [SerializeField]
    string _scenePath;

    [SerializeField]
    RectTransform[] _fadeObject;

    Vector3 _startPos1;
    Vector3 _startPos2;

    public bool _isLoading { get; private set; } = false;

    private void Start()
    {
        _startPos1 = _fadeObject[0].transform.position;
        _startPos2 = _fadeObject[1].transform.position;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Fade(string sceneName)
    {
        _sceneName = sceneName;
        if (!_isLoading)
        {
            _isLoading = true;
            DOTween.Sequence()
                .Append(_fadeObject[0].DOMoveX(450, 2f))
                .AppendInterval(1.5f)
                .Append(_fadeObject[0].DOMoveX(_startPos1.x, 2f));

            DOTween.Sequence()
                  .Append(_fadeObject[1].DOMoveX(1600, 2f))
                  .AppendInterval(1.5f)
                  .Append(_fadeObject[1].DOMoveX(_startPos2.x, 2f));
            
        }
    }
}