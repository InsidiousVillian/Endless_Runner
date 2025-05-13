using System.Collections;
using UnityEngine;

public class HighNoonEffect : MonoBehaviour
{
    private float slowTimeScale = 0.5f;
    private float HighNoonDuration = 3f;

    public void TriggerHighNoon()
    {
       
        StartCoroutine(SlowMotionRoutine());
         
    }

    private IEnumerator SlowMotionRoutine()
    {
        // slows entire game
        Time.timeScale = slowTimeScale;

        //adjusts physics timesteps to match slowe time
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        //wait for a few seconds before resetting time
        yield return new WaitForSecondsRealtime(HighNoonDuration);

        //resets back to normal
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
