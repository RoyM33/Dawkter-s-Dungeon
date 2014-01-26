using UnityEngine;
using System.Collections;

public class lookatPlayer : MonoBehaviour {
	// Use this for initialization
	private Transform lookatTarget;
	void Start () {
		lookatTarget = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(lookatTarget.position);
	}
}
