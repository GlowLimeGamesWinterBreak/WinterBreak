using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public GameObject playerCamera;
	public float upDownRange = 60.0f;
	float verticalRotation = 0;
	public float verticalVelocity = 0;
	public float jumpSpeed = 7.0f;
	public bool jump = false;
	public AudioSource walkSound;
	public float sptimer = 0.0f;
	public Slider sprintSlider;
	public bool damaged = false;
	public bool gameOver = false;
	public bool gameStart = true;
	public bool sprint = false;
	public float endSprint = 0f;
	public float invulnTime = 0f;

	PlayerHealth playerHealth;

	CharacterController characterController;
	GameObject fader;
	GameObject itemScript;

	// Use this for initialization
	void Start () {
		gameOver = false;
		fader = GameObject.FindGameObjectWithTag ("ScreenFader");
		itemScript = GameObject.FindGameObjectWithTag ("Terrain");

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
		if (gameOver == false) {
			if (gameStart) {
				fader.GetComponent<FadeScript> ().toClear ();
			}

			if (sprint) {
				if (Time.time > endSprint) {
					sprint = false;
					movementSpeed /= 2;
				}
			}
			Screen.lockCursor = true;

			//rotation
			float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate (0, rotLeftRight, 0);

			verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
			verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
			playerCamera.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

			//movement

			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;

			verticalVelocity += Physics.gravity.y * Time.deltaTime;

			if (characterController.isGrounded && Input.GetButton ("Jump")) {
				verticalVelocity = jumpSpeed;
			}

			Vector3 speed = new Vector3 (sideSpeed * movementSpeed, verticalVelocity, forwardSpeed * movementSpeed); //x,y,z forwardspeed is forward and back

			speed = transform.rotation * speed;
			if (forwardSpeed < .01 && sideSpeed < .01)
				walkSound.Stop ();
			else if (walkSound.isPlaying != true) {
				walkSound.Play ();
			}


			//cc.SimpleMove(speed); //takes care of gravity, ignores y. jump/fly/explosion cannot use simple

			characterController.Move (speed * Time.deltaTime); //does not expect speed, it expects how many units of distance traveling this frame
		} else {
			//game over tilt up fade to black
			//death sound?
			if (verticalRotation > -90)
				verticalRotation += -40.0f * Time.deltaTime;
			else
				verticalRotation = -90;
			playerCamera.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
			fader.GetComponent<FadeScript> ().toBlack ();
			GameObject.FindGameObjectWithTag ("Score").GetComponent<ScoreManager> ().GameOver ();
			if (Input.GetKeyDown (KeyCode.Space))
				Application.LoadLevel ("NoahBetaBuildScene");
		}
	}

	/*
    void walkSway () {
        if(swayTarget == 1){    
                //swayTarget is which of the two points I'm going towards
             if (Vector3.Distance(transform.localPosition, walkSway1) >= .01){
                curVect= walkSway1 - transform.localPosition;
                         //if the gun isn't at sway point one, transform towards it (the speed at which it transforms depends on the speed of the player) .
                transform.Translate(curVect*Time.deltaTime*swayRate*player.GetComponent("FPSWalker").speed,Space.Self);
            } else {
                        //if it has reached sway point 1, start going towards sway point 2
                swayTarget = 2;
            }
        } else if(swayTarget == 2) {
            if (Vector3.Distance(transform.localPosition, walkSway2) >= .01){
                curVect= walkSway2 - transform.localPosition;
                                // curVect is just the temporary vector for the translation
                transform.Translate(curVect*Time.deltaTime*swayRate*player.GetComponent("FPSWalker").speed,Space.Self);
            } else {
                swayTarget = 1;
            }
        }
    }*/

	void OnTriggerEnter (Collider col){
		print (col.gameObject.name);
		if (col.gameObject.name == "Powerup(Clone)") {
			int powerupVal = col.gameObject.GetComponent<ItemManager> ().getVal ();
			if (powerupVal == 0 && playerHealth.currentHealth < 12) {
				if (playerHealth.currentHealth <= 8)
					playerHealth.currentHealth += 4;
				else
					playerHealth.currentHealth = 12;
			} else if (powerupVal == 1) {
				if (sprint == true) {
					endSprint = Time.time + 10f;
				} else {
					sprint = true;
					endSprint = Time.time + 10f;
					movementSpeed *= 2;
				}

			}
			Vector3 pos = col.gameObject.transform.position;
			itemScript.GetComponent<SpawnItems> ().powerupGone (pos);
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "PowerupSprint" || col.gameObject.name == "PowerupSprint(Clone)") {
			jump = true;
			Destroy (col.gameObject);
			sprintSlider.value = 10;
			StartCoroutine(Sprinting());

		}
		if (col.gameObject.name == "Enemy" || col.gameObject.tag == "Enemy") {
//			playerHealth.TakeDamage (1);
			if (Time.time > invulnTime) {
				invulnTime = Time.time + .5f;
				if (gameOver == false)
					playerHealth.currentHealth -= 1;
				// should make a timer so that the character won't get damaged that quick
				// BUT I CANNOT DO ITTTTTT *CRIES* FOR NOW
				damaged = true;
				if (playerHealth.currentHealth <= 0) {
					gameOver = true;
				}
			} 
//			Destroy (this);
		}

		if (col.gameObject.name == "PowerupHealth" || col.gameObject.name == "PowerupHealth(Clone)") {
			if(gameOver == false)
				playerHealth.currentHealth -= 1;
			// should make a timer so that the character won't get damaged that quick
			// BUT I CANNOT DO ITTTTTT *CRIES* FOR NOW
			damaged = true;
			if (playerHealth.currentHealth <= 0) {
				gameOver = true;
			}
//			Destroy (this);
		}

		if (col.gameObject.name == "PowerupHealth" || col.gameObject.tag == "PowerupHealth") {
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
