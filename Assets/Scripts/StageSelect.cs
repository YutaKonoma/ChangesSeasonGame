using Unity.VisualScripting;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [SerializeField]
    [Header("")]
    private string _stage;

    [SerializeField]
    [Header("")]
    private GameObject _canvas;

    [SerializeField]
    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = SceneLoader.Instance;
        _canvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _canvas.SetActive(true);
    }

    public void ButtonOn()
    {
        _sceneLoader.LoadScene(_stage);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _canvas.SetActive(false);
    }
}