using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixFPSPos : MonoBehaviour {

	//NOTE: This script was originally used to fix the fpc from falling through terrain, but now is used to draw the crosshair on the screen (script name left unchanged)

	//attributes
	public Texture2D crosshair;

	// Use this for initialization
	void Start () {
		//translate.position.y = terrain.GetComponent<Terrain> ().SampleHeight (new Vector3 (transform.position.x, 0, transform.position.z)) + 0.5f;
		//transform.Translate = new Vector3 (transform.position.x, terrain.GetComponent<Terrain> ().SampleHeight (new Vector3 (transform.position.x, 0, transform.position.z)) + 0.5f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.DrawTexture( new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) /2, crosshair.width, crosshair.height), crosshair); //draws crosshair on the screen
	}
}
