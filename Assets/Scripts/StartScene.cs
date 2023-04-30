using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField] Canvas _start;
    [SerializeField] Canvas _explanation;
    void Awake()
    {
        _explanation.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void OnButton()
    {
        _explanation.enabled = true;
        _start.enabled = false;
    }
    public void returns()
    {
        _explanation.enabled = false;
        _start.enabled = true;
    }
}
