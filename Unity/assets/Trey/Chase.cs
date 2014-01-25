using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour
{
    public Character Target;
    private NavMeshAgent _agent;
    // Use this for initialization
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();

        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = Target.transform.position;
    }
	
	void OnTriggerEnter (Collider other)
	{
		if (other.name.Equals("Bullet(Clone)"))
		{
			Destroy(this.gameObject);
		}
	}
}
