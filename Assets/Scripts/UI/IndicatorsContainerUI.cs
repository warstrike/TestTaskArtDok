using System.Collections;
using System.Collections.Generic;
using StatsSystem;
using UnityEngine;

public class IndicatorsContainerUI : MonoBehaviour
{
    public CharStatContainer ContainerStat;
    public GameObject PrefabIndicator;
    public GameObject ContainerPrefab;
    void Start()
    {
        Init();
    }

    public void Init()
    {
        foreach (var stat in ContainerStat.Stats)
        {
          var gmjs=  Instantiate(PrefabIndicator, ContainerPrefab.transform);
          var indicator=gmjs.GetComponent<StatIndicatorUI>();
          indicator.Set(stat);
          
        }
    }

    
}
