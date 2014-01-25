using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(Camera.main.transform.forward * 4000);
	}

}
