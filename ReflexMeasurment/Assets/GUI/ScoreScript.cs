using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public GameObject listHolder;

    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = calcScore(MainMenuScrpit.playerInfo.lista);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public string calcScore(List<Info> listaa)
    {
        float temp = 0;
        foreach (var elem in listaa)
            temp += elem.time;
        temp *= 1000;
        return temp.ToString("n1");
    }
}
