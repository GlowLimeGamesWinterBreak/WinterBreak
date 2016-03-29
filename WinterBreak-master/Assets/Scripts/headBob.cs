using UnityEngine;
using System.Collections;

public class headBob : MonoBehaviour {

	private float timer = 0.0f; 
	float bobbingSpeed = 1.5f; 
	float bobbingAmount = 1.0f; 
	float midpoint = 2.0f;

	void Start(){
	}

	void Update () { 
		var waveslice = 0.0; 
		float horizontal = Input.GetAxis("Horizontal"); 
		float vertical = Input.GetAxis("Vertical"); 
		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 
			timer = 0.0f; 
		} 
		else { 
			waveslice = Mathf.Sin(timer); 
			timer = timer + bobbingSpeed; 
			if (timer > Mathf.PI * 2) { 
				timer = timer - (Mathf.PI * 2); 
			} 
		} 
		if (waveslice != 0) { 
			var translateChange = waveslice * bobbingAmount; 
			var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f); 
			translateChange = totalAxes * translateChange;
			var temp = transform.localPosition;
			float y = midpoint + (float)translateChange;
			transform.localPosition.Set(temp.x, y, temp.z); 
		} 
		else { 
			var temp = transform.localPosition;
			float y = midpoint;
			transform.localPosition.Set(temp.x, y, temp.z); 
		} 
	}
}
