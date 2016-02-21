using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform goal;
	public Transform player;
	public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		agent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = player.position;
	}
}
