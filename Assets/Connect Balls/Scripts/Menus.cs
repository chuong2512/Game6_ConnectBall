using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace ConnectBalls
{
	public class Menus : MonoBehaviour
	{

		public GameObject pauseUI;
		public GameObject levelSelectUI;
		public GameObject mainMenuUI;
		public GameObject statsMenuUI;
		public GameObject optionsMenuUI;
		public GameObject resetDataConfirmationDialog;
		public GameObject soundOnOffText;

		private AudioSource buttonSound;

		void Start()
		{
			Application.targetFrameRate = 300;
			buttonSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
		}

		public void MainMenu()
		{
			buttonSound.Play();
			Time.timeScale = 1;
			Invoke("LoadMainMenuScene", 0.2f);
		}

		private void LoadMainMenuScene()
		{
			SceneManager.LoadScene("MainMenu");
		}

		public void MainMenuUI()
		{
			buttonSound.Play();
			GetComponent<MenuTransitionAnimation>().enabled = true;
			GetComponent<MenuTransitionAnimation>().menu = 0;
		}

		public void LevelSelectMenu()
		{
			buttonSound.Play();
			GetComponent<MenuTransitionAnimation>().enabled = true;
			GetComponent<MenuTransitionAnimation>().menu = 1;
		}

		public void StatsMenuUI()
		{
			buttonSound.Play();
			GetComponent<MenuTransitionAnimation>().enabled = true;
			GetComponent<MenuTransitionAnimation>().menu = 2;
		}

		public void OptionsMenuUI()
		{
			buttonSound.Play();
			GetComponent<MenuTransitionAnimation>().enabled = true;
			GetComponent<MenuTransitionAnimation>().menu = 3;
		}

		public void ShowOptionsMenu()
		{
			optionsMenuUI.SetActive(true);
			mainMenuUI.SetActive(false);
			if (AudioListener.volume == 1)
			{
				soundOnOffText.GetComponent<Text>().text = "SOUND ON";
			}
			else
			{
				soundOnOffText.GetComponent<Text>().text = "SOUND OFF";
			}
		}

		public void SoundOnOff()
		{
			if (AudioListener.volume == 1)
			{
				AudioListener.volume = 0;
				soundOnOffText.GetComponent<Text>().text = "SOUND OFF";
			}
			else
			{
				AudioListener.volume = 1;
				soundOnOffText.GetComponent<Text>().text = "SOUND ON";
			}
			buttonSound.Play();
		}

		public void ShowStatsMenu()
		{
			statsMenuUI.SetActive(true);
			mainMenuUI.SetActive(false);
		}

		public void ShowMainMenu()
		{
			mainMenuUI.SetActive(true);
			levelSelectUI.SetActive(false);
			statsMenuUI.SetActive(false);
			optionsMenuUI.SetActive(false);
		}

		public void ShowLevelSelectMenu()
		{
			levelSelectUI.SetActive(true);
			mainMenuUI.SetActive(false);
		}

		public void ShowResetDataConfirmationDialog()
		{
			buttonSound.Play();
			resetDataConfirmationDialog.SetActive(true);
		}

		public void HideResetDataConfirmationDialog()
		{
			buttonSound.Play();
			resetDataConfirmationDialog.SetActive(false);
		}

		public void ResetAllData()
		{
			buttonSound.Play();
			PlayerPrefs.DeleteAll();
			resetDataConfirmationDialog.SetActive(false);
		}


		public void LevelSelect()
		{
			buttonSound.Play();
			PlayerPrefs.SetInt("PlayedGames", PlayerPrefs.GetInt("PlayedGames") + 1);
			SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
		}

		public void Restart()
		{
			buttonSound.Play();
			Time.timeScale = 1;
			Invoke("LevelRestart", 0.3f);
		}

		public void GameOver()
		{
			Invoke("ShowGameOverUI", 1f);
		}

		private void ShowGameOverUI()
		{
			RectTransform gameOverRectTransform = GameObject.Find("GameOverUI").GetComponent<RectTransform>();
			if (gameOverRectTransform.localScale.x < 1)
			{
				PlayerPrefs.SetInt("NumberOfFails", PlayerPrefs.GetInt("NumberOfFails") + 1);
				gameOverRectTransform.localScale = new Vector2(1, 1);
			}
		}

		public void LevelComplete()
		{
			int levelNumber = Int32.Parse(SceneManager.GetActiveScene().name);
			if (levelNumber >= PlayerPrefs.GetInt("levelUnlock"))
			{
				PlayerPrefs.SetInt("levelUnlock", (levelNumber + 1));
			}

			Invoke("ShowLevelCompleteUI", 1f);
			GameObject.Find("LevelEndSound").GetComponent<AudioSource>().Play();
		}

		private void ShowLevelCompleteUI()
		{
			GameObject.Find("LevelEndUI").transform.localScale = new Vector2(1, 1);
		}

		private void LevelRestart()
		{
			PlayerPrefs.SetInt("PlayedGames", PlayerPrefs.GetInt("PlayedGames") + 1);
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void Pause()
		{
			buttonSound.Play();
			Time.timeScale = 0;
			pauseUI.SetActive(true);
		}

		public void Continue()
		{
			buttonSound.Play();
			Time.timeScale = 1;
			pauseUI.SetActive(false);
		}

		public void NextLevel()
		{
			buttonSound.Play();
			Time.timeScale = 1;
			Invoke("LoadNextLevel", 0.3f);
		}

		private void LoadNextLevel()
		{
			int level = Int32.Parse(SceneManager.GetActiveScene().name);
			level++;
			SceneManager.LoadScene(level.ToString());
		}

		public void ExitTheGame()
		{
			buttonSound.Play();
			Application.Quit();
		}
	}
}
