using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = calcScore(GameMenager.playerInfo.lista);
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
