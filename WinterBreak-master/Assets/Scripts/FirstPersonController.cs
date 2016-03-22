using UnityEngine;
using UnityEngine.UI;
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
	public AudioSource walkSound;
	public float sptimer = 0.0f;
	public Slider sprintSlider;
	public bool damaged = false;

	PlayerHealth playerHealth;

	CharacterController characterController;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController> ();
		walkSound = GetComponent<AudioSource> ();
		GameObject temp = GameObject.FindGameObjectWithTag ("HealthSlider"); //
		if (temp != null) { //
			playerHealth = temp.GetComponent<PlayerHealth> (); //
//			pizzas = new Texture[pizzaIndex];
		} //
		GameObject temp2 = GameObject.FindGameObjectWithTag ("SprintSlider"); //
		if (temp2 != null) { //
			sprintSlider = temp2.GetComponent<Slider> (); //
//			sprintSlider.value = 0;
		} //
	}

	// Update is called once per frame
	void Update () {
		Screen.lockCursor = true;

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
		if (forwardSpeed < .01 && sideSpeed < .01)
			walkSound.Stop ();
		else if (walkSound.isPlaying != true)
			walkSound.Play ();


		//cc.SimpleMove(speed); //takes care of gravity, ignores y. jump/fly/explosion cannot use simple

		characterController.Move (speed * Time.deltaTime); //does not expect speed, it expects how many units of distance traveling this frame

	}

	void OnTriggerEnter (Collider col){
		print (col.gameObject.name);
		if (col.gameObject.name == "PowerupSprint" || col.gameObject.name == "PowerupSprint(Clone)") {
			jump = true;
			Destroy (col.gameObject);
			sprintSlider.value = 10;
			StartCoroutine(Sprinting());
//			sptimer = Time.deltaTime; //

//			while(sprintSlider.value > 0){
//				movementSpeed = 10.0f; // was 5.0f
//				jumpSpeed = 14.0f; // was 7.0f
//				Update ();
//				sprintSlider.value -= 1;

////				sptimer += 1;
//			}

//			movementSpeed = 10.0f; // was 5.0f
//			jumpSpeed = 14.0f; // was 7.0f

//			if (timer <= 10.0f) {
//				sprintSlider.value = 10.0f - timer;
//			} //
//			else {
//				sprintSlider.value = 0;
//				movementSpeed = 5.0f;
//				jumpSpeed = 7.0f;
//
//			}

		}
		if (col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy(Clone)") {
//			playerHealth.TakeDamage (1);
			playerHealth.currentHealth -= 1;
			// should make a timer so that the character won't get damaged that quick
			// BUT I CANNOT DO ITTTTTT *CRIES* FOR NOW
			damaged = true;
			if (playerHealth.currentHealth <= 0) {
				Application.LoadLevel ("GameOver");
			}
//			Destroy (this);
		}

		if (col.gameObject.name == "PowerupHealth" || col.gameObject.name == "PowerupHealth(Clone)") {
			playerHealth.currentHealth += 4;
			Destroy (col.gameObject);
		}
	}

	IEnumerator Sprinting() {
		movementSpeed = 10.0f; // was 5.0f
		jumpSpeed = 14.0f; // was 7.0f
		int sprinttime = 10;
		while (sprintSlider.value > 0) {
			yield return new WaitForSeconds(1f);
			sprintSlider.value -= 1;
		}
		movementSpeed = 5.0f;
		jumpSpeed = 7.0f;
	}
}
