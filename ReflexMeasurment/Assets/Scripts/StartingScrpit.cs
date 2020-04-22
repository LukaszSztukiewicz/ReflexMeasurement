using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boxes;
    public GameObject StartGUI;
    public GameObject SkipButton;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartGUI.activeSelf)
        {
            boxes.GetComponent<targetsManager>().enabled = true;
            SkipButton.SetActive(true);
        }
    }
}
