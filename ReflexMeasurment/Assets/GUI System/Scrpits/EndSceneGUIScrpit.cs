using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class EndSceneGUIScrpit : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI playername;

    private readonly string path = @"scores.csv";

    private playerInfo playerInfo;

    void Start()
    {
        playerInfo = GameMenager.playerInfo;
        scoretext.text = calcScore(playerInfo.lista);

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
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            Application.Quit();
        }



    }
    public string calcScore(List<Info> listaa)
    {
        float temp = 0;
        foreach (var elem in listaa)
            temp += elem.time;
        temp *= 1000;
        return temp.ToString("n1");
    }
    public void Again()
    {
        playerInfo.lista = new List<Info>();
        SceneManager.LoadScene(0);
    }
}
