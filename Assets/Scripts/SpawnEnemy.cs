using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject obj;
	public Transform[] spawnPoints;
	public GameObject floor;
	float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
		minX = -50;//gameObject.GetComponent<Collider> ().bounds.min.x;
		maxX = 50;//gameObject.GetComponent<Collider> ().bounds.max.x;
		minY = -50;//gameObject.GetComponent<Collider> ().bounds.min.y;
		maxY = 50;//gameObject.GetComponent<Collider> ().bounds.max.y;


		Vector3 spawn = new Vector3 (Random.Range (minX, maxX), .5f, Random.Range (minY, maxY));

		obj.GetComponent<Renderer> ().material.color = Color.red;
		Instantiate (obj, spawn, Quaternion.Euler(new Vector3(0,0,0)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
