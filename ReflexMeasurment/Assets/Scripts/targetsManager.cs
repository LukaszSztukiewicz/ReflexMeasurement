using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetsManager : MonoBehaviour
{
    int childNumber=6;
    System.Random rand;
    public GameObject target;
    private GameObject tar2=null;
    public Camera mainCamera;
    public LayerMask mask;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        childNumber = transform.childCount;
        Choose(out tar2);
        //Debug.Log(transform.childCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        bool isHit;
        if(Input.GetMouseButtonDown(0))
        {
            isHit=Shoot();
            if (tar2 != null&&isHit)
            { Destroy(tar2); tar2 = null;Debug.Log("Czas strzału: " + timer);timer = 0f; Choose(out tar2); }      
            
                 
        }
        timer += Time.deltaTime;
    }
    void Choose(out GameObject tar)
    {
        //Debug.Log("Wszedłem");
        rand = new System.Random();
        Transform coor=transform.GetChild(rand.Next(0, childNumber)).gameObject.transform;
        //Debug.Log(coor.localPosition);
        tar=Instantiate(target, coor.position, coor.localRotation);
        //Instantiate(target, coor);
        
        
    }
    bool Shoot()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f, mask))
            return true;
        else
            return false;
    }
}
