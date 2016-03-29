using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour {

	Image fade;
	int fadeDir = 0;
	// Use this for initialization
	void Start () {
		fade = GetComponent<UnityEngine.UI.Image> ();
		//fade.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
		fade.color = Color.black;
		//fade.color = Color.black;

	}

	public void toBlack(){
		fadeDir = -1;
		fade.color = Color.Lerp (fade.color, Color.black, .8f * Time.deltaTime);
	}

	public void toClear(){
		fadeDir = 1;
		fade.color = Color.Lerp (fade.color, Color.clear, .8f * Time.deltaTime);
	}
	// Update is called once per frame
	void Update () {
		if(fadeDir == 1)
			fade.color = Color.Lerp (fade.color, Color.clear, .8f * Time.deltaTime);
		else if(fadeDir == -1)
			fade.color = Color.Lerp (fade.color, Color.black, .8f * Time.deltaTime);
	}
}
