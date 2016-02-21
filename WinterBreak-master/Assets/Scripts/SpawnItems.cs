using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {
	//some placeholder vector3s for now, we can change it once we have the map
	Vector3[] itemSpawnPoints = {new Vector3 (0.0f, 0.5f, 0.0f), new Vector3 (2.0f, 0.5f, 2.0f), new Vector3 (-2.0f, 0.5f, -2.0f)};

	//we can put the gameobjects in once we import them into the game
	public GameObject obj;
	//public GameObject[] powerUps = {obj};

	public int timeToSpawn = 0;
	public int spawnTime = 10;

	void Start () {
		//spawn the first set of power ups, can add more if we decide we want more powerups at the start
		//Instantiate (obj, itemSpawnPoints [Random.Range(0, itemSpawnPoints.Length)], Quaternion.identity);

	}



	// Update is called once per frame

	void Update () {

		if (Time.time >= timeToSpawn) {

			timeToSpawn += spawnTime;
			//GameObject obj2 = this.gameObject;
			Instantiate (obj, itemSpawnPoints [Random.Range(0, itemSpawnPoints.Length)], Quaternion.identity);

		}

		//TO ADD: check if there is already a powerup at that spawn location before spawning a new one

	}
}
