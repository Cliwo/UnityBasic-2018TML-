using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : State
{	
	[SerializeField]
	private float runSpeed = 1.2f;
    private enum Orient{LEFT, RIGHT};
	private Orient orient;
	public Run(GameObject owner) : base(owner){}
    public override State HandleInput()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) && orient == Orient.LEFT)
		{
			return new Idle(this.owner);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow) && orient == Orient.RIGHT)
		{
			return new Idle(this.owner);
		}
        return null;
    }

    public override void StateUpdate()
    {
		float xDelta = Input.GetAxis("Horizontal");
        owner.transform.Translate(new Vector3(xDelta*runSpeed, 0f , 0f));
    }

    private void OnStart() {
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
