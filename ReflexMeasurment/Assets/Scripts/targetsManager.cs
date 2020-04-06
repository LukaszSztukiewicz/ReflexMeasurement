using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetsManager : MonoBehaviour
{
    int childNumber=6;
    System.Random rand;
    public GameObject target;
    private GameObject tar2=null;
    // Start is called before the first frame update
    void Start()
    {
        childNumber = transform.childCount;
        //Debug.Log(transform.childCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0))
        {
            if (tar2 != null)
            { Destroy(tar2); tar2 = null; }

            Choose(out tar2);
        }
    }
    void Choose(out GameObject tar)
    {
        Debug.Log("Wszedłem");
        rand = new System.Random();
        Transform coor=transform.GetChild(rand.Next(0, childNumber)).gameObject.transform;
        Debug.Log(coor.localPosition);
        tar=Instantiate(target, coor.position, coor.localRotation);
        //Instantiate(target, coor);
        
        
    }
}
