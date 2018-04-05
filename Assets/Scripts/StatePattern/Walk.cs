using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : State
{
	private enum Orient{LEFT, RIGHT};
	private Orient orient;
	private const float inputAvailableTime = 0.5f;
	private const float walkSpeed = 0.5f;
	private float startTime;
	public Walk (GameObject owner) : base (owner) {
		onStartState += OnStart;
	}
    public override State HandleInput()
    {
        if(Time.time - startTime < inputAvailableTime)
		{
			if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if(orient == Orient.LEFT)
				{
					return new Run(this.owner);
				}
				else
				{
					return new Idle(this.owner);
				}
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if(orient == Orient.LEFT)
				{
					return new Idle(this.owner);
				}
				else
				{
					return new Run(this.owner);
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow) && orient == Orient.LEFT)
		{
			return new Idle(this.owner);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) && orient == Orient.RIGHT)
		{
			return new Idle(this.owner);
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			return new Jump(this.owner);
			//Jump
		}
		return null;
    }

    public override void StateUpdate()
    {
		float xDelta = Input.GetAxis("Horizontal");
		owner.transform.Translate(new Vector3(xDelta * walkSpeed, 0, 0));
    }

	private void OnStart() {
		startTime = Time.time;
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			orient = Orient.LEFT;
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			orient = Orient.RIGHT;
		}
	}

}
