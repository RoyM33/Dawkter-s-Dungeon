using UnityEngine;
using System.Collections;

public class FlyingFire : MonoBehaviour {

	public float chargeTime = 3.5f;
	private float timeFromCharge = 0.0f;
	public Light light1;
	//public Light light2;
	//public Light light3;
	public AudioSource audio;

	private Transform lookatTarget;
	void Start () {
		lookatTarget = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		var fwd = transform.TransformDirection (Vector3.forward);
		RaycastHit hitinfo;
		if(Physics.Raycast(this.transform.position, fwd, out hitinfo, 200))
	   	{
			if(hitinfo.collider.gameObject.name == "Player")
			{
				timeFromCharge += Time.deltaTime;
			}
			else
			{
				timeFromCharge -= Time.deltaTime;
			}
		}
		else
		{
			timeFromCharge -= Time.deltaTime;
		}
		if(timeFromCharge < 0)
		{
			timeFromCharge = 0;
		}
		if(timeFromCharge > chargeTime)
		{
			timeFromCharge = chargeTime;
		}
		light1.intensity = 8* (timeFromCharge/chargeTime);
		//light2.intensity = 8* (timeFromCharge/chargeTime);
		//light3.intensity = 8* (timeFromCharge/chargeTime);
		audio.pitch = 1.2f * (timeFromCharge/chargeTime);
		audio.volume = .5f * (timeFromCharge/chargeTime);
		if(timeFromCharge == chargeTime)
		{
			//Attack

		}
	}
}
