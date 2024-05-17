using System;
using UnityEngine;

namespace StatsSystem
{
      [System.Serializable] 
    public class StatDependences 
    {
        public   StatsType Type;
        public float ModificatorValue;
        [NonSerialized]   private Stat baseStat;

        public void Init(Stat _bStat)
        {
            baseStat = _bStat;
        }

        public float GetDependResult()
        {
            return baseStat.GetValue() * ModificatorValue;
        }
        
        
        
    }
}
