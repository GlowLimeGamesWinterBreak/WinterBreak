using UnityEngine;
using System.Collections;
<<<<<<< HEAD
=======
//
//public class CameraBob : MonoBehaviour {
//	float TopExtent;
//	float BotExtent;
//	float Speed;
//	bool BobbingUp;
//	Vector3 Change;
//	void Start(){
//		//height defines how high your head bobs up IN METERS
//		TopExtent = .1f;
//		BotExtent = transform.localPosition.y;
//		// speed is in m/s
//		Speed = .1f;
//		Change = Vector3.zero;
//		BobbingUp = true;
//	}
//	void Update(){
//		Change = new Vector3(0,Speed * Time.deltaTime,0);
//
//		if(BobbingUp)
//		{
//			if(transform.localPosition.y < TopExtent)
//				transform.localPosition += Change;
//			else
//				BobbingUp = false;
//		}
//		else{
//			if(transform.localPosition.y > BotExtent)
//				transform.localPosition -= Change;
//			else
//				BobbingUp = true;
//		}
//
//	}
//}
>>>>>>> a8612f9155253f7e01a27b9e4e9c7217cd44b1a9

public class CameraBob: MonoBehaviour 
{

	private float timer = 0.0f;
	float bobbingSpeed = 0.18f;
<<<<<<< HEAD
	float bobbingAmount = 0.4f;
	float midpoint = 2.0f;
	GameObject cc;

	void Start(){
		cc = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		if (cc.GetComponent<FirstPersonController>().verticalVelocity < .01f) {
			float waveslice = 0.0f;
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");

			Vector3 cSharpConversion = transform.localPosition; 

			if (Mathf.Abs (horizontal) == 0 && Mathf.Abs (vertical) == 0) {
				timer = 0.0f;
			} else {
				waveslice = Mathf.Sin (timer);
				timer = timer + bobbingSpeed;
				if (timer > Mathf.PI * 2) {
					timer = timer - (Mathf.PI * 2);
				}
			}
			if (waveslice != 0) {
				float translateChange = waveslice * bobbingAmount;
				float totalAxes = Mathf.Abs (horizontal) + Mathf.Abs (vertical);
				totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
				translateChange = totalAxes * translateChange;
				cSharpConversion.y = midpoint + translateChange;
			} else {
				cSharpConversion.y = midpoint;
			}

			transform.localPosition = cSharpConversion;
		}
=======
	float bobbingAmount = 0.2f;
	float midpoint = 2.0f;

	void Update () {
		float waveslice = 0.0f;
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 cSharpConversion = transform.localPosition; 

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
			float translateChange = waveslice * bobbingAmount;
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
			translateChange = totalAxes * translateChange;
			cSharpConversion.y = midpoint + translateChange;
		}
		else {
			cSharpConversion.y = midpoint;
		}

		transform.localPosition = cSharpConversion;
>>>>>>> a8612f9155253f7e01a27b9e4e9c7217cd44b1a9
	}



}