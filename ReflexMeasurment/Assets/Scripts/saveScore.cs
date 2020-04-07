using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveScore : MonoBehaviour
{
    private playerInfo playerInfo = MainMenuScrpit.playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var elem in playerInfo.lista)
            Debug.Log(isHit(elem.z) + " " + elem.time + " " + elem.x + " " + elem.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    string isHit(int a)
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
    }
}
