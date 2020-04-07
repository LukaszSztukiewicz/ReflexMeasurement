using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPaused : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPausedd;
    public GameObject GUII;
    public GameObject target;
    void Start()
    {
        isPausedd = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPausedd = GUII.GetComponent<PauseScrpit>().iSPaused;
        if (isPausedd == true)
        {
            target.SetActive(false);
        }
        else 
        { 
            target.SetActive(true);
        }
    }
}
