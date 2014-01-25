using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float Health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		Health -= 10.01f;//10 shots to kill
		if (Health < 0 && other.name.Equals("Bullet(Clone)"))
		{
			Destroy(this.gameObject);
		}
	}
}
