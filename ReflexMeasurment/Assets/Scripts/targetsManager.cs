using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetsManager : MonoBehaviour
{
    int childNumber = 6;
    System.Random rand;
    public GameObject target;
    public GameObject test;
    private GameObject tar2 = null;
    public Camera mainCamera;
    public LayerMask mask;
    private float timer = 0f;
    private bool isSkip = false;
    public Material material;
    public Texture2D tex;
    void Start()
    {
        childNumber = transform.childCount;
        Choose(out tar2);
    }

    void Update()
    {
        bool isHit;
        Vector2 coor;
        if (Input.GetMouseButtonDown(0))
        {
            isHit = Shoot(out coor);
            if (tar2 != null)
            {
                Destroy(tar2); tar2 = null;
                //Zapisy
                
                if(isSkip)
                {
                    MainMenuScrpit.playerInfo.lista.Add(new Info(-1, timer, Vector2.zero));
                    isSkip = false;
                }else if(isHit)
                    MainMenuScrpit.playerInfo.lista.Add(new Info(1, timer, coor));
                else
                    MainMenuScrpit.playerInfo.lista.Add(new Info(0, timer, Vector2.zero));

                timer = 0f;
                Choose(out tar2);
            }


        }
        timer += Time.deltaTime;
    }
    void Choose(out GameObject tar)
    {
        rand = new System.Random();
        Transform coor=transform.GetChild(rand.Next(0, childNumber)).gameObject.transform;
        material.mainTexture = tex;
        //zmiana tekstury      
        if (loadImage.textures.Count == 0)
            material.mainTexture = tex;
        else
            material.mainTexture = loadImage.textures[rand.Next(0,loadImage.textures.Count)];
        tar = Instantiate(target, coor.position, Quaternion.Euler(-90f, 0f, -90f));


    }
    public void Skip()
    {
        isSkip = true;
    }
    bool Shoot(out Vector2 coor)
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000f, mask))
        {
            coor  =new Vector2(hit.textureCoord2.x*(float)material.mainTexture.width,Mathf.Abs((float)material.mainTexture.height*(1-hit.textureCoord2.y)));
            return true;
        }
        else
        {
            coor = Vector2.zero;
            return false;
        }
            
    }
}
