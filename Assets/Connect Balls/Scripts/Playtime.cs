using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
	public class Playtime : MonoBehaviour
	{

		public void Awake()
		{
			DontDestroyOnLoad(this);
			if (FindObjectsOfType(GetType()).Length > 1)
			{
				Destroy(gameObject);
			}
		}

		void Update()
		{
			PlayerPrefs.SetFloat("playtime", PlayerPrefs.GetFloat("playtime") + Time.deltaTime);
		}
	}
}
