using System;
using System.Collections.Generic;
using UnityEngine;

namespace Patrol
{
    public class PatrolBehaviour : MonoBehaviour
    {
        [SerializeField] private List<Transform> _checkPointList = new List<Transform>();
        [SerializeField] private GameObject _player;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _durationTime = 3f;

        private Transform _nextTarget;
        private float _currentTime;
        private int _currentPoint;

        private bool _isCheckedPointNow = false;

        private void Update()
        {
            if (_currentPoint == _checkPointList.Count)
            {
                _currentPoint = 0;
            }
            
            if (_checkPointList is { Count: > 0 } && !_isCheckedPointNow)
            {
                _nextTarget = _checkPointList[_currentPoint];
                LookAtTarget();
                MoveToTheTarget();
            }

            _currentTime += Time.deltaTime;
            if (_currentTime >= _durationTime)
            {
                _isCheckedPointNow = false;
                _currentTime = 0;
            }

        }

        private void MoveToTheTarget()
        {
            var stepDistance = _speed * Time.deltaTime;

            var newPosition = Vector3.MoveTowards(_player.transform.position, _nextTarget.position, stepDistance);
            _player.transform.position = newPosition;
            if (_player.transform.position == _nextTarget.transform.position)
            {
                _isCheckedPointNow = true;
                _currentPoint++;
            }
        }

        private void LookAtTarget()
        {
            _player.transform.LookAt(_checkPointList[_currentPoint]);
        }
    }
}
