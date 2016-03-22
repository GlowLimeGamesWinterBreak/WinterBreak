using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	//    public Text timerLabel;
	//    private float time = 0f;
	private float seconds = 0.0f;
	private float minutes = 0.0f;
	private float hours = 0.0f;

	void Update() {
		//        time += Time.deltaTime;
		seconds += Time.deltaTime;
		if (seconds > 60) {
			minutes += 1;
			seconds = 0;
		}
		if (minutes > 60) {
			hours += 1;
			minutes = 0;
		}

		//        print (hours + ":" + minutes + ":" + seconds);

		//        var minutes = time / 60; //Divide the guiTime by sixty to get the minutes.
		//        var seconds = time % 60;//Use the euclidean division for the seconds.
		//        var fraction = (time * 100) % 100;

		//update the label value
		//        timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
	}


	// UNCOMMENT THE BELOW CODE IF NEED TO DISPLAY THE TIME

//	private GUIStyle guiStyle = new GUIStyle ();
//
//	void OnGUI()
//	{
//		guiStyle.fontSize = 30;
//		guiStyle.normal.textColor = Color.black;
//		GUI.Label(new Rect(680,280,780,330), (int)hours + ":" + (int)minutes + ":" + (int)seconds, guiStyle);
//	}
}