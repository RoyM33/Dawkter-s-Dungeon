using UnityEngine;
using System.Collections;

public class CloseEntrance : MonoBehaviour {

    private TrapDoor parentDoor;
	// Use this for initialization
	void Start () {
        parentDoor = this.transform.parent.GetComponent<TrapDoor>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider objectColliding)
    {
        if (objectColliding.tag == "Player")
        {
            GlobalObjectUpdating globalupdater = GameObject.FindObjectOfType<GlobalObjectUpdating>();
            globalupdater.currentColor = Colors.normal;
            parentDoor.activated = true;
            GameObject.Destroy(this.gameObject, 1);
        }
    }
}
