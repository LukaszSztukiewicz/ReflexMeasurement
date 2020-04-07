using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class loadImage : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<Texture2D> textures=new List<Texture2D>();
    void Start()
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("Images");
            if (directoryInfo.Exists)
                Debug.Log("Jest folder");
            else
                directoryInfo.Create();

            FileInfo[] fileList = directoryInfo.GetFiles();
            foreach (var fi in fileList)
            {
                if (fi.Extension == ".jpg"||fi.Extension==".png")
                {
                    byte[] fileData;
                    fileData = File.ReadAllBytes(fi.FullName);
                    Texture2D tex=new Texture2D(256,512);
                    tex.LoadImage(fileData);
                    textures.Add(tex);
                }
            }
            Debug.Log(textures.Count);
        }
        catch(Exception ex)
        { Debug.Log(ex); }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
