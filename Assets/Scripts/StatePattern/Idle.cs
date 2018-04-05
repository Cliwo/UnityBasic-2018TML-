using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State {

	public Idle(GameObject owner):base(owner){}
		
    public override State HandleInput()
    {
		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			return new Walk(this.owner);
			//Walk
		}
		else if(Input.GetKeyDown(KeyCode.Space))
		{
			return new Jump(this.owner);
			//Jump
		}
        return null;
    }
    public override void StateUpdate()
    {
        //Do nothing
    }
}
