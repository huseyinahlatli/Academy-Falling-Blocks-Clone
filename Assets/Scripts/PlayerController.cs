using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private float _screenHalftWidthInWorldUnits;

    private void Start()
    {
        SetPlayerTransition();
    }

    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * (velocity * Time.deltaTime));

        if (transform.position.x < -_screenHalftWidthInWorldUnits)
            transform.position = new Vector2(_screenHalftWidthInWorldUnits, transform.position.y);
        
        if (transform.position.x > _screenHalftWidthInWorldUnits)
            transform.position = new Vector2(-_screenHalftWidthInWorldUnits, transform.position.y);
    }

    private void SetPlayerTransition()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        var main = Camera.main;
        if (main != null)
            _screenHalftWidthInWorldUnits = main.aspect * main.orthographicSize + halfPlayerWidth;
    }
}
