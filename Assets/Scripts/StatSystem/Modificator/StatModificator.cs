using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatsSystem
{
    public class  StatModificator
    {
        public float Value;
        public OperationType Type;
        public virtual float GetModValued(float baseValue)
        {
            float resultValue = Value;
            if (Type == OperationType.Percent)
            {
                resultValue = (baseValue * Value) / 100f;
            }
            return resultValue;
        }
        [System.Serializable]
        public enum OperationType
        {
            Add,Percent
        }
    }
}

