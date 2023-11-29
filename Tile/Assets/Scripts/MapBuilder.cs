using System;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    /// <summary>
    /// Данный метод вызывается автоматически при клике на кнопки с изображениями тайлов.
    /// В качестве параметра передается префаб тайла, изображенный на кнопке.
    /// Вы можете использовать префаб tilePrefab внутри данного метода.
    /// </summary>
    [SerializeField] private Grid _grid;
    [SerializeField] private Map _map;

    private Camera _camera;
    private Tile _currentTile;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void StartPlacingTile(Tile tilePrefab)
    {
        _currentTile = Instantiate(tilePrefab, _map.transform);
    }

    private void Update()
    {
        if (_currentTile == null)
        {
            return;
        }

        var mousePosition = Input.mousePosition;
        var ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var worldPosition = hitInfo.point;

            var cellPosition = _grid.WorldToCell(worldPosition);
            var cellCenterWorld = _grid.GetCellCenterWorld(cellPosition);

            _currentTile.transform.position = cellCenterWorld;

            var isAvailable = _map._isCellFreeAndWorking(cellPosition);
            _currentTile.SetColor(isAvailable);
            
            if (!isAvailable)
            {
                
                return;
            }
            Debug.Log(isAvailable);
            if (Input.GetMouseButtonDown(0) && isAvailable)
            {
                _map.SetTile(cellPosition,_currentTile);
                _currentTile.ResetColor();
                _currentTile = null;
            }
        }
        
        
    }
    
}