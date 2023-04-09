using System;
using DanPie.Framework.Extensions;
using DanPie.Framework.UnityExtensions;
using UnityEngine;

namespace FlatVillage.Controls
{
    public class MapMoveActionsProvider : MonoBehaviour
    {
        [SerializeField] private float _deadZone = 0.1f; 
        [SerializeField] private float _mouseScrollForce = 8f; 

        private Vector2 _dragStartPos;
        private Vector2 _lastDragPos;
        private bool _isDragging = false;
        private Vector2Int _screenSize;
        private Camera _camera;
        private Transform _cameraTransform;
        private float _pinchingDistance;
        private bool _isPinching;
        private int _previousTouchesCount;
        private Vector2 _lastActionScreenPoint;
        private int[] _ignoreUILayers;
        private bool _isStartedOnUI;

        public event Action<Vector2> Clicked;
        public event Action<Vector2> Moved;
        public event Action<float> Zoom;

        public Vector2 LastActionScreenPoint { get => _lastActionScreenPoint; }

        protected void Start()
        {
            _screenSize = new Vector2Int(Screen.width, Screen.height);
            _camera = Camera.main;
            _cameraTransform = _camera.transform;
            var ingoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            _ignoreUILayers = new int[] { ingoreRaycast };
        }

        protected void Update()
        {
#if UNITY_EDITOR
            float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(zoomDelta) > 0.01f)
            {
                _lastActionScreenPoint = Input.mousePosition;
                Zoom?.Invoke(-zoomDelta * _mouseScrollForce * _camera.orthographicSize);
            }
#else
            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                _lastActionScreenPoint = Vector3.Lerp(touch0.position, touch1.position, 0.5f);

                float GetPinchingDistance()
                    => Vector2.Distance(GetWorldPos(touch0.position), GetWorldPos(touch1.position));

                if ((touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began) && !_isPinching)
                {
                    _pinchingDistance = GetPinchingDistance();
                    _isPinching = true;
                }

                if (_isPinching)
                {
                    var newDistance = GetPinchingDistance();
                    float pinchAmount = (newDistance - _pinchingDistance);
                    if (!IsPointerHitUI(touch0.position) && !IsPointerHitUI(touch1.position))
                    {
                        Zoom?.Invoke(-pinchAmount);
                    }
                    _pinchingDistance = GetPinchingDistance();
                }

                if (touch0.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Ended ||
                    touch0.phase == TouchPhase.Canceled || touch1.phase == TouchPhase.Canceled)
                {
                    _isPinching = false;
                }
                _previousTouchesCount = Input.touchCount;
                return;
            }      
#endif
            if (Input.GetMouseButtonDown(0) && IsPointerHitUI(Input.mousePosition))
            {
                _isStartedOnUI = true;
            }

            if (Input.GetMouseButtonDown(0) && !IsPointerHitUI(Input.mousePosition))
            {
                _isStartedOnUI = false;
            }

            if (!_isStartedOnUI)
            {
                
                if (Input.GetMouseButtonDown(0) || _previousTouchesCount > 1)
                {
                    _previousTouchesCount = Input.touchCount;
                    _dragStartPos = GetRelativeMousePosition();
                    _lastDragPos = GetWorldPos();
                }
                else if (Input.GetMouseButton(0) && (GetDistance() > _deadZone || _isDragging))
                {
                    if (!_isDragging)
                    {
                        _isDragging = true;
                        _lastDragPos = GetWorldPos();
                    }

                    Vector2 dragPos = GetWorldPos();
                    Vector2 delta = (_lastDragPos - dragPos);
                    _lastActionScreenPoint = Input.mousePosition;
                    Moved?.Invoke(delta);
                    _lastDragPos = GetWorldPos();
                }
                else if (Input.GetMouseButtonUp(0) && !_isDragging)
                {
                    _lastActionScreenPoint = Input.mousePosition;
                    Clicked?.Invoke(GetWorldPos());
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    _isDragging = false;
                }
            }
        }

        private float GetDistance()
        {
            Vector2 relativePos = GetRelativeMousePosition();
            float distance = Vector2.Distance(_dragStartPos, relativePos);
            return distance;
        }

        private bool IsPointerHitUI(Vector3 pointer)
        {
            return _camera.IsPointerHitUI(pointer, _ignoreUILayers);
        }

        private Vector2 GetRelativeMousePosition()
        {
            Vector2 clickPos = Input.mousePosition;
            return new Vector2(clickPos.x / _screenSize.x, clickPos.y / _screenSize.y);
        }

        private Vector2 GetWorldPos()
            => _camera.GetWorldPosOnPlane(Input.mousePosition);

        private Vector2 GetWorldPos(Vector3 screenPoint)
           => _camera.GetWorldPosOnPlane(screenPoint);
    }
}
