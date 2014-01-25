using UnityEngine;
using System.Collections;

public class RadialDamage : MonoBehaviour
{

    public float DamagePerSecond = 20;
    public float Radius = 2;

    Character _player;


    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(_player.transform.position, this.transform.position) <= Radius)
        {
            _player.Health -= DamagePerSecond * Time.deltaTime;
        }
    }
}
