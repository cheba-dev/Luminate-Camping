using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LuminateCamping.Player
{
    public class CameraController : MonoBehaviour
    {
        public Transform player = null;
        public float moveSpeed;
        public Vector3 offset;
        public float followDistance;
        public Quaternion rotation;
        public float teleportDistanceThreshold = 100f;

        void Update()
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            else
            {
                if (Vector3.Distance(transform.position, player.position) > teleportDistanceThreshold)
                {
                    transform.position = player.position + offset + -transform.forward * followDistance;
                }
                else
                {
                    Vector3 pos = Vector3.Lerp(transform.position, player.position + offset + -transform.forward * followDistance, moveSpeed * Time.deltaTime);
                    transform.position = pos;
                }
                transform.rotation = rotation;
            }
        }
    }
}
