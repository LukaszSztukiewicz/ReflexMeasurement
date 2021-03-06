﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class targetsManager : MonoBehaviour
{
    int childNumber = 6;
    //System.Random rand;
    public GameObject target;
    public GameObject test;
    private GameObject tar2 = null;
    public Camera mainCamera;
    public LayerMask mask;
    private float timer = 0f;
    private bool isSkip = false;
    public Material material;
    public Texture2D tex;
    public GameObject child;
    public ParticleSystem flash;
    Animator anim;
    //Lukasz
    public GameObject GUII;
    private bool isPausedd;
    public GameObject gun;
    public List<int> rand = new List<int>() { 1, 2, 5, 5, 7, 7, 2, 3, 1, 4, 8, 9, 8, 9, 3, 4, 5, 7, 3, 2, 1 };
    public int x = 0;


    void Start()
    {
        anim = child.GetComponent<Animator>();
        childNumber = transform.childCount;
        Choose(out tar2);
    }

    void Update()
    {
        if (x > loadImage.textures.Count)
            SceneManager.LoadScene(2);
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
                    //Zapisy               
                    if (isSkip)
                    {
                        MainMenuScrpit.playerInfo.lista.Add(new Info(-1, timer, Vector2.zero));
                        isSkip = false;
                        timer = 0f;
                        Destroy(tar2); tar2 = null;
                        Choose(out tar2);
                    }
                    else if (isHit)
                    {
                        MainMenuScrpit.playerInfo.lista.Add(new Info(1, timer, coor));
                        //Gunshot
                        GUII.GetComponent<AudioSource>().PlayOneShot(GUII.GetComponent<AudioSource>().clip);
                        gun.GetComponent<AudioSource>().PlayOneShot(gun.GetComponent<AudioSource>().clip);
                        anim.SetTrigger("Shoot"); flash.Play();
                        timer = 0f;
                        Destroy(tar2); tar2 = null;

                        StartCoroutine(Wait());
                    }
                    else
                    {
                        MainMenuScrpit.playerInfo.lista.Add(new Info(0, timer, Vector2.zero));
                        timer = 0f;
                        anim.SetTrigger("Shoot"); flash.Play();
                        //Gunshot
                        gun.GetComponent<AudioSource>().PlayOneShot(gun.GetComponent<AudioSource>().clip);
                    }             
                }
            }
            timer += Time.deltaTime;
        }
    }
    IEnumerator Wait()
    {
        Choose(out tar2);
        yield return new WaitForSeconds(5);
    }
    void Choose(out GameObject tar)
    {
        Transform coor=transform.GetChild(rand[x]%childNumber).gameObject.transform;
        material.mainTexture = tex;
        //zmiana tekstury      
        if (loadImage.textures.Count == 0)
            material.mainTexture = tex;
        else
            material.mainTexture = loadImage.textures[(x++)%(loadImage.textures.Count)];

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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
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
