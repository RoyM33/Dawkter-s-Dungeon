using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GlobalObjectUpdating : MonoBehaviour {

    private Colors _currentColor;
    public Colors currentColor
    { 
        get { return _currentColor; }
        set
        {
            startBlinking = true;
            _currentColor = value; 
            switch (value)
            {
                case Colors.red:
                    foreach (var item in _blueObjects)
                    {
                        AdjustMeshToTrue(item);
                        item.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    foreach (var item in _yellowObjects)
                    {
                        AdjustMeshToTrue(item);
                        item.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    break;
                case Colors.blue:
                    foreach (var item in _redObjects)
                    {
                        AdjustMeshToTrue(item);
                        item.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    foreach (var item in _yellowObjects)
                    {
                        AdjustMeshToTrue(item);
                        item.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    break;
                case Colors.yellow:
                    foreach (var item in _blueObjects)
                    {
                        AdjustMeshToTrue(item);
                        item.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    foreach (var item in _redObjects)
                    {
                        AdjustMeshToTrue(item);
                        item.GetComponent<BoxCollider>().isTrigger = false;
                    }
                    break;
            }
        }
    }
    private bool startBlinking = false;
    private List<GameObject> _blueObjects = new List<GameObject>();
    private List<GameObject> _redObjects=new List<GameObject>();
    private List<GameObject> _yellowObjects=new List<GameObject>();
    public float flashIntervals = .5f;
    private float currentInterval = 0;

	void Start () {
       _blueObjects = GameObject.FindGameObjectsWithTag("Blue").ToList();
        _redObjects = GameObject.FindGameObjectsWithTag("Red").ToList();
        _yellowObjects = GameObject.FindGameObjectsWithTag("Yellow").ToList();
       }
	
	void Update () {
        if(startBlinking)
        {
            currentInterval += Time.deltaTime;
            if (currentInterval >= flashIntervals)
            {
                switch (currentColor)
                {
                    case Colors.red:
                        foreach (var item in _redObjects)
                        {
                            AdjustMeshToOpposite(item);
                            item.GetComponent<BoxCollider>().isTrigger = true;
                        }
                        break;
                    case Colors.blue:
                        foreach (var item in _blueObjects)
                        {
                            AdjustMeshToOpposite(item);
                            item.GetComponent<BoxCollider>().isTrigger = true;
                        }
                        break;
                    case Colors.yellow:
                        foreach (var item in _yellowObjects)
                        {
                            AdjustMeshToOpposite(item);
                            item.GetComponent<BoxCollider>().isTrigger = true;
                        }
                        break;
                    default:
                        break;
                }
                currentInterval = 0;
            }
        }
	}

    private static void AdjustMeshToTrue(GameObject item)
    {
        var mesh = item.GetComponent<MeshRenderer>();
        if (mesh)
        {
            mesh.enabled = true;
        }
    }

    private static void AdjustMeshToOpposite(GameObject item)
    {
        var mesh = item.GetComponent<MeshRenderer>();
        if (mesh)
        {
            mesh.enabled = !mesh.enabled;
        }
    }

    public void AddRed(GameObject itemToAdd)
    {
        _redObjects.Add(itemToAdd);
    }
    public void AddYellow(GameObject itemToAdd)
    {
        _blueObjects.Add(itemToAdd);
    }
    public void AddBlue(GameObject itemToAdd)
    {
        _yellowObjects.Add(itemToAdd);
    }
}

public enum Colors {
    red,
    blue,
    yellow
}
