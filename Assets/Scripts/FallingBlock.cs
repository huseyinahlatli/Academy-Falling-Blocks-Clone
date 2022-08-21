using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private Vector2 speedMinMax;

    private float _visibleHeightThresold;
    
    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        _visibleHeightThresold = -Camera.main.orthographicSize  - transform.localScale.y;
    }

    private void FixedUpdate()
    {   
        transform.Translate(Vector3.down * (speed * Time.deltaTime), Space.Self);
    }

    private void Update()
    {
        // if(transform.position.y <= -6f) Destroy(gameObject, 1f); || ↓ same code

        if(transform.position.y < _visibleHeightThresold)
            Destroy(gameObject);
    }
}
