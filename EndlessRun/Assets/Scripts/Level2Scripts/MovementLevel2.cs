using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class MovementLevel2 : MonoBehaviour
{
    public float speed = 5f;
    public float countdownTime = 10f;
    public AudioClip DeathSound;
    public TextMeshProUGUI countdownText;

    private int lastSecond = -1;
    private bool isAlive = true;

    void Update()
    {
        if (!isAlive) return;

    
        countdownTime -= Time.deltaTime;
        if (countdownTime < 0f)
        {
            countdownTime = 0f;
            Die();
        }

        int currentSecond = Mathf.FloorToInt(countdownTime);
        if (currentSecond != lastSecond)
        {
            lastSecond = currentSecond;
            countdownText.text = "Time remaining: " + currentSecond + "s";
        }

        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        if (!isAlive) return;

        isAlive = false;
        speed = 0f;
        countdownText.text = "Game Over"; 
        AudioManager.Instance.PlaySound(DeathSound);
        FindObjectOfType<GameManagerLevel2>().GameOver();
    }
}
