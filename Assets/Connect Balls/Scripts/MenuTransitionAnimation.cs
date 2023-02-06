using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ConnectBalls
{
    public class MenuTransitionAnimation : MonoBehaviour
    {

        public int menu = 0;
        public Image image;
        private bool up = true;
        private float alpha = 0;

        void Update()
        {
            if (up)
            {
                alpha += Time.deltaTime * 3;
                if (alpha >= 1f)
                {
                    up = false;

                    if (menu == 0)
                    {
                        GetComponent<Menus>().ShowMainMenu();
                    }
                    else if (menu == 1)
                    {
                        GetComponent<Menus>().ShowLevelSelectMenu();
                    }
                    else if (menu == 2)
                    {
                        GetComponent<Menus>().ShowStatsMenu();
                    }
                    else if (menu == 3)
                    {
                        GetComponent<Menus>().ShowOptionsMenu();
                    }
                }
            }
            else
            {
                alpha -= Time.deltaTime * 3;
                if (alpha <= 0)
                {
                    up = true;
                    alpha = 0;
                    image.color = new Color(0, 0, 0, 0);
                    GetComponent<MenuTransitionAnimation>().enabled = false;
                }
            }
            image.color = new Color(0, 0, 0, alpha);
        }
    }
}
