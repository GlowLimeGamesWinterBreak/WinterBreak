//using UnityEngine;
//using System.Collections;

//public class CameraShake : MonoBehaviour {



//	private float timer = 0.0f; 
//	float bobbingSpeed = 0.18f; 
//	float bobbingAmount = 0.2f; 
//	float midpoint = 2.0f; 
//
//	void Update () { 
//		float waveslice = 0.0f; 
//		horizontal = Input.GetAxis("Horizontal"); 
//		vertical = Input.GetAxis("Vertical"); 
//		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 
//			timer = 0.0; 
//		} 
//		else { 
//			waveslice = Mathf.Sin(timer); 
//			timer = timer + bobbingSpeed; 
//			if (timer > Mathf.PI * 2) { 
//				timer = timer - (Mathf.PI * 2); 
//			} 
//		} 
//		if (waveslice != 0) { 
//			translateChange = waveslice * bobbingAmount; 
//			totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
//			totalAxes = Mathf.Clamp (totalAxes, 0.0, 1.0); 
//			translateChange = totalAxes * translateChange; 
//			transform.localPosition.y = midpoint + translateChange; 
//		} 
//		else { 
//			transform.localPosition.y = midpoint; 
//		} 
//	}
//}

using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	float TopExtent;
	float BotExtent;
	float Speed;
	bool BobbingUp;
	Vector3 Change;
	void Start(){
		//height defines how high your head bobs up IN METERS
		TopExtent = .1f;
		BotExtent = transform.localPosition.y;
		// speed is in m/s
		Speed = .1f;
		Change = Vector3.zero;
		BobbingUp = true;
	}
	void Update(){
		Change = new Vector3(0,Speed * Time.deltaTime,0);

		if(BobbingUp)
		{
			if(transform.localPosition.y < TopExtent)
				transform.localPosition += Change;
			else
				BobbingUp = false;
		}
		else{
			if(transform.localPosition.y > BotExtent)
				transform.localPosition -= Change;
			else
				BobbingUp = true;
		}

	}
}
