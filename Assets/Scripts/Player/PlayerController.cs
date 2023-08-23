using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuminateCamping.Scripts;
using UnityEditor;
using System;

namespace LuminateCamping.Player
{
    public class PlayerController : MonoBehaviour, IPickable
    {
        public float speed = 5f;
        private Transform _campfire;
        private Rigidbody _rigidbody;
        private PickedItem _pickedItem = null;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _campfire = GameObject.FindGameObjectWithTag("Campfire").transform;
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

            if(_pickedItem != null)
            {
                if(Vector3.Distance(_pickedItem.transform.position, _campfire.position) <= 5f)
                {
                    _campfire.gameObject.GetComponent<CampfireHealth>().fireHealth += _pickedItem.data.addFireTime;
                    _pickedItem.transform.SetParent(null);
                    speed = 5f;
                    _pickedItem.transform.gameObject.GetComponent<ItemsController>().Move(_campfire);
                    _pickedItem = null;
                }
            }
        }

        public void OnPickable(Transform parent, LiftingObjects data)
        {
            if(_pickedItem == null)
            {
                parent.SetParent(this.transform);
                parent.localPosition = new Vector3(0, 2f, 0);
                PickedItem item = new PickedItem();
                item.transform = parent;
                item.data = data;
                _pickedItem = item;
                speed += data.addCharacterSpeed;
            }
        }
    }

    [Serializable]
    public class PickedItem
    {
        public Transform transform;
        public LiftingObjects data;
    }
}