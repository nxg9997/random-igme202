using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TerrainGeneration class
// Placed on a terrain game object
// Generates a Perlin noise-based heightmap

public class TerrainGeneration : MonoBehaviour 
{

	private TerrainData myTerrainData;
	public Vector3 worldSize;
	public int resolution = 128;
	float[,] heightArray;
	public float timestep;


	void Start () 
	{
		myTerrainData = gameObject.GetComponent<TerrainCollider> ().terrainData;
		worldSize = new Vector3 (200, 50, 200);
		myTerrainData.size = worldSize;
		//myTerrainData.heightmapResolution = resolution;
		heightArray = new float[resolution, resolution];

		// Fill the height array with values!
		// Uncomment the Ramp and Perlin methods to test them out!
		//Flat(1.0f);
		//Ramp();
		Perlin();

		// Assign values from heightArray into the terrain object's heightmap
		myTerrainData.SetHeights (0, 0, heightArray);
	}
	

	void Update () 
	{
		
	}

	/// <summary>
	/// Flat()
	/// Assigns heightArray identical values
	/// </summary>
	void Flat(float value)
	{
		// Fill heightArray with 1's
		for(int i = 0; i < resolution; i++)
		{
			for(int j = 0; j < resolution; j++)
			{
				heightArray [i, j] = value;
			}
		}
	}
		

	/// <summary>
	/// Ramp()
	/// Assigns heightsArray values that form a linear ramp
	/// </summary>
	void Ramp()
	{
		// Fill heightArray with linear values
		float interpolation = 1.0f/128.0f;
		Debug.Log (interpolation);
		for (int i = 0; i < resolution; i++)
		{
			float height = i * interpolation;
			for (int j = 0; j < resolution; j++) 
			{
				heightArray [i, j] = height;
			}
		}
			
	}

	/// <summary>
	/// Perlin()
	/// Assigns heightsArray values using Perlin noise
	/// </summary>
	void Perlin()
	{
		// Fill heightArray with Perlin-based values
		for (int i = 0; i < resolution; i++) 
		{
			//float currTime = timestep * i;
			for (int j = 0; j < resolution; j++) 
			{
				heightArray [i, j] = Mathf.PerlinNoise (i * timestep, j * timestep);
			}
		}

	}

	/*void OnGUI()
	{
		GUI.Box (new Rect (10, 10, 150, 50), "Press 'c' to switch scenes.");
	}*/
}
