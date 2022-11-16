using System;
using Unity.Mathematics;
using UnityEngine;

namespace Mono
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public bool WasStartClick;
        private Joystick _joystick;
        public float2 Direction { get; private set; }
        public float DirectionMagnitude => new Vector2(Direction.x, Direction.y).magnitude;
        public bool IsHasDirection => DirectionMagnitude != 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private void Start()
        {
            _joystick = FindObjectOfType<Joystick>(true);
        }

        private void Update()
        {
            if (_joystick)
            {
                Direction = _joystick.Direction;
            }
        }

        public void StartMoveButtonClick()
        {
            WasStartClick = true;
        }
    }
}