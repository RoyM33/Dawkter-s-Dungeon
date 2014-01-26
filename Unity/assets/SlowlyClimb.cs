using UnityEngine;
using System.Collections;

public class SlowlyClimb : MonoBehaviour {

	public float speedup = .001f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if(this.gameObject.transform.position.y < 25)
		{
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, (this.gameObject.transform.position.y+(speedup/Time.deltaTime)), this.gameObject.transform.position.z);
		}
	}
}
