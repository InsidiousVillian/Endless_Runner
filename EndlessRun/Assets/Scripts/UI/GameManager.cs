using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameOver(){
        gameOverUI.SetActive(true);
    }

    [MenuItem("Helpers/Restart Scene #R")]
    private static void restart()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(1);


    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void Quit(){
        Application.Quit();
    }
    public void Play(){
        SceneManager.LoadScene(1);
    }
}
