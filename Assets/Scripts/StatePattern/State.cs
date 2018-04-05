using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {
	protected GameObject owner;
	public System.Action onStartState;
	public System.Action onEndState;

	public State(GameObject owner){
		this.owner = owner;
		
	}
	public abstract State HandleInput();
	public abstract void StateUpdate();
}
