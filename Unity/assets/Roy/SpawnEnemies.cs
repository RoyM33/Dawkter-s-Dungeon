using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{

    public float spawnTimerInSeconds = 1;
    private float _timeElapsed = 0;
    private float _maxRangeRadius;
    private float _minRangeRadius;
    // Use this for initialization
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            if (child.name == "MaxSpawnRange")
            {
                _maxRangeRadius = child.transform.localScale.x / 2;
            }
            if (child.name == "MinSpawnRadius")
            {
                _minRangeRadius = child.transform.localScale.x / 2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= spawnTimerInSeconds)
        {
            SpawnEnemy();
            _timeElapsed = 0;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        var randomPointInsideCircle = Random.insideUnitSphere * _maxRangeRadius;
        var possibleNewLocation = new Vector3(this.transform.position.x + randomPointInsideCircle.x, this.transform.position.y, this.transform.position.z + randomPointInsideCircle.y);
        while (EnemyIsInMinimumRange(possibleNewLocation))
        {
            Debug.Log("respawning Location");
            randomPointInsideCircle = Random.insideUnitCircle * _maxRangeRadius;
            possibleNewLocation = new Vector3(this.transform.position.x + randomPointInsideCircle.x, this.transform.position.y, this.transform.position.z + randomPointInsideCircle.y);
        }
        enemy.transform.position = possibleNewLocation;
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
}
