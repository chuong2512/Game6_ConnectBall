using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondDisplay : MonoBehaviour
{
   public TextMeshProUGUI diamondTmp;

   void OnValidated()
   {
      diamondTmp = GetComponent<TextMeshProUGUI>();
   }

   void Start()
   {
      GameDataManager.Instance.playerData.onChangeDiamond += i => OnChangeDiamond(i);
      diamondTmp.text = $"{GameDataManager.Instance.playerData.intDiamond}";
   }
   
   void OnDestroy()
   {
      GameDataManager.Instance.playerData.onChangeDiamond -= i => OnChangeDiamond(i);
   }

   private void OnChangeDiamond(int i)
   {
      diamondTmp.text = $"{i}";
   }
}
