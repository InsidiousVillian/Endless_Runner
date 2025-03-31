using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameOver(){
        gameOverUI.SetActive(true);
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit(){
        Application.Quit();
    }
    public void Play(){
        SceneManager.LoadScene("Level");
    }
}
