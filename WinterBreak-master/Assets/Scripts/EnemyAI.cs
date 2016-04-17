using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform goal;
	public Transform player;
	public NavMeshAgent agent;
	public AudioSource playerNoise;
	bool chasePlayer;
	float minDistance;
	float visionDistance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		playerNoise = player.GetComponent<AudioSource>();
		chasePlayer = false;
		minDistance = 5;
		visionDistance = 200;
		agent.speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerNoise.isPlaying && CloseToPlayer ())
			chasePlayer = true;

		if (inFieldOfView ())
			chasePlayer = true;
		if(chasePlayer)
			agent.destination = player.position;
		else{
			NavMeshPath path;
			//agent.SetPath(
		}
	}

	bool CloseToPlayer(){
		Vector3 distance = player.position - this.transform.position;
		if (distance.magnitude < minDistance)
			return true;
		return false;
	}

	bool inFieldOfView(){
		Vector3 distance = player.position - this.transform.position;
		if (distance.magnitude > visionDistance)
			return false;
		Vector3 enemyToPlayer = player.position - this.transform.position;
		Vector3 enemyForward = this.transform.forward;

		float temp = Vector3.Angle (enemyToPlayer, enemyForward);
		if (temp < 45)
			return true;
		
		return false;
	}
}
