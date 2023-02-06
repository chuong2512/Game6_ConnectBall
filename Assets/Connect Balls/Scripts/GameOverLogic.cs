using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
	public class GameOverLogic : MonoBehaviour
	{

		[SerializeField]
		private Sprite sadBall;

		void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.gameObject.name.Contains("Ball")) return;
			GameObject.Find("ExplosionSound").GetComponent<AudioSource>().Play();
			GameObject.Find("GameManager").GetComponent<Menus>().GameOver();
			GameObject.Find("Level").GetComponent<LevelRotate>().enabled = false;
			Transform explosion = col.transform.Find("Explosion");
			explosion.parent = null;
			explosion.gameObject.SetActive(true);
			Destroy(col.gameObject);
			if (col.gameObject.name.Equals("RedBall"))
			{
				if (GameObject.Find("BlueBall") != null)
					GameObject.Find("BlueBall").GetComponent<SpriteRenderer>().sprite = sadBall;
			}
			else
			{
				if (GameObject.Find("RedBall") != null)
					GameObject.Find("RedBall").GetComponent<SpriteRenderer>().sprite = sadBall;
			}
		}
	}
}
