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
	[SerializeField]
	private float jumpConst = 7.0f;
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
			float yDelta = (jumpConst - gravityAccelerate*(Time.time - timeBucket)) * Time.deltaTime;
            transform.Translate(new Vector3(0, yDelta , 0));
		}

		//F = ma
		//위치 = 시간 * 속도 
		//여기에서 속도는 (1) Jump를 누르는 순간 부여되는 힘 
		//(2) 중력가속도 * 시간 (가속도 * 시간은 시간에 따른 속도변화니까)를 뺀 값
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        ground = true;
		// -> 버그 존재 Tag로 거르지 않았기 때문에 Ceiling에 닿아도 Jump가 다시 가능
    }

}
