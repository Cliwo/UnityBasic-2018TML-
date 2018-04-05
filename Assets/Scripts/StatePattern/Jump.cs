using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
	public bool grounded;
	private const float gravity = 0.98f;
	private const float jumpConst = 0.5f;
	private float startTime;
	private const float walkSpeed = 0.5f;
	public Jump (GameObject owner) : base(owner){
		onStartState += OnStart;
		grounded = false;
	}
    public override State HandleInput()
    {
		if(grounded)
		{
			return new Idle(this.owner); //Idle 반환
		}
		return null;
    }

    public override void StateUpdate()
    {
		float xDelta = Input.GetAxis("Horizontal");
		float yDelta = jumpConst - gravity * (Time.time-startTime);
        owner.transform.Translate(new Vector3 (xDelta, yDelta, 0));
    }

	

	private void OnStart() {
		startTime = Time.time;
	}

}
