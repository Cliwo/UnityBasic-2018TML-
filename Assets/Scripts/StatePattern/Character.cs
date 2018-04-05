using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	State currentState;
	void Start () {
		currentState = new Idle(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		currentState.StateUpdate();
		State temp = currentState.HandleInput();
		if(temp != null)
		{
			if( currentState.onEndState !=null)
				currentState.onEndState();

			currentState = temp;

			if( currentState.onStartState !=null)
				currentState.onStartState();
		}
		
		
	}

	private void OnCollisionEnter2D(Collision2D coll)
    {
		if(currentState is Jump)
		{
			((Jump)currentState).grounded = true;
		}
        // 캡슐화 위배
    }
}
