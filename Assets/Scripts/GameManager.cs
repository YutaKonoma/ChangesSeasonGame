public class GameManager :SingletonMonoBehaviour<GameManager> 
{
    public bool IsActive { get; private set; }

    private void Start()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        else DontDestroyOnLoad(gameObject);
    }
}
