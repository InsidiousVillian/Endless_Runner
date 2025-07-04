using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MasterInfo : MonoBehaviour
{
    [SerializeField] GameObject bottleDisplay;
    [SerializeField] GameObject gunDisplay;
    [SerializeField] GameObject highNoonDisplay;
    [SerializeField] GameObject bossBottleDisplay;
    [SerializeField] public TextMeshProUGUI highscore;
    public static int bottleCount = 0;

    public static int BossBottleCount = 0;
    

    public int MaxBossbottles = 15;

    private void Start()
    {
        Debug.LogError(this.name + " HELL");


        if (bottleDisplay == null)
        {
            bottleDisplay = GameObject.Find("BottleCount");

        }
        if (gunDisplay == null)
        {
            gunDisplay = GameObject.Find("gunCount");

        }
        if (highNoonDisplay == null)
        {
            highNoonDisplay = GameObject.Find("HighNoonCount");

        }


        if (bottleDisplay == null || gunDisplay == null || highNoonDisplay == null)
        {
            Debug.LogWarning("One or more UI elements are missing in the scene.");
        }

        bottleCount = 0;

        if (ItemPickup.guns != null)
        {
            ItemPickup.guns.Clear();
        }
        if (HighNoonPickup.highNoonList != null)
        {
            HighNoonPickup.highNoonList.Clear();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (bottleDisplay && gunDisplay && highNoonDisplay)
        {
            bottleDisplay.GetComponent<TMPro.TMP_Text>().text = "Bottles: " + bottleCount;
            gunDisplay.GetComponent<TMPro.TMP_Text>().text = "Guns: " + ItemPickup.guns.Count;
            highNoonDisplay.GetComponent<TMPro.TMP_Text>().text = "High Noon: " + HighNoonPickup.highNoonList.Count;
            bossBottleDisplay.GetComponent<TMPro.TMP_Text>().text = "Bottles:" + BossBottleCount;
        }
        HighScore();
        CheckHighScore();
        UpdateHighScore();

        if (BossBottleCount >= MaxBossbottles)
        {
            Debug.Log("Scene change");
            SceneManager.LoadScene("BossLevel2");
        }

    }
    void HighScore()
    {
        PlayerPrefs.SetInt("HighScore", bottleCount);
    }
    void CheckHighScore()
    {
        if (bottleCount > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("Highschool", bottleCount);
        }
    }
    void UpdateHighScore()
    {
        highscore.text = $"HighScore:{PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
