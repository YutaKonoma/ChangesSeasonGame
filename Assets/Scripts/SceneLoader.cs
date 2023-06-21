using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System;

public class SceneLoader :SingletonMonoBehaviour<SceneLoader>
{ 
    [SerializeField]
    string _sceneName;

    [SerializeField]
    RectTransform[] _fadeObject;

    Vector3 _startPos1;
    Vector3 _startPos2;

    bool _isLoading;

    private void Start()
    {
        _startPos1 = _fadeObject[0].transform.position;
        _startPos2 = _fadeObject[1].transform.position;
    }

    public async void LoadScene(string sceneName)
    {
        _sceneName = sceneName;
        var asyncLoad = SceneManager.LoadSceneAsync(_sceneName);
        asyncLoad.allowSceneActivation = false;
        Fade();
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        asyncLoad.allowSceneActivation = true;
        _isLoading = false;
    }

    private void Fade()
    {
        if (!_isLoading)
        {
            _isLoading = true;

            DOTween.Sequence()
                 .Append(_fadeObject[0].DOMoveX(450, 2f))
                 .Join(_fadeObject[1].DOMoveX(1600, 2f))
                 .AppendInterval(1.5f)
                 .Append(_fadeObject[0].DOMoveX(_startPos1.x, 2f))
                 .Join(_fadeObject[1].DOMoveX(_startPos2.x, 2f))
                 .OnComplete(() => DOTween.Kill(this));
        }      
    }
}