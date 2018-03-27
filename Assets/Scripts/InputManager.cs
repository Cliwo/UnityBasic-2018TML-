using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour {

	private SpriteRenderer s_renderer;
	private CharacterController c_controller;
	private const int LEFT = 0;
	private const int RIGHT = 1;
	[SerializeField]
	private float speed = 3.0f;
	[SerializeField]
	private float gravityAccelerate = 3.0f;
	private int Orientation;
	private bool ground;

	private float timeBucket;

	// Use this for initialization
	void Awake () {
		s_renderer = GetComponent<SpriteRenderer>();
		c_controller = GetComponent<CharacterController>();
		if(!s_renderer || !c_controller)
		{
			Debug.LogError("Invalid Component Setting");
		}
		ground = true;
		timeBucket = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		float horizon_v = Input.GetAxis("Horizontal");
		c_controller.Move(new Vector3(horizon_v * Time.deltaTime * speed, 0, 0 ));

		if(horizon_v<0)
		{
			Orientation = LEFT;
			s_renderer.flipX = true;
		}
		else if(horizon_v >0)
		{
			Orientation = RIGHT;
			s_renderer.flipX = false;
		}

		if(Input.GetKeyDown(KeyCode.Space) && ground == true)
		{
			ground = false;
			timeBucket = Time.time;
		}
		if(!ground)
		{
			float yDelta = (gravityAccelerate * 2 - gravityAccelerate*(Time.time - timeBucket)) * Time.deltaTime;
			c_controller.Move(new Vector3(0, yDelta , 0));
			SimulateFakeGravity();
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log("OnCollision");
		if(gameObject.transform.position.y - hit.collider.gameObject.transform.position.y > 0)
		{
			ground = true;
		}
	}

	private void SimulateFakeGravity()
	{
		c_controller.Move(new Vector3(0, -gravityAccelerate * Time.deltaTime, 0));
	}
}
