using UnityEngine;

namespace LineDrawing
{
    public class LineDrawer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _lineWidth = 0.01f;

        private Camera _mainCamera;
        private bool _isButtonPressed;
        private int _positionsCount;

        private void Start()
        {
            _mainCamera = Camera.main;
            _lineRenderer.startWidth = _lineRenderer.endWidth = _lineWidth;

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartDrawing();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                StopDrawing();
            }

            if (_isButtonPressed)
            {
                var mousePosition = GetMousePosition();
                AddPositionToLine(mousePosition);
                
            }
        }

        private void StartDrawing()
        {
            _isButtonPressed = true;
            ResetLine();
        }

        private void StopDrawing()
        {
            _isButtonPressed = false;
            _positionsCount = 0;
        }

        private void AddPositionToLine(Vector3 newPosition)
        {
            if (_positionsCount == 0)
            {
                _lineRenderer.positionCount = 1;
                _lineRenderer.SetPosition(0, newPosition);
            }
            else
            {
                _lineRenderer.positionCount = _positionsCount + 1;
                _lineRenderer.SetPosition(_positionsCount, newPosition);
            }

            _positionsCount++;
        }

        private void ResetLine()
        {
            _lineRenderer.positionCount = 0;
        }

        private Vector3 GetMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            return _mainCamera.ScreenToWorldPoint(mousePos);
        }
    }
}

