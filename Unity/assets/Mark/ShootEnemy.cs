using UnityEngine;
using System.Collections;

public class ShootEnemy : MonoBehaviour
{
	
	public double timebetweenshots = .1;
	public double timebetweenSounds = 1;
	private double lastfiretime = 0;
	private double lastSoundtime = 0;
	public GameObject Bullet;
	public AudioClip Audio;
	public AudioSource audioS;
	public GameObject _gunUser;
	
	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
		lastfiretime += Time.deltaTime;
		lastSoundtime += Time.deltaTime;
		if(lastfiretime > timebetweenshots && Input.GetButton("Fire1") == true)
		{
			lastfiretime = 0;
			var clone  = Instantiate(Bullet,_gunUser.transform.position,_gunUser.transform.rotation);
			
			if(lastSoundtime > timebetweenshots)
			{
				lastSoundtime = 0;
				this.audioS.PlayOneShot(Audio);
			}
			Destroy(clone, .5f);
		}
		
	}
	
}
