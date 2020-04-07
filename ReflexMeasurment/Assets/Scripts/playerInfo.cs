using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Info
{
    public int z { get; set; }
    public float time { get; set; }
    public float x { get; set; }
    public float y { get; set; }
    public Info(int z,float time,float x,float y)
    {
        this.z = z;
        this.time = time;
        this.x = x;
        this.y = y;
        
    }
}
public class playerInfo
{
    public List<Info> lista = new List<Info>();
}
