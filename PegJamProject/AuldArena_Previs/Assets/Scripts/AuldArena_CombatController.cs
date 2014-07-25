using UnityEngine;
using System.Collections;

public class AuldArena_CombatController : MonoBehaviour {




	#region WARRIOR VARIABLES
	/// <summary>
	/// Remember to use summaries in your coding! XD
	/// </summary>

	public GameObject defaultWarriorPrefab;
	// Each warrior is composed of the following attributes.
	public struct Warrior
	{
		/// <summary>
		/// Does this warrior belong to player 1?
		/// </summary>
		bool player1; // Controlled by player 1.
		GameObject warriorPrefab;
		int timesHit;
		/// <summary>
		/// State number of the warrior's action pose.
		/// </summary>
		int warriorPose;
	}
	public GameObject[] warriorsArray;

	public int numWarriorsToStart = 3; // This reflects the number of fighters per side.  The number is doubled before warriors are spawned.
	private int warriorsAlivePlayer1;
	private int warriorsAlivePlayer2;
	#endregion


	#region WAYPOINT VARIABLES
	// This var is for the number of waypoints (units/slots for movement) intended for the stage.
	public int stageTotalWaypoints = 20;
	
	private float waypointUnitSize = 0.4f;  // This will be the distance between waypoints.
	private Vector3 waypointsOrigin; // This will determine the far left waypoint, it is set in the Start() function.
	
	public GameObject waypointPrefab;  // Used to store the default waypoint prefab.
	private GameObject currentWaypoint;  // Used to store whichever waypoint we are dealing with at the time.

	public GameObject[] waypointsArray;

	#endregion


	// Use this for initialization
	void Start () 
	{
		/// Warriors initialization
		/// 
		/// WARRIORS SECTION OF START
		
		warriorsArray = new GameObject[numWarriorsToStart * 2];
		/// This ensures I haven't forgotten to set the default warrior prefab.
		if (!defaultWarriorPrefab)
		{
			Debug.LogError ("The variable 'defaultWarriorPrefab' of the AuldArena_CombatController has not been set.");
		}

		/// This portion is for creating the level's waypoints.
		/// 
		/// WAYPOINT SECTION of START

		if (!waypointPrefab)
		{
			Debug.LogError ("The variable prefab for waypoints has not been set in the arenafloor script.");
		}
		
		waypointsOrigin = new Vector3 (waypointUnitSize * (-stageTotalWaypoints/2.0f), 0.0f, -0.1f); // This will be exactly half the level's intended size to the left of 0, 0, 0,
		// and will be just slightly in front of the player etc.

		// Before I spawn the waypoints, I need to set the size of the waypointArray
		waypointsArray = new GameObject[stageTotalWaypoints];
		SpawnWaypoints ();

		/// Names initialization
		/// 
		/// NAMES SECTION of START
		randomNamesArray = new string[50];
		AssignNamesToArray();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}




	void SpawnWarriors()
	{
		for(int i = 0; i < warriorsArray.Length; i++)
		{
			bool leftSideWarriors = true;
			if (i < numWarriorsToStart)
			{
				leftSideWarriors = true;
			}
			else
			{
				leftSideWarriors = false;
			}
			Vector3 spawnPoint = Vector3.zero;
			if (leftSideWarriors)
			{
				spawnPoint = new Vector3 (waypointsArray[i + numWarriorsToStart].transform.position.x, 0.0f, 0.0f);
			}
			else
			{
				spawnPoint = new Vector3 (waypointsArray[waypointsArray.Length - i].transform.position.x, 0.0f, 0.0f);
			}
			warriorsArray[i] = Instantiate(defaultWarriorPrefab, spawnPoint, Quaternion.identity) as GameObject;
			warriorsArray[i].SendMessage ("SetFacingRight", leftSideWarriors, SendMessageOptions.RequireReceiver);
			warriorsArray[i].SendMessage ("SetWarriorID", i, SendMessageOptions.RequireReceiver);
			warriorsArray[i].SendMessage ("SetName", randomNamesArray[Random.Range (0, 49)], SendMessageOptions.RequireReceiver);
		}
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
			currentWaypoint.SendMessage ("SetWaypointID", waypoints + 1, SendMessageOptions.RequireReceiver);
			waypointsArray[waypoints] = currentWaypoint;
			currentWaypoint.name = "Waypoint" + (waypoints + 1).ToString ();
			// Debug.Log ("Waypoint ID number " + (waypoints + 1).ToString () + " has been assigned.");
		}

	}

	#region RANDOMNAMES

	string[] randomNamesArray;
	
	
	//Random rnd = new Random();
	//int month = rnd.Next(1, 13); // creates a number between 1 and 12



	void AssignNamesToArray()
	{
		randomNamesArray[0] = "Abraham";
		randomNamesArray[1] = "Bartholemew";
		randomNamesArray[2] = "Christopher";
		randomNamesArray[3] = "Williford";
		randomNamesArray[4] = "Abraham";
		randomNamesArray[5] = "Abraham";
		randomNamesArray[6] = "Mondoosh";
		randomNamesArray[7] = "Abraham";
		randomNamesArray[8] = "Abraham";
		randomNamesArray[9] = "Philosook";
		randomNamesArray[10] = "Aasdf";
		randomNamesArray[11] = "Abraham";
		randomNamesArray[12] = "Crapador";
		randomNamesArray[13] = "Abraham";
		randomNamesArray[14] = "Abfdfsham";
		randomNamesArray[15] = "Abraham";
		randomNamesArray[16] = "Abraham";
		randomNamesArray[17] = "Jerenly";
		randomNamesArray[18] = "Abfdsfdfm";
		randomNamesArray[19] = "Abraham";
		randomNamesArray[20] = "Abraham";
		randomNamesArray[21] = "Abfasdfm";
		randomNamesArray[22] = "Abraham";
		randomNamesArray[23] = "asdfam";
		randomNamesArray[24] = "Abraham";
		randomNamesArray[25] = "Linseed";
		randomNamesArray[26] = "dfasdfasdfham";
		randomNamesArray[27] = "Abraham";
		randomNamesArray[28] = "sdfasdfsdfham";
		randomNamesArray[29] = "Abraham";
		randomNamesArray[30] = "Abraham";
		randomNamesArray[31] = "Abraham";
		randomNamesArray[32] = "Poudur";
		randomNamesArray[33] = "Abraham";
		randomNamesArray[34] = "Bosconovich";
		randomNamesArray[35] = "Abraham";
		randomNamesArray[36] = "Will";
		randomNamesArray[37] = "ghfham";
		randomNamesArray[38] = "Spartacular";
		randomNamesArray[39] = "Hart";
		randomNamesArray[40] = "Jumpy";
		randomNamesArray[41] = "Koala";
		randomNamesArray[42] = "Nevermore";
		randomNamesArray[43] = "Bert";
		randomNamesArray[44] = "Swindle";
		randomNamesArray[45] = "Wendel";
		randomNamesArray[46] = "Jera";
		randomNamesArray[47] = "Nobbie";
		randomNamesArray[48] = "Yargol";
		randomNamesArray[49] = "ZebraDood";
		
	}
	#endregion
}
