using UnityEngine;
using System.Collections;

public class AuldArena_FloorWaypoints : MonoBehaviour {

	// This var is for the number of waypoints (units/slots for movement) intended for the stage.
	public int stageTotalWaypoints = 20;

	private float waypointUnitSize = 0.4f;  // This will be the distance between waypoints.
	private Vector3 waypointsOrigin; // This will determine the far left waypoint, it is set in the Start() function.

	public GameObject waypointPrefab;
	private GameObject currentWaypoint;



	// Use this for initialization
	void Start () 
	{
		if (!waypointPrefab)
		{
			Debug.LogError ("The variable prefab for waypoints has not been set in the arenafloor script.");
		}

		waypointsOrigin = new Vector3 (waypointUnitSize * (-stageTotalWaypoints/2.0f), 0.0f, -0.1f); // This will be exactly half the level's intended size to the left of 0, 0, 0,
		// and will be just slightly in front of the player etc.
		SpawnWaypoints ();


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void SpawnWaypoints()
	{
		waypointsOrigin = new Vector3 (waypointUnitSize * (-stageTotalWaypoints/2.0f), 0.0f, -0.1f); 
		// This will be exactly half the level's intended size to the left of 0, 0, 0,
		// and will be just slightly in front of the player etc.

		// Spawn the appropriate number of waypoints for the stage.
		for (int waypoints = 0; waypoints < stageTotalWaypoints; waypoints ++)
		{

			currentWaypoint = GameObject.Instantiate (waypointPrefab, waypointsOrigin + new Vector3 (waypointUnitSize * waypoints, 0.0f, 0.0f), Quaternion.identity) as GameObject;
			// xxx Attempted to access the WaypointSelection.cs of each currentWaypoint to set the IDs as they spawned - but kept getting reference to instance of object errors.
			// xxx Need to set those IDs somehow.

			Debug.Log ("Waypoint ID number " + " has been assigned.");
		}
	}
}
