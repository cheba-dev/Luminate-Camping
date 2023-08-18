using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuminateCamping.Scripts
{
    public class CampfireHealth : MonoBehaviour
    {
        public float fireHealth = 10f;
        private bool _gameOver;
        void Update()
        {
            if (!_gameOver)
            {
                fireHealth -= Time.deltaTime;

                if (fireHealth <= 0)
                {
                    _gameOver = true;
                    fireHealth = 0f;
                    Debug.Log("Game Over!");
                }
            }
        }
    }
}
