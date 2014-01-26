using UnityEngine;
using System.Collections;

public class lookatPlayer : MonoBehaviour {
	
	public Transform lookatTarget;
	// Use this for initialization
	void Start () {
		lookatTarget = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(lookatTarget.position);
	}
}
