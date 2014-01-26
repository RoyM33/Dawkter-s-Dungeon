using UnityEngine;
using System.Collections;
using System.Timers;

public class ColorObject : MonoBehaviour {

    private GlobalObjectUpdating _controller;
    public Colors myColor;
    internal bool _pickedUp;
	void Start () {
        _controller = GameObject.FindObjectOfType<GlobalObjectUpdating>();
	}

    void OnTriggerEnter(Collider objectColliding)
    {
        if (objectColliding.tag == "Player")
        {
            _controller.currentColor = myColor;
            _pickedUp = true;
           this.gameObject.SetActive(false);
        }
    }
}
