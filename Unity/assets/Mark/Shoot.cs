using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    public double timebetweenshots = 1;
    private double lastfiretime = 0;
    public GameObject Bullet;
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

        if (_player.ViewOption == PlayerViewOptions.OverTheShoulder)
        {
            if (lastfiretime > timebetweenshots && Input.GetButton("Fire1") == true)
            {
                var clone = Instantiate(Bullet, Camera.main.transform.position, Camera.main.transform.rotation);
                Destroy(clone, 1);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.transform.localPosition.Set(10, 10, 0);// = 10;
        }
    }
}
