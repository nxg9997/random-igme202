using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour {

	public Camera[] cameras;

	private int currentCameraIndex;
	public manager man;

	// Use this for initialization
	void Start () {
		
		man = GameObject.Find ("scenemanager").GetComponent<manager> ();
		currentCameraIndex = 0;

		for (int i = 0; i < cameras.Length; i++) {
			cameras [i].gameObject.SetActive (false);
		}

		if (cameras.Length > 0) {
			cameras [0].gameObject.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {

			currentCameraIndex++;



			if (currentCameraIndex < cameras.Length) {
				cameras [currentCameraIndex - 1].gameObject.SetActive (false);
				cameras [currentCameraIndex].gameObject.SetActive (true);
			
			} 
			else {
				cameras [currentCameraIndex - 1].gameObject.SetActive (false);
				currentCameraIndex = 0;
				cameras [currentCameraIndex].gameObject.SetActive (true);
			}

			//Changes the current camera information on the GUI depending on the current active camera
			if (cameras [currentCameraIndex].gameObject.name == "FirstPersonCharacter") {
				man.currCam = "Camera 1\nFirst Person Controller";
			}
			if (cameras [currentCameraIndex].gameObject.name == "fullCam") {
				man.currCam = "Camera 2\nFull Camera";
			}
			if (cameras [currentCameraIndex].gameObject.name == "leaderCam") {
				man.currCam = "Camera 3\nLeader Cam";
			}
			if (cameras [currentCameraIndex].gameObject.name == "hordeCam") {
				man.currCam = "Camera 4\nHorde Cam";
			}
			if (cameras [currentCameraIndex].gameObject.name == "frontCam") {
				man.currCam = "Camera 5\nFront Cam";
			}
			if (cameras [currentCameraIndex].gameObject.name == "closeCam") {
				man.currCam = "Camera 6\nClose Cam";
			}

		}
	}
}
