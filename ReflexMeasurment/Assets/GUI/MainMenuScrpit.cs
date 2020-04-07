using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScrpit : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject MoreMenu;
    public GameObject MoreButton;
    public GameObject StartButton;
    public static playerInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {
        playerInfo = new playerInfo();
        MoreMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void More()
    {
        MainMenu.SetActive(false);
        MoreMenu.SetActive(true);
    }
    public void Back()
    {
        MoreMenu.SetActive(false);
        MainMenu.SetActive(true);
       
    }
}
