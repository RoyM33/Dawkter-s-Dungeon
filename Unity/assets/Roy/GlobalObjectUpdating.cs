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
            var normalColor = _playerColorObjects.FirstOrDefault(item => item.name == "NormalColor");
            if (normalColor)
            {
                normalColor.SetActive(false);
            }

            startBlinking = true;
            _currentColor = value;
            ChangePlayerColor(value);
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
                case Colors.normal:
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
                    foreach (var item in _yellowObjects)
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
    private List<GameObject> _playerColorObjects =  new List<GameObject>();

	void Start () {
       _blueObjects = GameObject.FindGameObjectsWithTag("Blue").ToList();
        _redObjects = GameObject.FindGameObjectsWithTag("Red").ToList();
        _yellowObjects = GameObject.FindGameObjectsWithTag("Yellow").ToList();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        foreach(Transform child in player.transform)
        {
            var particleSystem = child.GetComponent<ParticleSystem>();
            if (particleSystem)
                _playerColorObjects.Add(child.gameObject);
        }
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
        if (item.name == "Entrance")
            return;
        var mesh = item.GetComponent<MeshRenderer>();
        if (mesh)
        {
            mesh.enabled = true;
        }
    }

    private static void AdjustMeshToOpposite(GameObject item)
    {
        if (item.name == "Entrance")
        {
            var trapDoor = item.GetComponent<TrapDoor>();
            if(!trapDoor.activated)
                return;
        }
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

    private void ChangePlayerColor(Colors colorToChangeTo)
    {
        foreach (var item in _playerColorObjects)
        {
            switch (item.name)
            {
                case "BlueColor":
                    item.SetActive(colorToChangeTo == Colors.blue);
                    break;
                case "RedColor":
                    item.SetActive(colorToChangeTo == Colors.red);
                    break;
                case "Yellow":
                    item.SetActive(colorToChangeTo == Colors.yellow);
                    break;
                case "NormalColor":
                    item.SetActive(colorToChangeTo == Colors.normal);
                    break;
            }
            Debug.Log(item.name);
        }
    }
}

public enum Colors {
    red,
    blue,
    yellow,
    normal
}
