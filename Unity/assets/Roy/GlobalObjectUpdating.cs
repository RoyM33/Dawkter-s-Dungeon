using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GlobalObjectUpdating : MonoBehaviour {

    public Colors currentColor = Colors.blue;
    private List<GameObject> _blueObjects;
    private List<GameObject> _redObjects;
    private List<GameObject> _yellowObjects;
    public float flashIntervals = .5f;
    private float currentInterval = 0;
	// Use this for initialization
	void Start () {
        _blueObjects = GameObject.FindGameObjectsWithTag("Blue").ToList();
        Debug.Log(_blueObjects.Count);
        _redObjects = GameObject.FindGameObjectsWithTag("Red").ToList();
        _yellowObjects = GameObject.FindGameObjectsWithTag("Yellow").ToList();
	}
	
	// Update is called once per frame
	void Update () {
        currentInterval += Time.deltaTime;
        if (currentInterval >= flashIntervals)
        {
            switch (currentColor)
            {
                case Colors.red:
                    break;
                case Colors.blue:
                    foreach (var item in _blueObjects)
                    {
                        var mesh = item.GetComponent<MeshRenderer>();
                        if (mesh)
                        {
                            mesh.enabled = !mesh.enabled;
                        }
                    }
                    break;
                case Colors.yellow:
                    break;
                default:
                    break;
            }
            currentInterval = 0;
        }
	}
}

public enum Colors {
    red,
    blue,
    yellow
}
