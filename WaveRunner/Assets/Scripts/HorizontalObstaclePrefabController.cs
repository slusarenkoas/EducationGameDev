using UnityEngine;

public class HorizontalObstaclePrefabController : MonoBehaviour
{
    [SerializeField] private float _leftBorder = -3f;
    [SerializeField] private float _rightBorder = 3f;
    [SerializeField] private float _duration = 3f;

    private float _currentTime;
    
    private void Update()
    {
        _currentTime += Time.deltaTime;
        
        var progress = Mathf.PingPong(_currentTime, _duration) / _duration;
        var position = transform.position;
        
        position = new Vector3(Mathf.Lerp(_leftBorder, _rightBorder, progress), position.y,
            position.z);
        transform.position = position;
    }
}
