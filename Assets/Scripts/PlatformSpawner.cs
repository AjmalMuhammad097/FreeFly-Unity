using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private PlatformBehaviour _platformPrefab;
    [SerializeField] private PlatformBehaviour _superPlatformPrefab;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private int _initialPlatformCount = 10;
    [SerializeField] private float minVerticalDistance = 1f, maxVerticalDistance = 2.5f;


    private int indexToCheck = 5;
    private int indexToTanslate = 0;
    private float levelWidth;
    private List<PlatformBehaviour> platformPoolerList = new();
    private Vector2 spawnPosition;
    private bool superCharge = false;
    private WaitForSeconds waitForSeconds = new(0.01f);

    private void Start()
    {
        spawnPosition = transform.position;
        levelWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x - _platformPrefab.GetComponent<SpriteRenderer>().bounds.extents.x / 2f;
        InstantiatePlatforms();
    }

    private void Update()
    {
        transform.position = _cameraTransform.position;

        if (indexToCheck < platformPoolerList.Count)
        {
            if (transform.position.y >= platformPoolerList[indexToCheck].transform.position.y)
            {
                TranslatePlatforms(indexToTanslate);
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
        spawnPosition = new(0f, spawnPosition.y);
        spawnPosition += new Vector2(Random.Range(-levelWidth, levelWidth), Random.Range(minVerticalDistance, maxVerticalDistance));
        PlatformBehaviour tempPlatform;
        if (!superCharge)
        {
            if (Random.Range(0, 3) == 0)
            {
                superCharge = true;
                tempPlatform = Instantiate(_superPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else tempPlatform = Instantiate(_platformPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            tempPlatform = Instantiate(_platformPrefab, spawnPosition, Quaternion.identity);
        }
        platformPoolerList.Add(tempPlatform);
    }

    private void TranslatePlatforms(int platformIndex)
    {
        platformPoolerList[platformIndex].transform.position = new Vector2(0f, platformPoolerList[platformIndex].transform.position.y);
        spawnPosition = new Vector2(0f, spawnPosition.y);
        spawnPosition += new Vector2(Random.Range(-levelWidth, levelWidth), Random.Range(minVerticalDistance, maxVerticalDistance));
        platformPoolerList[platformIndex].transform.position = spawnPosition;
        StartCoroutine(GrowPlatformAnimation(platformPoolerList[platformIndex]));
        if (indexToTanslate < platformPoolerList.Count - 1) indexToTanslate++;
        else indexToTanslate = 0;
        indexToCheck = (indexToTanslate + 5) % (platformPoolerList.Count - 1);
    }

    private IEnumerator GrowPlatformAnimation(PlatformBehaviour platform)
    {
        for (int i = 0; i <= 10; i++)
        {
            float k = (float)i / 10;
            platform.transform.localScale = new Vector3(k, k, k);
            yield return waitForSeconds;
        }
    }

}
