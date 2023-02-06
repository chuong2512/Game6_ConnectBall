using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ConnectBalls
{
    public class Tutorial : MonoBehaviour
    {

        [SerializeField]
        private TextMesh tutorialText;
        private float tutorialAlpha = 1;
        private bool destroyTutorialGameObject = false;
        void Update()
        {

            if (Input.GetMouseButtonDown(0)) destroyTutorialGameObject = true;
            if (destroyTutorialGameObject)
            {
                tutorialAlpha -= Time.deltaTime * 3;
                tutorialText.color = new Color(1, 1, 1, tutorialAlpha);
                if (tutorialAlpha <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
