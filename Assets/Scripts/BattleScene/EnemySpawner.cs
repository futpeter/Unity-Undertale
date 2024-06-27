using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    public GameObject _enemyPrefab;

    [SerializeField] 
    public float _minimumSpawnTime;

    [SerializeField] 
    public float _maximumSpawnTime;

    private float _timeUntilSpawn;

    [SerializeField] 
    public bool enemyCanSpawn = false;

    void awake()
    {
        SetTimeUntilSpawn();
    }
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if(_timeUntilSpawn <= 0 && enemyCanSpawn == true)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }
   
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
