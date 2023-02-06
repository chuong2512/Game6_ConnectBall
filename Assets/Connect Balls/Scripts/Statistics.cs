using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ConnectBalls
{
    public class Statistics : MonoBehaviour
    {

        public Text completedLevels;
        public Text playedGames;
        public Text numberOfJumps;
        public Text playtime;

        void OnEnable()
        {
            if (PlayerPrefs.GetInt("levelUnlock") == 0) PlayerPrefs.SetInt("levelUnlock", 1);
            completedLevels.text = "COMPLETED LEVELS " + (PlayerPrefs.GetInt("levelUnlock") - 1) + "/60";
            playedGames.text = "PLAYED GAMES " + PlayerPrefs.GetInt("PlayedGames");
            numberOfJumps.text = "NUMBER OF FAILS " + PlayerPrefs.GetInt("NumberOfFails");

            TimeSpan t = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("playtime"));
            string playtimeCalc = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                    t.Hours,
                    t.Minutes,
                    t.Seconds);
            playtime.text = "PLAYTIME: " + playtimeCalc;
        }
    }
}
