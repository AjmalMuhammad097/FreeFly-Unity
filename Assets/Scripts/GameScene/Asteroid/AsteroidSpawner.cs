using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private AsteroidBehaviour _asteroidPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _minVerticalDistance = 1f, _maxVerticalDistance = 2.5f;
    [SerializeField] private float _horizontalOffset;

    private AsteroidBehaviour asteroidInstance;
    private Vector2 spawnPosition;
    private float levelWidth;

    private void Start()
    {
        spawnPosition = transform.position;
        levelWidth = _camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x -
                     _asteroidPrefab.GetComponentInChildren<SpriteRenderer>().bounds.extents.x / 2f -
                     _horizontalOffset;

        CreateAsteroid();
    }

    private void FixedUpdate()
    {
        // transform.position = _camera.transform.position; // Keep spawner at the camera's position

        if (asteroidInstance.transform.position.y < _camera.transform.position.y - _camera.orthographicSize)
        {
            RepositionAsteroid(asteroidInstance);
        }

    }


    private void CreateAsteroid()
    {
        spawnPosition = new Vector2(Random.Range(-levelWidth, levelWidth),
                                    _camera.transform.position.y + _camera.orthographicSize + Random.Range(_minVerticalDistance, _maxVerticalDistance));
        asteroidInstance = Instantiate(_asteroidPrefab, spawnPosition, Quaternion.identity);
    }

    private void RepositionAsteroid(AsteroidBehaviour asteroid)
    {
        float newX = Random.Range(-levelWidth, levelWidth);
        float newY = _camera.transform.position.y + _camera.orthographicSize + Random.Range(_minVerticalDistance, _maxVerticalDistance);

        asteroid.transform.position = new Vector2(newX, newY);
    }
}


