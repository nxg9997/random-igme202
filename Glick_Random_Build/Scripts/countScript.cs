using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countScript : MonoBehaviour {

	//attributes
	public int zCount = 0;
	public int tCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		GUI.Box (new Rect (new Vector2 (10, 10), new Vector2 (200, 50)), "Score\nZombies Killed: " + zCount + "\nTrees Destroyed: " + tCount); //displays current score in the top left
	}
}
