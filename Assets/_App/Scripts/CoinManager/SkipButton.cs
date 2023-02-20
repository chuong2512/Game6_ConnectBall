using System.Collections;
using System.Collections.Generic;
using ConnectBalls;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public void OnPressDown()
    {
        Menus.Instance.NextLevel();
    }
}