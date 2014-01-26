using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour
{
	public Light scarylight;
    public float Health = 100;
    public Action damaged;
    public float maxHealth = 100;
    // Use this for initialization
    void Start()
    {
        if (Health > maxHealth)
            maxHealth = Health;
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Bullet(Clone)"))
        {
            Health -= 10.01f;//10 shots to kill
            if (damaged != null)
                damaged();
            if (Health < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
