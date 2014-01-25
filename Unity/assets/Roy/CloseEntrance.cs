using UnityEngine;
using System.Collections;

public class CloseEntrance : MonoBehaviour {

    private BoxCollider parentBox;
    private MeshRenderer parentMesh;
	// Use this for initialization
	void Start () {
        var parent = this.transform.parent;
        parentBox = parent.GetComponent<BoxCollider>();
        parentMesh = parent.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider objectColliding)
    {
        Debug.Log("entered");
        if (objectColliding.tag == "Player")
        {
            parentBox.enabled = true;
            parentMesh.enabled = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
