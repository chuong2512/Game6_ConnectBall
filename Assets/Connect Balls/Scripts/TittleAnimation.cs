using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
    public class TittleAnimation : MonoBehaviour
    {

        private float scale = 1;
        private bool up = false;

        void Update()
        {
            if (up)
            {
                scale += Time.deltaTime / 20;
                if (scale >= 1)
                {
                    up = false;
                }
            }
            else
            {
                scale -= Time.deltaTime / 20;
                if (scale <= 0.95f)
                {
                    up = true;
                }
            }
            transform.localScale = new Vector2(scale, scale);
        }
    }
}
