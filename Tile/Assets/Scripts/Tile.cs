using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _defaultColor = Color.white;
    [SerializeField] private Color _defeatColor = Color.red;
    [SerializeField] private Color _acceptColor = Color.green;

    private List<Material> _materialsPrefab = new List<Material>();

    private void Awake()
    {
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in renderers)
        {
            _materialsPrefab.Add(meshRenderer.material);
        }
        
    }


    public void SetColor(bool isAvailable)
    {
        if (isAvailable)
        {
            foreach (var material in _materialsPrefab)
            {
                material.color = _acceptColor;
            }
        }
        else
        {
            foreach (var material in _materialsPrefab)
            {
                material.color = _defeatColor;
            }
        }
    }

    public void ResetColor()
    {
        foreach (var material in _materialsPrefab)
        {
            material.color = _defaultColor;
        }
    }
}
