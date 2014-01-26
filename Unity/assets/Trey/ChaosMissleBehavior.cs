using UnityEngine;
using System.Collections;

public class ChaosMissleBehavior : MonoBehaviour
{
    public GameObject Target;

    public float Speed = 10;
    public float Damage = 10;
    public float Turn = 1f;

    private GameObject TargetRotationHelper;


    // Use this for initialization
    void Start()
    {
        this.transform.rotation = Random.rotation;

        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Player");


        TargetRotationHelper = new GameObject("RotationHelper");
        TargetRotationHelper.transform.parent = this.transform;
        TargetRotationHelper.EnsureComponent<lookatPlayer>();

        //this.EnsureComponent<ImpactDamage>().Damage = Damage;

        this.EnsureComponent<Rigidbody>();
        rigidbody.useGravity = false; 

    }


    void OnTriggerEnter(Collider objectColliding)
    {
        Character character = objectColliding.GetComponent<Character>();

        if (character != null)
        {
            character.Health -= Damage;
        }

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        var rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Turn);
    }

    //void FixedUpdate()
    //{
    //    rigidbody.velocity = Vector3.zero;
    //    rigidbody.AddForce(this.transform.forward * 400);       
    //}
}
