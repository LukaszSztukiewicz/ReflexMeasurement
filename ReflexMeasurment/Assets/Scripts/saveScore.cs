using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class saveScore : MonoBehaviour
{
    private playerInfo playerInfo = GameMenager.playerInfo;
    private string path = @"scores.csv";
    public TextMeshProUGUI playername;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var elem in playerInfo.lista)
          Debug.Log(playername.text + ";" + elem.z + ";" + elem.time + ";" + elem.coordinates.x + ";" + elem.coordinates.y);
    }
    public void Save()
    {
        try
        {
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("person;shot_type;delta_time;coord_x;coord_y");
                    foreach (var elem in playerInfo.lista)
                        sw.WriteLine(playername.text + ";" + elem.z + ";" + elem.time + ";" + elem.coordinates.x + ";" + elem.coordinates.y);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (var elem in playerInfo.lista)
                        sw.WriteLine(playername.text + ";" + elem.z + ";" + elem.time + ";" + elem.coordinates.x + ";" + elem.coordinates.y);
                }
            }
        }
        catch(System.Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }
}

