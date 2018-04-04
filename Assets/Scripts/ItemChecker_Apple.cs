using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecker_Apple : MonoBehaviour {

	// Use this for initialization
	public event System.Action onDestroyCallback;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Character")
		{
			OnItemTouched();
		}
	}

	private void OnItemTouched()
	{
		if(onDestroyCallback != null)
		{
			onDestroyCallback();
		}
		Destroy(gameObject);
	}
}
