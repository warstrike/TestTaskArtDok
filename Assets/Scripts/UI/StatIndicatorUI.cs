using System;
using System.Collections;
using System.Collections.Generic;
using StatsSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatIndicatorUI : MonoBehaviour
{
   public Button MinusButton;
   public Button AddButton;
   public Image  FillImg;
   public TextMeshProUGUI TextValue;
   public TextMeshProUGUI TextName;
   public float ChangeValue;
   private Stat curentTrackedStat;
   
   public void Set(Stat trackedStat)
   {
      curentTrackedStat = trackedStat;
      Init();
   }

   public void Init()
   {
     
      curentTrackedStat.OnResultValueChanged += Refresh;
      MinusButton.onClick.AddListener(SubButtonClick);
      AddButton.onClick.AddListener(AddButtonClick);
      Refresh();
   }

   private void AddButtonClick()
   {
      curentTrackedStat.AddAndSaveBaseValue(ChangeValue);
   }
   private void SubButtonClick()
   {
      curentTrackedStat.AddAndSaveBaseValue(-ChangeValue);
   }
   private void OnDestroy()
   {
      if (curentTrackedStat != null)
      {
         if (curentTrackedStat.OnResultValueChanged != null) curentTrackedStat.OnResultValueChanged -= Refresh;
         
         
      }
   }
   

  

   public void Refresh()
   {
      if (TextName)
      {
         TextName.text=curentTrackedStat.Type.ToString();
      }
      if (TextValue)
      {
       
         TextValue.text =Math.Round(curentTrackedStat.GetValue(),2).ToString();
      }
      RefreshFill();
   }

   private void RefreshFill()
   {
      if (FillImg)
         FillImg.fillAmount = Mathf.InverseLerp(curentTrackedStat.GetMinValue(), curentTrackedStat.GetMaxValue(),
            curentTrackedStat.GetValue());
   }
}
