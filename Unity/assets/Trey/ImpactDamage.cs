using UnityEngine;
using System.Collections;

public class ImpactDamage : MonoBehaviour
{
    private bool _hit = false;
    public float Damage = 20;
    public float Radius = 1;

    Character _player;

    private static AudioClip _onHitSound;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

        if (_onHitSound == null)
        {
            _onHitSound = Resources.Load<AudioClip>("Sounds/onDashHit");
        }

        this.EnsureComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_hit && Vector3.Distance(_player.transform.position, this.transform.position) <= Radius)
        {
            _hit = true;
            _player.Health -= Damage;
            audio.PlayOneShot(_onHitSound);
        }
    }
}