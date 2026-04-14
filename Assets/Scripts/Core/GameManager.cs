using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGame()
    {
        LoadScene("GameBoard");
    }

    public void LoadDeck()
    {
        LoadScene("DeckManager");
    }

    public void LoadProfile()
    {
        LoadScene("Profile");
    }

    public void LoadAdmin()
    {
        LoadScene("AdminCards");
    }
    public void LoadCardLibrary()
    {
        LoadScene("CardGallery");
    }
}
