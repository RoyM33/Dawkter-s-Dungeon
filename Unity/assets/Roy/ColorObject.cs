using UnityEngine;
using System.Collections;

public class ColorObject : MonoBehaviour {

    private GlobalObjectUpdating _controller;
    public Colors myColor;
	void Start () {
        _controller = GameObject.FindObjectOfType<GlobalObjectUpdating>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider objectColliding)
    {
        Debug.Log("entered");
        if (objectColliding.tag == "Player")
        {
            _controller.currentColor = myColor;
            GameObject.Destroy(this.gameObject);
        }
    }
}
