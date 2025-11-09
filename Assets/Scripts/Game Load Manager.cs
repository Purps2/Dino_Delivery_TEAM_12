using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        Debug.Log("Exit Game to Main Menu");
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene(1);
    }

    public void CloseApplication()
    {
        Debug.Log("Close Application");
        Application.Quit();
    }
}
