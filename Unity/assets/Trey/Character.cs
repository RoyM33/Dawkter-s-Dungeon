using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour
{
	public Light scarylight;
    public float Health = 100;
    public Action damaged;
    public float maxHealth = 100;
	private PlayerCharacter _player;
    // Use this for initialization
    void Start()
    {
        if (Health > maxHealth)
            maxHealth = Health;
		_player = GameObject.FindWithTag("Player").GetComponent<PlayerCharacter>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Bullet(Clone)"))
        {
			Destroy(other.gameObject);
			var clone  = Instantiate(GameObject.Find("BulletHitJuice"),other.transform.position,other.transform.rotation);
			Destroy(clone, .1f);
			//this.audioS.PlayOneShot(Audio);
			//AudioSource[] audios = _player.GetComponents<AudioSource>();
			//audios[2];
            Health -= 10.01f;//10 shots to kill
            if (damaged != null)
                damaged();
            if (Health < 0)
            {
				var clone2  = Instantiate(GameObject.Find("EnemyDeathJuice"),this.transform.position,this.transform.rotation);
				Destroy(clone2, .5f);
                Destroy(this.gameObject);
            }
        }
    }
}
