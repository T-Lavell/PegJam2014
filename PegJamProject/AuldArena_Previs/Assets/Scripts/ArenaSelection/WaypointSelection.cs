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

	private TextMesh _textMesh;
	private float unselectedLetterSize;
	private float selectedLetterSize;

	// Use this for initialization
	void Start () 
	{
		_textMesh = gameObject.GetComponent<TextMesh>();
		unselectedLetterSize = _textMesh.characterSize;
		selectedLetterSize = unselectedLetterSize * 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void Selected()
	{
		_textMesh.characterSize = selectedLetterSize;
	}
	void NotSelected()
	{
		_textMesh.characterSize = unselectedLetterSize;
	}

	// The arenaFloorWaypoints script will assign an ID to each waypoint as it instantiates them.
	public void SetWaypointID(int newID)
	{
		waypointID = newID;
		// Debug.Log ("Waypoint ID number " + newID.ToString () + " has been instantiated.");
	}
}
