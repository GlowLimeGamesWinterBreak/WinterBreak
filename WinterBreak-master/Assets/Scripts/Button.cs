using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public void loadScene (string level){
		Application.LoadLevel ("Untitled");
	}

	public void Update(){
		if (Input.GetKeyDown (KeyCode.Return)) {
			Application.LoadLevel ("Untitled");
		}
	}

//	// Use this for initialization
//	void Start () {
//	
//	}

}
