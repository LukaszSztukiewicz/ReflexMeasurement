using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScrpit : MonoBehaviour
{
    // Start is called before the first frame update

    public bool iSPaused;

    public GameObject pausemenu;

    void Start()
    {
        iSPaused = false;
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (iSPaused)
            {
                iSPaused = false;
                Resume();
                
            }
            else
            {
                iSPaused = true;
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        iSPaused = false;
        Time.timeScale = 1f;
        pausemenu.SetActive(false);


    }

    public void Pause()
    {
        iSPaused = true;
        Time.timeScale = 0f;
        pausemenu.SetActive(true);

    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        iSPaused = false;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
        iSPaused = false;
    }
}

