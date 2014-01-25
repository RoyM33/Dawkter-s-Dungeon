using UnityEngine;
using System.Collections;

public class PlayerCharacter : Character {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width * Health / 100, 30), Health.ToString());
    }
}
