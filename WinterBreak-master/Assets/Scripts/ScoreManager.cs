using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static int score;


	Text text;
	float timer = 0f; //
	bool isCounting = false; //


	void Awake ()
	{
//		text = GetComponent <Text> ();
		text = GetComponent<UnityEngine.UI.Text>();
		score = 0;
		isCounting = !isCounting; //
	}


	void Update ()
	{
		//        score += (int)Time.deltaTime;
		text.text = "Score: " + score;
		if (isCounting) { //
			timer += Time.deltaTime;
			if (timer > 1f) {
				score += 1;
				timer -= 1f;
			}
		}
	}

}
