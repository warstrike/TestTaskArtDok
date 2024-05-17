

using System;
using System.Collections.Generic;
using UnityEngine;

namespace StatsSystem
{
    [System.Serializable] 
    public class Stat 
    {
        public StatsType Type;
      [SerializeField]  private float BaseValue;
      [SerializeField] private float maxValue;
      [SerializeField] private float minValue;
        public Action OnBaseValueChanged;
        public Action OnValueRefreshed;
        public Action OnResultValueChanged;
        private  float ResultValue;
        private CharStatContainer _charStatContainer;
        [SerializeField]   private List<StatDependences> Dependences=new List<StatDependences>();
        private List<StatModificator> Modificators=new List<StatModificator>();
        
        public void Init(CharStatContainer container)
        {
            _charStatContainer = container;
            foreach (var statDependencese in Dependences)
            {
                var neededStat = _charStatContainer.GetStat(statDependencese.Type);
                if (neededStat != null)
                {
                    statDependencese.Init(neededStat);
                    neededStat.OnResultValueChanged += RefreshValue;
                }
            }

            RefreshValue();
        }
        
        
         public void SetBaseValue(float newValue)
          {
              
          BaseValue = newValue;
          OnBaseValueChanged?.Invoke();
          RefreshValue();

          }

         public void AddAndSaveBaseValue(float addValue)
         {
             BaseValue += addValue;
             BaseValue = Mathf.Clamp(BaseValue, minValue, maxValue);
             _charStatContainer.SaveStats();
             OnBaseValueChanged?.Invoke();
             RefreshValue();
            
         }

         public float GetMinValue()
         {
             return minValue;
         }
         public float GetMaxValue()
         {
             return maxValue;
         }
         public float GetBaseValue()
         {
             return BaseValue;
         }
        public float GetValue()
        {
          
            return ResultValue;
            
        }

        

        public void RefreshValue()
        {
           
            ResultValue = BaseValue;
            foreach (var dep in Dependences)
            {
                ResultValue += dep.GetDependResult();
            }
            foreach (var statModificator in Modificators)
            {
                ResultValue += statModificator.GetModValued(BaseValue);
            }

            ResultValue = Mathf.Clamp(ResultValue, minValue, maxValue);
            OnResultValueChanged?.Invoke();
            OnValueRefreshed?.Invoke();
        }

        public void AddModificator(StatModificator newModificator)
        {
            Modificators.Add(newModificator);
            RefreshValue();
        }
        public bool TryRemoveModificator(StatModificator mod)
        {
           var resultMod= Modificators.Find(modificator => modificator == mod);
           if (resultMod != null)
           {
             var result=  Modificators.Remove(resultMod);
             if (!result) return false;
           }
           else
           {
               return false;
           }
            RefreshValue();
            return true;
        }

       
       
    }
}
