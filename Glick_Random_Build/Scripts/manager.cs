using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	//attributes
	public GameObject terrain;
	public GameObject target;
	public int targetNum;
	public GameObject hordeType;
	public int hordeNum;
	public float minHeight;
	public float maxHeight;

	public string currCam;

	// Use this for initialization
	void Start () {
		TargetGen ();
		HordeGen ();
		currCam = "Camera 1\nFirst Person Controller";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//GUI box for controls and current camera
	void OnGUI () {
		GUI.Box (new Rect (new Vector2 (10, 70), new Vector2 (200, 85)), "Controls:\n'C' changes the camera\n'Left Click' shoots bullets in FP\n" + currCam);
	}

	/// <summary>
	/// Method for generating the trees placed around the terrain. It finds the dimentions of the terrain, then randomly choosing a coordinate inside the dimentions to place a tree object
	/// </summary>
	void TargetGen() {
		Vector3 dimentions;
		dimentions = terrain.GetComponent<Terrain> ().terrainData.size;
		for (int i = 0; i < targetNum; i++) {
			float rX = Random.Range (0, dimentions.x + 1);
			float rZ = Random.Range (0, dimentions.z + 1);
			GameObject newTarget = Instantiate (target, new Vector3 (rX, terrain.GetComponent<Terrain>().SampleHeight(new Vector3(rX, 0, rZ)) /*+ 2.5f*/, rZ), transform.rotation);
		}
	}

	/// <summary>
	/// Method for generating the line of leaders. Gaussian values are randomly selected to determine the height and size of each leader
	/// </summary>
	/// <param name="genLoc">Vector containing the placement coordinates of the first leader</param>
	void LeaderGen (Vector3 genLoc) {
		for (int i = 0; i < 10; i++) {
			GameObject newTarget = Instantiate (hordeType, new Vector3 (Random.Range(13f, 16f), terrain.GetComponent<Terrain>().SampleHeight(new Vector3(15, 0, genLoc.z + i + 1)) + 0.75f/*+ 2.5f*/, genLoc.z + i + 1), hordeType.transform.rotation);
			float scale = Gaussian (minHeight, maxHeight);
			newTarget.transform.localScale = new Vector3 (scale, Gaussian (minHeight, maxHeight), scale);
		}
	}

	/// <summary>
	/// Method for generating the non-uniform zombie horde
	/// </summary>
	void HordeGen () {
		Vector3 dimentions;
		dimentions = terrain.GetComponent<Terrain> ().terrainData.size;
		dimentions.x = dimentions.x / 2;
		dimentions.z = dimentions.z / 2;
		Vector3 genLoc = new Vector3 (terrain.GetComponent<Terrain> ().terrainData.size.x / 4, 0, terrain.GetComponent<Terrain> ().terrainData.size.z / 4);
		for (int i = 0; i < hordeNum; i++) {
			float rX = NonUniform (genLoc.x, terrain.GetComponent<Terrain> ().terrainData.size.x * 0.5f);
			//float rZ = NonUniform (genLoc.z, dimentions.z);
			float rZ = Random.Range(genLoc.z, genLoc.z + 50);
			GameObject newTarget = Instantiate (hordeType, new Vector3 (rX, terrain.GetComponent<Terrain>().SampleHeight(new Vector3(rX, 0, rZ)) + 0.75f/*+ 2.5f*/, rZ), hordeType.transform.rotation);
			float scale = Gaussian (minHeight, maxHeight);
			newTarget.transform.localScale = new Vector3 (scale, Gaussian (minHeight, maxHeight), scale);
		}
		LeaderGen (genLoc);

	}

	/// <summary>
	/// Method for generating random Gaussian values given the minimum and maximum values desired
	/// </summary>
	/// <param name="min">Minimum Value</param>
	/// <param name="max">Maximum Value</param>
	float Gaussian (float min, float max) {
		float mean = (min + max) / 2;
		float stdDev = (max - mean) / 3;
		return Random.Range (mean, stdDev);
	}

	/// <summary>
	/// Method for generating nonuniform random numbers (weighted towards the minimum value)
	/// </summary>
	/// <returns>A nonuniform random number between the min and max</returns>
	/// <param name="min">Minimum Value</param>
	/// <param name="max">Maximum Value</param>
	float NonUniform (float min, float max) {
		int ticket = Random.Range(1, 1001);
		if (ticket < 500) {
			return Random.Range (min, max / 4);
		}
		else if (ticket >= 500 && ticket < 750) {
			return Random.Range (max / 4, max / 2);
		}
		else if (ticket >= 750 && ticket < 875) {
			return Random.Range (max / 2, max * (3.0f/4.0f));
		}
		else if (ticket >= 875 && ticket < 938) {
			return Random.Range ( max * (3.0f/4.0f),  max * (9.0f/10.0f));
		}
		else if (ticket >= 938 && ticket < 970) {
			return Random.Range (max * (9.0f/10.0f), max * 0.95f);
		}
		else if (ticket >= 970) {
			return Random.Range (max * 0.95f, max);
		}
		return -1;
	}
}
