using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    [SerializeField] private GameObject car;

    private void Awake()
    {
        Instantiate(car);
    }
}
