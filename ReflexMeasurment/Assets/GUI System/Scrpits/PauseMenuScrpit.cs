using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScrpit : MonoBehaviour
{
    public GameObject pausemenu;

    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameMenager.GameState == GameMenager.GameStates.Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        GameMenager.GameState = GameMenager.GameStates.Running;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pausemenu.SetActive(true);
        GameMenager.GameState = GameMenager.GameStates.Paused;
        Time.timeScale = 0f;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void Save()
    {
        GameMenager.GameState = GameMenager.GameStates.OnMenu;
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

