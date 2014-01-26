using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    public GameObject ObjectToFire;
    public float ObjectsToFirePerSecond = 1;
    public GameObject CannonMount;

    private PlayerCharacter _player;
    private float _timeSinceLastFire;
    private float _timeBetweenShots;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        _timeBetweenShots = 1 / ObjectsToFirePerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeSinceLastFire < _timeBetweenShots)
        {// Wait
            _timeSinceLastFire += Time.deltaTime;
        }
        else
        {// Fire
            var clone = Instantiate(ObjectToFire, CannonMount.transform.position, CannonMount.transform.rotation);
            _timeSinceLastFire = 0;
        }
    }
}