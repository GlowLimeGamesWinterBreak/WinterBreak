using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public Sprite[] PizzaSprites;
	public Image Pizza;

// FROM HERE
	public int startingHealth = 12;
	public int currentHealth;
	public int maxHealth;
//	public int healthPerPizza;

//	public int amount; //
//	public GUITexture pizzaGUI;
	public Texture[] pizzas;
	public Texture[] images = new Texture[13];

	bool isDead;
	bool damaged;

//	private ArrayList pizzas = new ArrayList ();
//	public int maxPizzasPerRow;
//	private float spacingX;
//	private float spacingY;
//
//	// Use this for initialization
	void Awake () {
		currentHealth = startingHealth;

//		spacingX = pizzaGUI.pixelInset.width;
//		spacingY = -pizzaGUI.pixelInset.height;
//		AddPizzas (startingHealth / healthPerPizza);


//		GameObject temp = GameObject.FindGameObjectWithTag ("HealthSlider");
//		if (temp != null) {
//			pizzas = new Texture[currentHealth+1];

//			healthSlider = temp.GetComponent<Slider> ();

//		}
//	
	}
//	
//	public void AddPizzas(int n){
//		for (int i = 0; i < n; i++) {
//			Transform newPizza = ((GameObject)Instantiate (pizzaGUI.gameObject, transform.position, Quaternion.identity)).transform;
//			newPizza.parent = this.transform.parent;
//
//			int y = Mathf.FloorToInt (pizzas.Count / maxPizzasPerRow);
//			int x = pizzas.Count - y * maxPizzasPerRow;
//
//			newPizza.GetComponent<GUITexture> ().pixelInset = new Rect (x * spacingX, y * spacingY, 100, 100);
//			pizzas.Add (newPizza);
//		}
//		maxHealth += n * healthPerPizza;
//		currentHealth = maxHealth;
//		Update ();
//
//	}
//
//	public void ModifyHealth(int amount){
//		currentHealth += amount;
//		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
//		Update ();
//	}

//	public void UpdatePizzas(){
//		bool restAreEmpty = false;
//		int iii = 1;
//
//		foreach (Transform pizza in pizzas) {
//			if (restAreEmpty) {
//				pizza.guiTexture = images [0];
//			} 
//			else {
//				int currentPizzaHealth = (int)(healthPerPizza - (healthPerPizza * i - currentHealth));
//				int healthPerImage = healthPerPizza / images.Length;
//				int imageIndex;
//
//				pizza.guiTexture = images[imageIndex];
//				restAreEmpty = true;
//			}
//		}
//	}

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
		GUI.DrawTexture (new Rect (20, 100, 150, 400), images[currentHealth], ScaleMode.ScaleToFit);
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
