using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ConnectBalls
{
	public class UnlockLevel : MonoBehaviour
	{

		void OnEnable()
		{
			int gameLevel = Int32.Parse(this.gameObject.name);

			if (PlayerPrefs.GetInt("levelUnlock") >= gameLevel)
			{
				this.transform.Find("Lock").gameObject.SetActive(false);
				this.transform.Find("Text").gameObject.SetActive(true);
				GetComponent<Button>().interactable = true;
			}
			else
			{
				this.transform.Find("Lock").gameObject.SetActive(true);
				this.transform.Find("Text").gameObject.SetActive(false);
				GetComponent<Button>().interactable = false;
			}
		}
	}
}
