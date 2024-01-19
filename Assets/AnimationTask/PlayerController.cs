using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace AnimationTask
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speedChangeValue = 0.1f;
        [SerializeField] private float _speed;
        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("speed");
        private static readonly int Kick = Animator.StringToHash("kick");
        private static readonly int Kick2 = Animator.StringToHash("kick2");
        private static readonly int Kick3 = Animator.StringToHash("kick3");
        

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                _speed += _speedChangeValue;
            }

            if (Input.GetKey(KeyCode.S))
            {
                _speed -= _speedChangeValue;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger(ChoseKick());
                _speed = 0;
            }
            _animator.SetFloat(Speed,_speed);
        }

        private int ChoseKick()
        {
            var random = new Random();
            var kick = random.Next(0, 2);

            return kick == 0 ? Kick : Kick2;
        }
    }
}
