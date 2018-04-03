using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollisions : MonoBehaviour {

	//attributes
	public countScript counter;
	public GameObject explosion;
	public AudioClip explosionSound;
	public GameObject blood;

	// Use this for initialization
	void Start () {
		counter = GameObject.Find ("counter").GetComponent<countScript> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name.Contains ("Slasher")) { //checks if the bullet collides with a zombie
			Destroy (collision.gameObject);
			counter.zCount++; //increases zombie kill count
			GameObject bloodSpurt = Instantiate (blood, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation); //creates instance of blood particle effect
			Debug.Log ("HIT SLASHER!");
		}
		else if (collision.gameObject.name.Contains ("Broadleaf")) { //checks if the bullet hits a tree
			Destroy (collision.gameObject);
			counter.tCount++; //increases tree destroy count
			GameObject explo = Instantiate (explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation); //creates instance of the explosion particle effect
			AudioSource.PlayClipAtPoint (explosionSound, transform.position); //plays explosion sound effect
			Debug.Log ("HIT TREE!");
		}
		Destroy (gameObject);

	}
}
