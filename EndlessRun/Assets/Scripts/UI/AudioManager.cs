using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region 
    public static AudioManager Instance;
    public AudioSource sfxSource;

    #endregion

    // add all your audio clip references here
    #region Audio clips
    [SerializeField] AudioClip bottlePickup;

    #endregion

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
