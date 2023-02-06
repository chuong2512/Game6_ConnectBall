using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
	public class Sound : MonoBehaviour
	{
		public void Awake()
		{
			DontDestroyOnLoad(this);
			if (FindObjectsOfType(GetType()).Length > 1)
			{
				Destroy(gameObject);
			}
		}
	}
}
