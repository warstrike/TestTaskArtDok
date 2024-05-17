using System;
using System.Collections;
using System.Collections.Generic;
using StatsSystem;
using UnityEngine;

public class CharStatContainer : MonoBehaviour
{
   public List<Stat> Stats=new List<Stat>();
   public StatData Data;

   private void Awake()
   {
      Init();
   }

   private void Init()
   {
      Stats = Data.Stats;
      InitStats();
   }

   [EasyButtons.Button]
   public void SaveStats()
   {
      Data.Save();
   }
   private void InitStats()
   {
      foreach (var stat in Stats)
      {
         stat.Init(this);
      }
   }
   public Stat GetStat(StatsType typeStat)
   {
      return Stats.Find(stat => stat.Type == typeStat);
   }
   
}
