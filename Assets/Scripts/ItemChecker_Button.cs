using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecker_Button : MonoBehaviour {

	public GameObject mApple;
	private GameObject instantiatedApple;

	private Vector3 appleTransform = new Vector3(8.82f,4.33f,0f);
	// Use this for initialization
	private bool enableInput;

	private void Awake() {
		enabled = false;	
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enabled && Input.GetKeyDown(KeyCode.Space))
		{
			if(instantiatedApple == null)
			{
				instantiatedApple = Instantiate<GameObject>(mApple);
				instantiatedApple.transform.position = appleTransform;
				ItemChecker_Apple script = instantiatedApple.GetComponent<ItemChecker_Apple>();
				
				script.onDestroyCallback += ()=>{ 
					instantiatedApple = null;
					Debug.Log("Destroy callback called");
				} ;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Character")
		{
			enabled = true;
		}	
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="Character")
		{
			enabled = false;
		}	
	}
}
