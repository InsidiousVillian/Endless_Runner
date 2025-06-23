using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPointBoss2 : MonoBehaviour
{
    public MasterInfo MasterInfo;

    public int MaxBossbottles = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottle"))
        {
            
            if (MasterInfo.BossBottleCount == MaxBossbottles)
            {
                Debug.Log("Scene Change");
                //SceneController.instance.NextLevel();
                SceneManager.LoadScene("BossLevel2");


            }
        }
    }
}
