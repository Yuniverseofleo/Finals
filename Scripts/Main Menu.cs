using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string mainMenuMusic = "MainMenu";
    [SerializeField] private string gameMusic = "Game";

    private void Start()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PlayMusic(mainMenuMusic);
        }
    }

    public void Play()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PlayMusic(gameMusic);
        }

        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
