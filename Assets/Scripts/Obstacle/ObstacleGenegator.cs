using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenegator : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _minSpawnPositionY;
    [SerializeField] private float _maxSpawnPositionY;

    private float _elapsedTime;

    private void Start()
    {
        _elapsedTime = 0;

        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject obstacle))
            {
                _elapsedTime = 0;

                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector2 spawnPoint = new Vector2(transform.position.x, spawnPositionY);

                obstacle.SetActive(true);
                obstacle.transform.position = spawnPoint;

                DisableOffscreenObjects();
            }
        }
    }
}
