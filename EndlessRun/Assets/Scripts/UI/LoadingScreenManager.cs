using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;
    public GameObject M_LoadingScreen;
    public Slider progressBar;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void SwitchToScene(int id)
    {
        M_LoadingScreen.SetActive(true);
        progressBar.value = 0;
        StartCoroutine(SwitchToSceneAsyc(id));
        
    }
    IEnumerator SwitchToSceneAsyc(int id)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);
        while (!asyncLoad.isDone) 
        { 
            progressBar.value = asyncLoad.progress;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        M_LoadingScreen.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
