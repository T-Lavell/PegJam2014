using UnityEngine;
using System.Collections;

public class AuldArena_CombatController : MonoBehaviour {

	/// <summary>
	/// Remember to use summaries in your coding! XD
	/// </summary>
	public GameObject defaultWarriorPrefab;

	// These will be used to track each created character.
	private GameObject warrior1;
	private Vector3 startLocation = new Vector3 (-5.5f, 0.0f, 0.0f);// Each warrior will spawn one unit to the right of the last.
	private GameObject warrior2;
	private GameObject warrior3;
	private GameObject warrior4;
	private GameObject warrior5;
	private GameObject warrior6;
	private bool allWarriorsSpawned = false;

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

	public int numWarriorsToStart = 3;
	private int warriorsAlivePlayer1;
	private int warriorsAlivePlayer2;



	// Use this for initialization
	void Start () 
	{
		if (!defaultWarriorPrefab)
		{
			Debug.LogError ("The variable 'defaultWarriorPrefab' of the AuldArena_CombatController has not been set.");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.15f, Screen.height * 0.15f), "Create Warrior"))
		{
			SpawnWarrior();
		}
	}

	void SpawnWarrior()
	{
		if (allWarriorsSpawned)
		{
			Debug.LogError ("We shouldn't be trying to spawn more warriors... SpawnWarrior() has been called too many times.");
			return;
		}

		if (!warrior1)
		{
			warrior1 = Instantiate (defaultWarriorPrefab, startLocation, Quaternion.identity) as GameObject;
			startLocation.x += 2.0f;
		}
		else if (!warrior2)
		{
			warrior2 = Instantiate (defaultWarriorPrefab, startLocation, Quaternion.identity) as GameObject;
			startLocation.x += 2.0f;
		}
		else if (!warrior3)
		{
			warrior3 = Instantiate (defaultWarriorPrefab, startLocation, Quaternion.identity) as GameObject;
			startLocation.x += 2.0f;
		}else if (!warrior4)
		{
			warrior4 = Instantiate (defaultWarriorPrefab, startLocation, Quaternion.identity) as GameObject;
			startLocation.x += 2.0f;
		}else if (!warrior5)
		{
			warrior5 = Instantiate (defaultWarriorPrefab, startLocation, Quaternion.identity) as GameObject;
			startLocation.x += 2.0f;
		}else if (!warrior6)
		{
			warrior6 = Instantiate (defaultWarriorPrefab, startLocation, Quaternion.identity) as GameObject;
			allWarriorsSpawned = true;
		}
		// warrior1 = Instantiate (defaultWarriorPrefab, new Vector3 (-1.0f, 0.0f, 0.0f), Quaternion.identity) as GameObject;
	}
}
