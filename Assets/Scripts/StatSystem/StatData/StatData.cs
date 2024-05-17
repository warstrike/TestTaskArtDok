using System.Collections;
using System.Collections.Generic;
using StatsSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace StatsSystem
{


   [CreateAssetMenu(fileName = "Stat", menuName = "Data/Stats")]
   public class StatData : ScriptableObject
   {
      public List<Stat> Stats = new List<Stat>();


      public void Save()
      {
#if UNITY_EDITOR
         EditorUtility.SetDirty(this);
         AssetDatabase.SaveAssets();
         AssetDatabase.Refresh();
#endif
      }
   }
}
