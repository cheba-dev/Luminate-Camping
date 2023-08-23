using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuminateCamping.Scripts;

namespace LuminateCamping.Scripts
{

    public class ItemsController : MonoBehaviour
    {
        public LiftingObjects data;
        private Transform _campfire = null;

        private void Update()
        {
            if (_campfire != null)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, _campfire.position, Time.deltaTime * 2f);
                float distanceToCampfire = Vector3.Distance(this.transform.position, _campfire.position);
                if (distanceToCampfire < 0.1f)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_campfire == null)
            {
                IPickable player = other.gameObject.GetComponent<IPickable>();
                player.OnPickable(this.transform, data);
            }
        }

        public void Move(Transform campfire)
        {
            _campfire = campfire;
        }
    }
}
