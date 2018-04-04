using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour {

	private SpriteRenderer s_renderer;

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
		if(!s_renderer)
		{
			Debug.LogError("Invalid Component Setting");
		}
		ground = true;
		timeBucket = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		float horizon_v = Input.GetAxis("Horizontal");
		transform.Translate(new Vector3(horizon_v * Time.deltaTime * speed, 0, 0 ));

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
            transform.Translate(new Vector3(0, yDelta , 0));
		}
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        ground = true;
		// Debug.Log("grounded");
    }

}
