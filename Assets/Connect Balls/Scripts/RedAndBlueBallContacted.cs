using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
    public class RedAndBlueBallContacted : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name.Equals("BlueBall"))
            {
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(col.gameObject.GetComponent<Rigidbody2D>());
                GameObject loveParticleRed = transform.Find("LoveParticle").gameObject;
                GameObject loveParticleBlue = col.gameObject.transform.Find("LoveParticle").gameObject;
                loveParticleRed.SetActive(true);
                loveParticleRed.transform.rotation = Quaternion.Euler(-90, 0, 0);
                loveParticleBlue.SetActive(true);
                loveParticleBlue.transform.rotation = Quaternion.Euler(-90, 0, 0);
                GameObject.Find("Level").GetComponent<LevelRotate>().enabled = false;
                GameObject.Find("GameManager").GetComponent<Menus>().LevelComplete();
            }
        }
    }
}
