using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuminateCamping.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
            _rigidbody.velocity = movement * speed;

            if (movement == new Vector3(0f, 0f, 0f))
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
    }
}