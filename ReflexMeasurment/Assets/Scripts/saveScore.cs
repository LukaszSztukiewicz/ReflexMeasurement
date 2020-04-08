using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class saveScore : MonoBehaviour
{
    private playerInfo playerInfo = MainMenuScrpit.playerInfo;
    private string path = @"scores.csv";
    public TextMeshProUGUI playername;
    // Start is called before the first frame update
    void Start()
    {
        //foreach (var elem in playerInfo.lista)
        //   Debug.Log(playername.text + ";" + elem.z + ";" + elem.time + ";" + elem.coordinates[0] + ";" + elem.coordinates[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*string isHit(int a)
    {
        switch(a)
        {
            case 0:
                return "Pudło";
            case 1:
                return "Trafienie";
            case -1:
                return "Skipnięcie";
        }
        return "";
    }*/

    public void Save()
    {

        // This text is added only once to the file.
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("person;shot_type;delta_time;coord_x;coord_y");
                foreach (var elem in playerInfo.lista)
                    sw.WriteLine(playername.text +";" + elem.z + ";" + elem.time + ";" + elem.coordinates[0] + ";" + elem.coordinates[1]);
            }
        }
        else
        {
            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var elem in playerInfo.lista)
                    sw.WriteLine(playername.text + ";" + elem.z + ";" + elem.time + ";" + elem.coordinates[0] + ";" + elem.coordinates[1]);
            }
        }
        Application.Quit();
        
    }
}

