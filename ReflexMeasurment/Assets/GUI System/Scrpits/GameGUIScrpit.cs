using UnityEngine;


public class GameGUIScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetsMenager;
    public GameObject StartGUI;
    public GameObject NonDestructUI;
    public GameObject EndGUI;

    void Start()
    {
        GameMenager.GameState = GameMenager.GameStates.Running;
        StartGame();
        Time.timeScale = 0f;
    }

    public void Play()
    {
        targetsMenager.SetActive(true);
        Time.timeScale = 1f;
        NonDestructUI.SetActive(true);
        StartGUI.SetActive(false);
    }
    public void StartGame()
    {
        targetsMenager.SetActive(false);
        StartGUI.SetActive(true);
    }
    public void EndGame()
    {
        targetsMenager.GetComponent<targetsManager>().enabled = false;
        EndGUI.SetActive(true);
        EndGUI.GetComponent<EndSceneScrpit>().End();
        NonDestructUI.SetActive(true);
    }
}
