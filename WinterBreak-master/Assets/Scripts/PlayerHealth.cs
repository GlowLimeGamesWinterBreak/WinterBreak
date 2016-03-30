using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

// FROM HERE
	public int startingHealth = 12;
	public int currentHealth = 12;

	public Texture[] images = new Texture[4];

	bool isDead;
	bool damaged;

//	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;
	}

//	// Update is called once per frame
	void Update () {

//		Pizza.sprite = PizzaSprites [currentHealth];
		// display GUI
//		if (damaged) {
//			currentHealth -= 1;
//			currentHealth -= 0;
//		}
//		damaged = false; // resets the bool
		if(isDead){
			Screen.lockCursor = false;
//
		}
//	
	}

	void OnGUI(){
		int pizzaAmount = currentHealth;
		int pizzaDiv = pizzaAmount / 4;
		int pizzaMod = (pizzaAmount % 4);

		int x = -50;
		int y = 240;
		for (int i = 0; i < pizzaDiv; i++) {
			GUI.DrawTexture (new Rect (x, y, 120, 120), images [4], ScaleMode.ScaleToFit);
			x += 40;
		}
		if (pizzaMod > 0) {
			GUI.DrawTexture (new Rect (x, y, 120, 120), images [pizzaMod], ScaleMode.ScaleToFit);
		}
	}

	public void TakeDamage(int amount){
//		// Set the damaged flag so the screen will flash. (won't flash for now)
		damaged = true;
//
//		// Reduce the current health by the damage amount.
		currentHealth -= 1;
//
//		// Set the health bar's value to the current health.
//		healthSlider.value = currentHealth;
//
////		// Play the hurt sound effect.
////		playerAudio.Play ();
//
//		// If the player has lost all it's health and the death flag hasn't been set yet...
//		if(currentHealth <= 0 && !isDead)
		if(currentHealth <= 0)
		{
//			// ... it should die.
//
//
			Death ();
		}
	}
//
	void Death ()
	{
//		// Set the death flag so this function won't be called again.
		isDead = true;
		Application.LoadLevel ("GameOver");
//
////		// Turn off any remaining shooting effects.
////		playerShooting.DisableEffects ();
//
////		// Tell the animator that the player is dead.
////		anim.SetTrigger ("Die");
//
////		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
////		playerAudio.clip = deathClip;
////		playerAudio.Play ();
//
//		// Turn off the movement and shooting scripts.
////		playerMovement.enabled = false;
////		playerShooting.enabled = false;
	}       // TO HERE IS COMMENTED

}
