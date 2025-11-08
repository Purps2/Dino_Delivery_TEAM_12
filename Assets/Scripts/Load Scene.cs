using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneByID(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
