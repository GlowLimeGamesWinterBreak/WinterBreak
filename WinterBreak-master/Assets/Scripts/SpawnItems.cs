using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {
	//some placeholder vector3s for now, we can change it once we have the map
	Vector3[] itemSpawnPoints = {new Vector3 (0.0f, 0.5f, 0.0f), new Vector3 (2.0f, 0.5f, 2.0f), new Vector3 (-2.0f, 0.5f, -2.0f)};
	bool[] item = { false, false, false };

	//we can put the gameobjects in once we import them into the game
	public GameObject obj;
	//public GameObject[] powerUps = {obj};

	public int timeToSpawn = 0;
	public int spawnTime = 3;
	public int numOfPowerups = 0;

	void Start () {
		//spawn the first set of power ups, can add more if we decide we want more powerups at the start
		//Instantiate (obj, itemSpawnPoints [Random.Range(0, itemSpawnPoints.Length)], Quaternion.identity);
	}



	// Update is called once per frame

	void Update () {

		if (Time.time >= timeToSpawn) {//&& slots not all full

			timeToSpawn += spawnTime;
			//only spawn at unused points
			int val = allTrue();
			if (val != -1) {
				Instantiate (obj, itemSpawnPoints [val], Quaternion.identity);
				item [val] = true;
			}

		}

		//TO ADD: check if there is already a powerup at that spawn location before spawning a new one
	}

	int allTrue(){
		for(int i = 0; i < item.Length; i++){
			if (item [i] == false)
				return i;
		}
		return -1;
	}

	public void powerupGone(Vector3 pos){
		for (int i = 0; i < itemSpawnPoints.Length; i++) {
			if(pos.Equals(itemSpawnPoints[i])){
				item[i] = false;
				break;
			}
		}
	}
}
