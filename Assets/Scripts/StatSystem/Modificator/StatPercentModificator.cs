using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatsSystem
{
    public class StatPercentModificator : StatModificator
    {
        public override float GetModValued(float baseValue)
        {
            return (baseValue * Value)/100f;
        }
    }
}
