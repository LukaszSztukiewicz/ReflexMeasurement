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
    public GameObject emptyText;
    public static playerInfo playerInfo;
    bool secondTry = false;

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
        //Włącza gre

        //jeżeli za pierwszym razem nie było plików, to próbuje załadować jeszcze raz 
        if (secondTry)
        { 
            loadImage.loadIm(); 
            secondTry = false;
        }//jeżeli są jakieś zdjęcia w folderze, to je ładuje
        if(loadImage.fileList.Length>0)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }else//w przeciwnym wypadku pokazuje napis że zdjęć nie ma
        {
            secondTry = true;
            emptyText.SetActive(true);
        }
        
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
