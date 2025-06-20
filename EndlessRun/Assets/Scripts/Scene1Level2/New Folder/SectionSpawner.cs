using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    public GameObject[] sectionsToSpawn;

	public int Index;

	private GameObject chosenSection;
	private Vector3 currentPosition;
	
	 void OnTriggerEnter(Collider other){
		 if (other.CompareTag("Player"))
		 {
			 Debug.Log("Spawning new section");
			 SpawnSection();
			 
		 }
	
	 }
	void SpawnSection(){
		currentPosition = new Vector3(transform.position.x + 15, transform.position.y, transform.position.x);

		Debug.Log($"New position created: {currentPosition}");
		
		Index = Random.Range(0, sectionsToSpawn.Length);
		Debug.Log($"Random section chosen {Index}");

		chosenSection = sectionsToSpawn[Index];

        Instantiate(chosenSection, currentPosition, Quaternion.identity);
	}
}
 