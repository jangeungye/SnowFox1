using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
   


    public void RestartStage()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        Time.timeScale = 1f;
    }
}
