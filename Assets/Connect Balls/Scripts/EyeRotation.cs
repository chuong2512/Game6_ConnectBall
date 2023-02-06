using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
    public class EyeRotation : MonoBehaviour
    {
        public GameObject otherBall;
        private Transform ball;

        void Start()
        {
            ball = transform.parent;
        }

        void Update()
        {
            if (otherBall == null) return;
            float px = transform.position.x - otherBall.transform.position.x;
            float py = transform.position.y - otherBall.transform.position.y;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(-py, -px));
        }
    }
}
