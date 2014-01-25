﻿using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

    public float spawnTimerInSeconds = 1;
    private float _timeElapsed = 0;
    public float _maxRangeRadius;
    public float _minRangeRadius;
    private bool started;
    public Transform[] enemyPrefab;
    private Transform Character;
    private int enemiesLeft;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (enemiesLeft > 0)
            {
                _timeElapsed += Time.deltaTime;
                if (_timeElapsed >= spawnTimerInSeconds)
                {
                    enemiesLeft--;
                    SpawnEnemy();
                    _timeElapsed = 0;
                    spawnTimerInSeconds = Random.Range(1, 3);
                }
            }
            else
            {
                var enemies = GameObject.FindWithTag("Enemy");
                if (enemies == null)
                    started = false;
                    //You win
            }
        }
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
        //var enemyToSpawnIndex = Random.Range(0, enemyPrefab.Length - 1);
        Instantiate(enemyPrefab[0], possibleNewLocation, transform.rotation);
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
        if (!started)
        {
            if (GUI.Button(new Rect(0, 100, 200, 200), "Begin"))
            {
                enemiesLeft = 20;
                started = true;
            }
        }
        else
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
            var position = new Vector3(transform.position.x + _minRangeRadius * Mathf.Cos(Mathf.Deg2Rad * i), 1, transform.position.z + _minRangeRadius * Mathf.Sin(Mathf.Deg2Rad * i));

            if (lastposition != Vector3.zero)
                Gizmos.DrawLine(lastposition, position);

            lastposition = position;
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < 361; i++)
        {
            var position = new Vector3(transform.position.x + _maxRangeRadius * Mathf.Cos(Mathf.Deg2Rad * i), 1, transform.position.z + _maxRangeRadius * Mathf.Sin(Mathf.Deg2Rad * i));

            if (lastposition != Vector3.zero)
                Gizmos.DrawLine(lastposition, position);

            lastposition = position;
        }
    }
}



