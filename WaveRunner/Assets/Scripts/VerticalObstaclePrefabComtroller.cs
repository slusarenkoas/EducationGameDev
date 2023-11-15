using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstaclePrefabComtroller : MonoBehaviour
{
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _speedMultiply = 1f;
    
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _currentTime;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = new Vector3(_startPosition.x,_startPosition.y + _distance, _startPosition.z);
    }

    private void Update()
       {
           _currentTime += Time.deltaTime * _speedMultiply;

           var progress = (Mathf.Sin(_currentTime) + 1) / 2;

           var newPosition = Vector3.Lerp(_startPosition, _endPosition , progress);
           transform.position = newPosition;
       }
}
