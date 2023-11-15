using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScaleChangingObstaclePrefabController : MonoBehaviour
{
    [SerializeField] private float _speedChangingScale = 2f; 
    [SerializeField] private float _multiSizeScale = 2f;
    
    private Vector3 _startTransform;
    private Vector3 _newScale;
    private float _currentTime;

    private void Start()
    {
        _startTransform = GetComponent<Transform>().localScale;
        _newScale = new Vector3(_startTransform.x * _multiSizeScale, _startTransform.y * _multiSizeScale,
            transform.localScale.z);
    }
    
    private void Update()
    {
        _currentTime += Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _speedChangingScale) / _speedChangingScale;

        var currentScale = Vector3.Lerp(_startTransform,_newScale,progress);
        
        transform.localScale = currentScale;
    }
}
