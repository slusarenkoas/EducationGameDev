using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Vector2Int _sizeMap;
    private Tile[,] _tilesOnMap;

    private void Awake()
    {
        _tilesOnMap = new Tile[_sizeMap.x, _sizeMap.y];
    }

    public bool _isCellFreeAndWorking(Vector3Int index)
    {
        var isCellNotOnGridPosition = index.x < 0 || index.z < 0 || index.x >= _tilesOnMap.GetLength(0) ||
                                   index.z >= _tilesOnMap.GetLength(1);

        if (isCellNotOnGridPosition)
        {
            Debug.Log("@#");
            return false;
        }

        var isFreePlace = _tilesOnMap[index.x, index.z] == null;
        return isFreePlace;
    }
    
    public void SetTile(Vector3Int index, Tile tile)
    {
        _tilesOnMap[index.x, index.z] = tile;
    }
}
