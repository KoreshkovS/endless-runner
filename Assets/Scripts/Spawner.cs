using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePatterns;
    [SerializeField] private float _startTimeBtwSpawn;
    [SerializeField] private float _decreaseTime;
    [SerializeField] private float _minTime = 0.65f;

    private float timeBtwSpawn;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, _obstaclePatterns.Length);
            Instantiate(_obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = _startTimeBtwSpawn;

            if (_startTimeBtwSpawn > _minTime)
            {
                _startTimeBtwSpawn -= _decreaseTime;

            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
