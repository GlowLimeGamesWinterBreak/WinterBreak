using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public GameObject playerCamera;
	public float upDownRange = 60.0f;
	float verticalRotation = 0;
	float verticalVelocity = 0;
	public float jumpSpeed = 7.0f;
	public bool jump = false;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}


	// Update is called once per frame
	void Update () {
		CharacterController cc = GetComponent<CharacterController> ();

		//rotation
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);
		float rotUpDown = Input.GetAxis ("Mouse Y") * mouseSensitivity;

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		//movement

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if (cc.isGrounded && Input.GetButton ("Jump") && jump == true) {
			verticalVelocity = jumpSpeed;
		}

		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed * movementSpeed); //x,y,z forwardspeed is forward and back

		speed = transform.rotation * speed;


		//cc.SimpleMove(speed); //takes care of gravity, ignores y. jump/fly/explosion cannot use simple

		cc.Move (speed * Time.deltaTime); //does not expect speed, it expects how many units of distance traveling this frame

	}

	void OnTriggerEnter (Collider col){
		print (col.gameObject.name);
		if (col.gameObject.name == "Powerup" || col.gameObject.name == "Powerup(Clone)") {
			jump = true;
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy(Clone)") {
			Destroy (this);
		}
	}
}
