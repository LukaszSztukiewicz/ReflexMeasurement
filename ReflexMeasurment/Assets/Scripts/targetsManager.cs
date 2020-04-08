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

    //Lukasz
    public GameObject GUII;
    private bool isPausedd;
    public GameObject gun;

    void Start()
    {
        childNumber = transform.childCount;
        Choose(out tar2);
    }

    void Update()
    {
        isPausedd = GUII.GetComponent<PauseScrpit>().iSPaused;
        if (isPausedd == false)
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
                    
                    if (isSkip)
                    {
                        MainMenuScrpit.playerInfo.lista.Add(new Info(-1, timer, Vector2.zero));
                        isSkip = false;
                    }
                    else if (isHit)
                    {
                        MainMenuScrpit.playerInfo.lista.Add(new Info(1, timer, coor));
                        //Gunshot
                        GUII.GetComponent<AudioSource>().PlayOneShot(GUII.GetComponent<AudioSource>().clip);
                        gun.GetComponent<AudioSource>().PlayOneShot(gun.GetComponent<AudioSource>().clip);
                    }
                    else
                    {
                        MainMenuScrpit.playerInfo.lista.Add(new Info(0, timer, Vector2.zero));
                        //Gunshot
                        gun.GetComponent<AudioSource>().PlayOneShot(gun.GetComponent<AudioSource>().clip);
                    }
                    timer = 0f;
                    Choose(out tar2);
                }


            }
            timer += Time.deltaTime;
        }
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
        { material.mainTexture = loadImage.textures[rand.Next(0, loadImage.textures.Count)]; Debug.Log(material.mainTexture.width + " " + material.mainTexture.height); }
        tar = Instantiate(target, coor.position, Quaternion.Euler(-90f, 0f, -90f));


    }
    public void Skip()
    {
        isSkip = true;
    }
    public void deSkip()
    {
        isSkip = false;
    }
    bool Shoot(out Vector2 coor)
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000f, mask))
        {
            Debug.Log(material.mainTexture.width + " " + material.mainTexture.height);
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
