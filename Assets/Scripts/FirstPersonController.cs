using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public GameObject playerCamera;
	public float upDownRange = 60.0f;
	float verticalRotation = 0;
	float verticalVelocity = 0;
	public float jumpSpeed = 7.0f;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	 	characterController = GetComponent<CharacterController> ();

	}


	// Update is called once per frame
	void Update () {
		//checkSprint

		//rotation
		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotLeftRight, 0);

		verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
		playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		//movement

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if (characterController.isGrounded && Input.GetButton("Jump")) {
			verticalVelocity = jumpSpeed;
		}

		Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed * movementSpeed); //x,y,z forwardspeed is forward and back

		speed = transform.rotation * speed;


		//cc.SimpleMove(speed); //takes care of gravity, ignores y. jump/fly/explosion cannot use simple

		characterController.Move (speed * Time.deltaTime); //does not expect speed, it expects how many units of distance traveling this frame

	}
}
