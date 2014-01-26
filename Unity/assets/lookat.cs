using UnityEngine;
using System.Collections;

public class lookat : MonoBehaviour {

	public Transform lookatTarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(lookatTarget.position);
	}
}
