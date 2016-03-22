//using UnityEngine;
//using System.Collections;
//
//public class EnemyManager : MonoBehaviour { // source: Unity Survival Shooter tutorial
//
//	public gameObject enemy;
//	public float spawnTime = 3f;
//	public Transform[] spawnPoints;
//
//
//	// Use this for initialization
//	void Start () {
//		InvokeRepeating ("Spawn", spawnTime, spawnTime);
//	
//	}
//
//	void Spawn(){
//		// If the player has no health left...
////		if(playerHealth.currentHealth <= 0f)
////		{
////			// ... exit the function.
////			return;
////		}
//
//		// Find a random index between zero and one less than the number of spawn points.
//		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
//
//		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
//		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
//	}
//	
//	// Update is called once per frame
////	void Update () {
////	
////	}
//}
