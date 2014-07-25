using UnityEngine;
using System.Collections;

public class HumMale_StateChanger : MonoBehaviour {

	/// The ID of each 'warrior' will be used to ensure the correct messages are being send & received over the network.
	private int warriorID = -1;

	/// <summary>
	/// 	This represents which of the [noOfStates] states the gameObject should be in.
	/// </summary>
	public int state = 1;
	// private int stateWas = 1;
	public int noOfStates = 21;

	public bool facingRight = true;

	// [HideInInspector]
	public int timesHit;
	// [HideInInspector]
	public int timesCut;
	// [HideInInspector]
	public bool isAlive = true;
	public bool isToppled = false;
	public int mobility = 6;

	private Animator _animator;



	// Use this for initialization
	void Start () 
	{
		_animator = gameObject.GetComponent<Animator>();
	}

	// When each warrior is spawned, their IDs will be set via SendMessage().
	public void SetWarriorID(int newID)
	{
		warriorID = newID;
	}
	public void SetName(string newName)
	{
		gameObject.name = newName;
	}

	// Set "facing" from an external script with this function.
	[RPC]
	public void SetFacingRight(bool _facingRight)
	{
		facingRight = _facingRight;
		UpdateFacing ();
	}
	// Set the state from an external script with this function.
	[RPC]
	public void SetState(int _state)
	{
		state = _state;
		_animator.SetInteger("State", state);
	}
	// Set the transform location with this function.
	[RPC]
	public void SetLocation(Vector3 _location)
	{
		transform.position = _location;
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void UpdateFacing()
	{
		if (facingRight)
		{
			transform.localScale = Vector3.one;
		}
		else
		{
			transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);
		}
	}
	

}
