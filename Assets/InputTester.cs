using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer sprite;
	void Start () {
	sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float xDelta = Input.GetAxis("Horizontal");
		transform.Translate(new Vector3(xDelta, 0,0));

		if(xDelta < 0)
		{
			sprite.flipX = true;
		}
		else if (xDelta > 0)
		{
			sprite.flipX = false;
		}
	}
}
