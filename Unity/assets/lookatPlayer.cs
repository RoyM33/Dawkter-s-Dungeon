using UnityEngine;
using System.Collections;

public class lookatPlayer : MonoBehaviour {
	// Use this for initialization
	private PlayerCharacter _player;
	void Start () {
		_player = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
	}

	// Update is called once per frame
	void Update () {
//		if(_player.ViewOption == PlayerViewOptions.OverTheShoulder)
//		{
//			this.transform.LookAt(Camera.main.transform.position);//lookatTarget.position);
//		}
//		else
		//{
			this.transform.LookAt(_player.transform.position);
		//}
	}
}
