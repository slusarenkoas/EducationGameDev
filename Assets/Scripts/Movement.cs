using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    private void Update()
    {
        var position = transform.position;
        var rotation = transform.rotation;
        
        var step = _speed * Time.deltaTime;
        
        
        if (Input.GetKey(KeyCode.W))
        {
            position.z += step;
            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            position.z -= step;
            transform.position = position;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= step;
            transform.position = position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += step;
            transform.position = position;
        }
    }
}
