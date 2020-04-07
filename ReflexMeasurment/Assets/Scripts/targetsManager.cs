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
    private bool isSkip=false;
    public Material material;
    public Texture2D tex;
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
            if (tar2 != null)
            { Destroy(tar2); tar2 = null;
                /*
                if(isSkip)
                {
                    MainMenuScrpit.playerInfo.lista.Add(new Info(-1, timer, 0f, 0f));
                    isSkip = false;
                }else if(isHit)
                    MainMenuScrpit.playerInfo.lista.Add(new Info(1, timer, 0f, 0f));
                else
                    MainMenuScrpit.playerInfo.lista.Add(new Info(0, timer, 0f, 0f));*/
                   
                timer = 0f; 
                Choose(out tar2); }      
            
                 
        }/*
        if(Input.GetKey(KeyCode.E))
        {
            material.mainTexture=tex;
        }
        /*
        if(Input.GetKey(KeyCode.E))
        {
            if (MainMenuScrpit.playerInfo.lista.Count == 0)
                Debug.Log("Puste!!!!!!");
            else
                Debug.Log(MainMenuScrpit.playerInfo.lista.Count);
        }*/
        timer += Time.deltaTime;
    }
    void Choose(out GameObject tar)
    {
        //Debug.Log("Wszedłem");
        rand = new System.Random();
        Transform coor=transform.GetChild(rand.Next(0, childNumber)).gameObject.transform;
        //Debug.Log(coor.localPosition);
        if (loadImage.textures.Count == 0)
            material.mainTexture = tex;
        material.mainTexture = loadImage.textures[rand.Next(0,loadImage.textures.Count)];
        tar=Instantiate(target, coor.position, Quaternion.Euler(-90f,0f,-90f));
        //Instantiate(target, coor);
        
        
    }
    public void Skip()
    {
        isSkip = true;
    }
    bool Shoot()
    {
       
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000f, mask))
            return true;
        else
            return false;
    }
}
