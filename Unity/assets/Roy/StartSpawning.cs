using UnityEngine;
using System.Collections;

public class StartSpawning : MonoBehaviour {

    public GameObject spawnEnemiesGO;
    public int timeToWaitForSpawning = 1;
    public int numberToSpawn = 20;
    private float _timeElapsed = 0;
    private SpawnEnemies _spawnEnemies;
    private bool _startSpawning = false;
	// Use this for initialization
	void Start () {
        if (spawnEnemiesGO)
        {
            _spawnEnemies = spawnEnemiesGO.GetComponent<SpawnEnemies>();
            if (_spawnEnemies == null)
            {
                foreach (Transform child in spawnEnemiesGO.transform)
                {
                    var otherSpawnEnemies = child.GetComponent<SpawnEnemies>();
                    if (otherSpawnEnemies != null)
                    {
                        _spawnEnemies = otherSpawnEnemies;
                        break;
                    }
                }
            }
        }
	}

    void OnTriggerEnter(Collider objectEntering)
    {
        if (!_startSpawning)
        {
            if (objectEntering.tag == "Player")
            {
                Debug.Log("started");
                _spawnEnemies.StartSpawning(timeToWaitForSpawning, numberToSpawn);
                _startSpawning = true;
            }
        }
    }

    void OnDrawGizmos()
    {
        if(spawnEnemiesGO)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, spawnEnemiesGO.transform.position);
        }
    }
}
