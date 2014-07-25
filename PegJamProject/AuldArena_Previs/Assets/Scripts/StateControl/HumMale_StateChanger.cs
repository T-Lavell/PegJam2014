using UnityEngine;
using System.Collections;

public class HumMale_StateChanger : MonoBehaviour {

	/// <summary>
	/// 	This represents which of the [noOfStates] states the gameObject should be in.
	/// </summary>
	public int state = 1;
	private int stateWas = 1;
	public int noOfStates = 21;

	public bool facingRight = true;

	private Animator _animator;

	// Use this for initialization
	void Start () 
	{
		_animator = gameObject.GetComponent<Animator>();
	}

	// Set "facing" from an external script with this function.
	[RPC]
	void SetFacingRight(bool _facingRight)
	{
		facingRight = _facingRight;
	}
	// Set the state from an external script with this function.
	[RPC]
	void SetState(int _state)
	{
		state = _state;
	}
	// Set the transform location with this function.
	[RPC]
	void SetLocation(Vector3 _location)
	{
		transform.position = _location;
	}

	// Update is called once per frame
	void Update () 
	{
		UpdateFacing();
	
		stateWas = state;

		if (Input.GetButtonDown ("Fire1"))
		{
			state++;
		}
		if (Input.GetButtonDown ("Jump"))
		{
			state--;
		}



		// This bit serves to loop between the earlier and later states.
		if (state > noOfStates)
		{
			state = 1;
		}
		else if (state < 1)
		{
			state = noOfStates;
		}

		// Print the state number only if it has been changed this frame.
		if (state != stateWas)
		{
			// print ("State changed to number " + state.ToString ());
		}

		_animator.SetInteger("State", state);
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
