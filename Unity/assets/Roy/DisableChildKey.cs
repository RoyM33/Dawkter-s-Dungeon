using UnityEngine;
using System.Collections;

public class DisableChildKey : MonoBehaviour {

    private bool _respawning;
    private float _timeElapsed = 0;
    public float _timeForRespawn = 5;
    private ColorObject _childKey;
	// Use this for initialization
	void Start () {
        foreach (Transform child in this.transform)
        {
            _childKey = child.GetComponent<ColorObject>();
            if (_childKey)
                break;
        }
        if (!_childKey)
            Debug.Log("UnableToFindKey");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (_childKey._pickedUp)
        {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed >= _timeForRespawn)
            {
                _childKey.gameObject.SetActive(true);
                _childKey._pickedUp = false;
                _timeElapsed = 0;
            }

        }
    }
}
