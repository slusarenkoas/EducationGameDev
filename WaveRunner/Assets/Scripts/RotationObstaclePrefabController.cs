using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstaclePrefabController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 90f;
    
    private float _currentTime;
    

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }
}
