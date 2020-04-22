using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class targetsManager : MonoBehaviour
{
    int childNumber = 6;
    public GameObject target;
    public GameObject test;
    private GameObject tar2 = null;
    public Camera mainCamera;
    public LayerMask mask;
    private float timer = 0f;

    public Material material;
    public Texture2D tex;
    public GameObject child;
    public ParticleSystem flash;
    private bool isHit;
    private Vector2 coor;
    private RaycastHit hit;
    Animator anim;
    //Lukasz
    public GameObject GameGUI;
    private bool isSkip = false;

    public AudioClip gunshot;
    public AudioClip confirmation;
    public AudioSource audioSource;

    public List<int> rand = new List<int>() { 1, 2, 5, 2, 7, 4, 2, 3, 1, 4, 2, 3, 8, 3, 6, 4, 5, 7, 3, 2, 1 };
    public int x = 0;




    void Start()
    {
        anim = child.GetComponent<Animator>();
        childNumber = transform.childCount;
        Choose(out tar2);
        audioSource = GameGUI.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GameMenager.GameState == GameMenager.GameStates.Running)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(gunshot);
                anim.SetTrigger("Shoot"); flash.Play();

                isHit = Shoot(out coor);
                if (tar2 != null)
                {
                    RejestrShot();
                }
            }
            timer += Time.deltaTime;
        }
    }

    IEnumerator Wait(Action AfterWait)
    {
        yield return new WaitForSeconds(rand[x] / 2);
        AfterWait();
    }
    void Choose(out GameObject tar)
    {
        Transform coor=transform.GetChild(rand[x]%childNumber).gameObject.transform;
        material.mainTexture = tex;
        //zmiana tekstury      
        if (loadImage.textures.Count == 0)
            material.mainTexture = tex;
        else
            material.mainTexture = loadImage.textures[(x)%(loadImage.textures.Count)];

        tar = Instantiate(target, coor.position, Quaternion.Euler(-90f, 0f, -90f));
    }

    bool Shoot(out Vector2 coor)
    {

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
    public void RejestrShot()
    {
        //Zapisy               
        if (isSkip)
        {
            GameMenager.playerInfo.lista.Add(new Info(-1, timer, Vector2.zero));
            isSkip = false;
            timer = 0f;
            Destroy(tar2); tar2 = null;
            x++;
            if (x >= loadImage.textures.Count)
            {
                GameMenager.GameState = GameMenager.GameStates.OnEndGame;
                GameGUI.GetComponent<GameGUIScrpit>().EndGame();
            }
            StartCoroutine(Wait(() =>
            {
                Choose(out tar2);
            }));
        }
        else if (isHit)
        {
            GameMenager.playerInfo.lista.Add(new Info(1, timer, coor));

            audioSource.PlayOneShot(confirmation);

            timer = 0f;
            Destroy(tar2); tar2 = null;
            x++;
            if (x >= loadImage.textures.Count)
            {
                GameMenager.GameState = GameMenager.GameStates.OnEndGame;
                GameGUI.GetComponent<GameGUIScrpit>().EndGame();
            }
            StartCoroutine(Wait(() =>
            {
                Choose(out tar2);
            }
            ));
        }
        else
        {
            GameMenager.playerInfo.lista.Add(new Info(0, timer, Vector2.zero));
        }
    }

    public void Skip()
    {
        isSkip = true;
    }
    public void deSkip()
    {
        isSkip = false;
    }
}
