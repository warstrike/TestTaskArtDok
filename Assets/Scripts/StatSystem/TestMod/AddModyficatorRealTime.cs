using System.Collections;
using System.Collections.Generic;
using StatsSystem;
using UnityEngine;

public class AddModyficatorRealTime : MonoBehaviour
{
    public CharStatContainer StatContainer;
    public StatsType TypeStat;
    public StatModificator.OperationType TypeMod;
    public float Value=10;
    
    void Start()
    {
        
    }

    [EasyButtons.Button]
    public void Add()
    {
      var stat=  StatContainer.GetStat(TypeStat);
      var mod=new StatModificator();
      mod.Type = TypeMod;
      mod.Value = Value;
      stat.AddModificator(mod);
    }
}
