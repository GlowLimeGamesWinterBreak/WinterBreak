using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

	// Use this for initialization
	int type = -1;
	void Start () {
		type = Random.Range (0, 2);
		if (type == 0)
			GetComponent<Renderer> ().material.SetColor ("_Color", new Color (0, 1, 0));
		else if (type == 1)
			GetComponent<Renderer> ().material.SetColor("_Color", new Color (0, 0, 1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getVal(){
		return type;
	}
}
