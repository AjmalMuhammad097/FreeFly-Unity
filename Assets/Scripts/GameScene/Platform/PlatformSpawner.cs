using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private PlatformBehaviour _platformPrefab;
    [SerializeField] private PlatformBehaviour _superPlatformPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private int _initialPlatformCount = 10;
    [SerializeField] private float _minVerticalDistance = 1f, _maxVerticalDistance = 2.5f;
    [SerializeField] private float _horizontalOffset;

    private int indexToCheck = 5;
    private int indexToTranslate = 0;
    private float levelWidth;
    [SerializeField] private List<PlatformBehaviour> platformPoolerList = new();
    private Vector2 spawnPosition;
    private bool superCharge = false;
    private readonly WaitForSeconds waitForSeconds = new(0.01f);

    private void Start()
    {
        spawnPosition = transform.position;
        levelWidth = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x -
            _platformPrefab.GetComponent<SpriteRenderer>().bounds.extents.x / 2f -
            _horizontalOffset;

        InstantiatePlatforms();
    }

    private void Update()
    {
        transform.position = _camera.transform.position;        //This works for the Asteroid Spawner, Its in same GameObject.

        if (indexToCheck < platformPoolerList.Count)
        {
            if (transform.position.y >= platformPoolerList[indexToCheck].transform.position.y)
            {
                TranslatePlatforms(indexToTranslate);
            }
        }
    }


    private void InstantiatePlatforms()
    {
        for (int i = 0; i < _initialPlatformCount; i++)
        {
            CreatePlatforms();
        }
    }

    private void CreatePlatforms()
    {
        // Create a new spawn position for each platform
        var newSpawnPosition = new Vector2(0f, spawnPosition.y);
        newSpawnPosition += new Vector2(Random.Range(-levelWidth, levelWidth),
            Random.Range(_minVerticalDistance, _maxVerticalDistance));

        PlatformBehaviour tempPlatform;

        if (Random.Range(0, 3) == 0 && !superCharge)
        {
            superCharge = true;
            tempPlatform = Instantiate(_superPlatformPrefab, newSpawnPosition, Quaternion.identity);
        }
        else
        {
            tempPlatform = Instantiate(_platformPrefab, newSpawnPosition, Quaternion.identity);
        }
        platformPoolerList.Add(tempPlatform);

        // Update spawnPosition for the next platform
        spawnPosition = newSpawnPosition;
    }

    private void TranslatePlatforms(int platformIndex)
    {
        var platform = platformPoolerList[platformIndex];

        // Reset platform position
        platform.transform.position = new(Random.Range(-levelWidth, levelWidth), spawnPosition.y);

        // Update spawn position
        spawnPosition = new Vector2(0f, spawnPosition.y);
        spawnPosition += new Vector2(platform.transform.position.x, Random.Range(_minVerticalDistance, _maxVerticalDistance));

        // Start growing platform
        StartCoroutine(GrowPlatformAnimation(platform));        //This doesnt see in the screen. maybe check git.

        // Update indexToTranslate and indexToCheck
        indexToTranslate = (indexToTranslate + 1) % platformPoolerList.Count;
        indexToCheck = (indexToTranslate + 5) % platformPoolerList.Count;
    }

    private IEnumerator GrowPlatformAnimation(PlatformBehaviour platform)
    {
        for (int i = 0; i <= 10; i++)
        {
            float scale = (float)i / 10;
            platform.transform.localScale = new Vector3(scale, scale, scale);
            yield return waitForSeconds;
        }
    }

}
