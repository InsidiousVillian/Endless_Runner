using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManagerLevel2 : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("MAIN GAME LEVEL");
       
    }
}
