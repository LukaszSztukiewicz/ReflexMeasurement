using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMaker : MonoBehaviour
{
    private float Score;
    public TextMeshProUGUI scoretext;
    private int counter;


    // Start is called before the first frame update
    void Start()
    {
        scoretext.text =" 2";
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public float Get()
    {
        return Score;
    }
}
