using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadSceneAsync(1);
        LoadingScreenManager.Instance.SwitchToScene(1);
    }
    public void HowToPlay()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Home()
    {
        Debug.Log("ButtonClicked");
        SceneManager.LoadScene(0);
    }
}