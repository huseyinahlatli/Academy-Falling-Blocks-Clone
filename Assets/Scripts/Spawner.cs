using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject fallingBlockPrefab;
    [SerializeField] private Vector2 secondsBetweenSpawnsMinMax;
    [SerializeField] private Vector2 spawnSizeMinMax;
    [SerializeField] private float spawnAngleMax;
    
    private Vector2 _screenHalfSizeWorldUnits;
    private float _nextSpawnTime;
    
    private void Start()
    {
        float orthographicSize;  
        var main = Camera.main;
        
        if (main != null)
            _screenHalfSizeWorldUnits = new Vector2(main.aspect * (orthographicSize = main.orthographicSize), orthographicSize);
    }

    private void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            
            _nextSpawnTime = Time.time + secondsBetweenSpawns;

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            
            Vector2 spawnPosition = new Vector2(Random.Range(-_screenHalfSizeWorldUnits.x, _screenHalfSizeWorldUnits.x), _screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBlock = Instantiate (fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
