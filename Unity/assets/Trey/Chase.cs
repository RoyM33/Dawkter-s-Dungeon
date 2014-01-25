using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	public Transform Target;
	private NavMeshAgent _agent;
	// Use this for initialization
	void Start () {
		_agent = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		_agent.destination = Target.position;
	}
}
