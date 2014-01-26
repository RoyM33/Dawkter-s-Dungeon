using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	
	public double timebetweenshots = .1;
	public double timebetweenSounds = 1;
	private double lastfiretime = 0;
	private double lastSoundtime = 0;
	public GameObject Bullet;
	public AudioClip Audio;
	public AudioSource audioS;
	private PlayerCharacter _player;
	
	// Use this for initialization
	void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
	}
	
	// Update is called once per frame
	void Update()
	{
		lastfiretime += Time.deltaTime;
		lastSoundtime += Time.deltaTime;
		if(lastfiretime > timebetweenshots && Input.GetButton("Fire1") == true&& _player.ViewOption == PlayerViewOptions.OverTheShoulder)
		{
			lastfiretime = 0;
			var clone  = Instantiate(Bullet,Camera.main.transform.position,Camera.main.transform.rotation);
			
			if(lastSoundtime > timebetweenshots)
			{
				lastSoundtime = 0;
				this.audioS.PlayOneShot(Audio);
			}
			Destroy(clone, .5f);
		}
		
	}
	
}
