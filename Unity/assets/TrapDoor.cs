using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour {

    private bool _activated;
    internal bool activated
    {
        get {return _activated;}
        set
        {
            _activated = value;
            if (value)
            {
                this.GetComponent<BoxCollider>().enabled = true;
                this.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
