using UnityEngine;
using System.Collections;

public class CloseEntrance : MonoBehaviour {

    private TrapDoor parentDoor;
    private GameObject spawner;
	// Use this for initialization
	void Start () {
        parentDoor = this.transform.parent.GetComponent<TrapDoor>();
        spawner = this.GetComponent<StartSpawning>().spawnEnemiesGO;
	}

    void OnTriggerEnter(Collider objectColliding)
    {
        if (objectColliding.tag == "Player")
        {
            if (spawner)
            {
                GlobalObjectUpdating globalupdater = GameObject.FindObjectOfType<GlobalObjectUpdating>();
                globalupdater.currentColor = Colors.normal;
            }
            parentDoor.activated = true;
            GameObject.Destroy(this.gameObject, 1);
        }
    }
}
