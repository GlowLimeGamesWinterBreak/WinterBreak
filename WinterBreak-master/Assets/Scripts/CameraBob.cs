using UnityEngine;
using System.Collections;

public class CameraBob : MonoBehaviour {
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
