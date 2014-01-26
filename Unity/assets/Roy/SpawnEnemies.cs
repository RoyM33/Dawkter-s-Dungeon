using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{
    public float _spawnDelayTime = 0;
    public float spawnTimerBetweenStart = 1;
    public float spawnTimerBetweenEnd = 3;
    private float _timeElapsed = 0;
    public float _maxRangeRadius;
    public float _minRangeRadius;
    public bool startImmediatly = false;
    public bool alwaysSpawn = false;
    private bool started;
    public GameObject[] enemyPrefab;
    private Transform Character;
    private int enemiesLeft;
    public GameObject Prize;
    private List<GameObject> enemiesSpawned =  new List<GameObject>();

    void Start()
    {
        started = startImmediatly;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (!alwaysSpawn)
            {
                if (enemiesLeft > 0)
                {
                    SpawnEnemiesWithTimer();
                }
                else
                {
                    foreach (var enemy in enemiesSpawned.ToArray())
                    {
                        if (enemy == null)
                            enemiesSpawned.Remove(enemy);
                    }
                    if (enemiesSpawned.Count <= 0)
                    {
                        started = false;
                        if (Prize)
                            Instantiate(Prize, new Vector3(this.transform.position.x, 1, this.transform.position.z), this.transform.rotation);
                    }
                }
            }
            else
            {
                SpawnEnemiesWithTimer();
            }
        }
    }

    private void SpawnEnemiesWithTimer()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= _spawnDelayTime)
        {
            enemiesLeft--;
            SpawnEnemy();
            _timeElapsed = 0;
            _spawnDelayTime = Random.Range(spawnTimerBetweenStart, spawnTimerBetweenEnd);
            Debug.Log(_spawnDelayTime);
        }
    }

    public void StartSpawning(int timeToWait, int numberToSpawn)
    {
        enemiesLeft = numberToSpawn;
        _spawnDelayTime = timeToWait;
        this.started = true;
    }

    private void SpawnEnemy()
    {
       var randomPointInsideCircle = Random.insideUnitSphere * _maxRangeRadius;
        var possibleNewLocation = new Vector3(this.transform.position.x + randomPointInsideCircle.x, this.transform.position.y, this.transform.position.z + randomPointInsideCircle.y);
        while (EnemyIsInMinimumRange(possibleNewLocation))
        {
            randomPointInsideCircle = Random.insideUnitCircle * _maxRangeRadius;
            possibleNewLocation = new Vector3(this.transform.position.x + randomPointInsideCircle.x, this.transform.position.y, this.transform.position.z + randomPointInsideCircle.y);
        }
        var enemyToSpawnIndex = Random.Range(0, enemyPrefab.Length);
        
        GameObject spawnedEnemy = Instantiate(enemyPrefab[enemyToSpawnIndex], possibleNewLocation, transform.rotation) as GameObject;
        Debug.Log(spawnedEnemy);
        enemiesSpawned.Add(spawnedEnemy);        
    }

    private bool EnemyIsInMinimumRange(Vector3 randomPointInsideCircle)
    {
        var distanceBetweenNewEnemyAndYou = Vector3.Distance(randomPointInsideCircle, this.transform.position);
        if (distanceBetweenNewEnemyAndYou < _minRangeRadius)
        {
            return true;
        }
        return false;
    }

    void OnGUI()
    {
        if (started && !alwaysSpawn)
        {
            GUI.Label(new Rect(50, 50, Screen.width / 2, Screen.height / 2), enemiesLeft.ToString());
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 lastposition = Vector3.zero;

        for (int i = 0; i < 361; i++)
        {
            var position = new Vector3(transform.position.x + _minRangeRadius * Mathf.Cos(Mathf.Deg2Rad * i), transform.position.y, transform.position.z + _minRangeRadius * Mathf.Sin(Mathf.Deg2Rad * i));

            if (lastposition != Vector3.zero)
                Gizmos.DrawLine(lastposition, position);

            lastposition = position;
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < 361; i++)
        {
            var position = new Vector3(transform.position.x + _maxRangeRadius * Mathf.Cos(Mathf.Deg2Rad * i), transform.position.y, transform.position.z + _maxRangeRadius * Mathf.Sin(Mathf.Deg2Rad * i));

            if (lastposition != Vector3.zero)
                Gizmos.DrawLine(lastposition, position);

            lastposition = position;
        }
    }
}



