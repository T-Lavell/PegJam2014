using UnityEngine;
using System.Collections;

public class WaypointSelection : MonoBehaviour {
	/// <summary>
	/// The intent of this script is to allow procedural assignment of IDs (as integers) to each waypoint in the stage as they are instantiated.
	/// Once instantiated, if GUI (from the CombatController) is allowing the player to select a waypoint / target, these prefabs will change their
	/// appearance (become larger) to show that they are the currently selected object.
	/// </summary>

	[HideInInspector]
	public bool isSelected = false;

	[HideInInspector]
	public int waypointID = -1;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// The arenaFloorWaypoints script will assign an ID to each waypoint as it instantiates them.
	public void SetWaypointID(int newID)
	{
		waypointID = newID;
	}
}
