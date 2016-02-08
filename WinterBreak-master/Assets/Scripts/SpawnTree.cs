using UnityEngine;
using System.Collections;

public class SpawnTree : MonoBehaviour {

	public GameObject obj;
	public Transform[] spawnPoints;
	public GameObject floor;
	float minX, maxX, minY, maxY;

	// Use this for initialization
	void Start () {
		minX = -400;//gameObject.GetComponent<Collider> ().bounds.min.x;
		maxX = 400;//gameObject.GetComponent<Collider> ().bounds.max.x;
		minY = -400;//gameObject.GetComponent<Collider> ().bounds.min.y;
		maxY = 400;//gameObject.GetComponent<Collider> ().bounds.max.y;


		for(int i =0 ; i<300; i++){
			Vector3 spawn = new Vector3 (Random.Range (minX, maxX), .5f, Random.Range (minY, maxY));

			obj.GetComponent<Renderer> ().material.color = Color.green;
			Instantiate (obj, spawn, Quaternion.Euler(new Vector3(0,0,0)));
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		Destroy (this.gameObject);
	}
}

