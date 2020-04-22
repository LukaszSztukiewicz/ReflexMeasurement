using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Info
{
    public int z { get; set; }
    public float time { get; set; }
    public Vector2 coordinates { get; set; }
    public Info(int z,float time,Vector2 coordinates)
    {
        this.z = z;
        this.time = time;
        this.coordinates = coordinates;
        
    }
}
public class playerInfo
{
    public List<Info> lista = new List<Info>();
}
