using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConnectBalls
{
    public class LevelPanel : MonoBehaviour
    {

        public GameObject[] levelPanels;
        public GameObject[] levelIndicators;
        public GameObject previousButton;
        public GameObject nextButton;
        private int currentPanel = 0;

        private AudioSource buttonSound;

        void Start()
        {
            buttonSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        }

        public void NextPanel()
        {
            buttonSound.Play();
            DeactivateAllPanels();
            DeactivateAllLevelIndicators();
            if (currentPanel == (levelPanels.Length - 2))
            {
                nextButton.SetActive(false);
            }
            currentPanel++;
            levelPanels[currentPanel].SetActive(true);
            levelIndicators[currentPanel].SetActive(true);
            previousButton.SetActive(true);
        }

        public void PreviousPanel()
        {
            buttonSound.Play();
            DeactivateAllPanels();
            DeactivateAllLevelIndicators();
            if (currentPanel == 1)
            {
                previousButton.SetActive(false);
            }
            currentPanel--;
            levelPanels[currentPanel].SetActive(true);
            levelIndicators[currentPanel].SetActive(true);
            nextButton.SetActive(true);
        }

        private void DeactivateAllPanels()
        {
            foreach (GameObject panel in levelPanels)
            {
                panel.SetActive(false);
            }
        }

        private void DeactivateAllLevelIndicators()
        {
            foreach (GameObject levelIndicator in levelIndicators)
            {
                levelIndicator.SetActive(false);
            }
        }
    }
}
