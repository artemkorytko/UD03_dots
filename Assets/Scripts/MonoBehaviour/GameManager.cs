using System;
using UnityEngine;

namespace Mono
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        public bool WasStartClick;

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

        public void StartMoveButtonClick()
        {
            WasStartClick = true;
        }
    }
}