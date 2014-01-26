using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(this.transform.forward * 4000);
	}

}
