using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GamePrefs : MonoBehaviour
{
    public delegate void OnCoinsRefresh(int count);
    public static event OnCoinsRefresh OnCoinsRefresgEvent;

    public delegate void OnNoEnought();
    public static event OnNoEnought OnNoEnoughtEvent;

    private static string COINS_KEY = "coins";
    private static string SOUND_KEY = "sound";
    private static string NOADS_KEY = "no_ads";
    private static string BEST_SCORE_KEY = "best_score";
    private static string CURRENT_LEVEL_KEY = "current_level";
    private static string SCULPT_KEY = "sculpt_";
    private static string LevelSaved = "ioptalevel";
    private static string Sound = "Sound";
    private static string Vibrate = "Vibrate";
    private static string CurentPowers = "PlayerPower";
    private static string OfflineEarningsUpgrade = "PlayerOfflineEarnings";
    private static string BayedSkin = "BayedSkin";
    private static string CurentCharacterSkin="CurentCharacterSkin";
    private static string OldLvlGetedSkin="LvlGetedSkin";
    private static string  CurentCamera="CurentCamera";
    public static void SetCurentSkin(int number)
    {
        xPrefs.SetInt(CurentCharacterSkin,number);
    }

    public static bool IsFirstPersonCamera()
    {
        return xPrefs.GetBool(CurentCamera,false);
        
    }
    public static void  SetCameraToFirstPerson(bool isfirst)
    {
         xPrefs.SetBool(CurentCamera,isfirst);
        
    }
    

    public static int GetLvlGetedSkin()
    {
        return xPrefs.GetInt(OldLvlGetedSkin, 0);
    }

    public static void SetLvlGetedSkin(int lvl)
    {
        xPrefs.SetInt(OldLvlGetedSkin,lvl);
    }
    public static int GetCurentSkin()
    {
        return xPrefs.GetInt(CurentCharacterSkin, 0);
    }
    public static bool IsSkinBayed(int index)
    {
        return xPrefs.GetBool(BayedSkin + index.ToString(),false);
    }

    public static void BaySkin(int index)
    {
        xPrefs.SetBool(BayedSkin + index.ToString(),true);
    }
   

    /// <summary>
    /// 
    /// </summary>
    #region Configs
        public static bool GetSound()
    {
        return xPrefs.GetBool(Sound, true);
    }

    public static void SetSound(bool enabled)
    {
        xPrefs.SetBool(Sound, enabled);
    }

    public static bool GetVibrate()
    {
        return xPrefs.GetBool(Vibrate, true);
    }

    public static void SetVibrate(bool enabled)
    {
        xPrefs.SetBool(Vibrate, enabled);
    }

    #endregion 
    #region ADS
    public static void SetNoAds()
    {
        xPrefs.SetBool(NOADS_KEY, true);
    }

    public static bool GetNoAds()
    {
        return xPrefs.GetBool(NOADS_KEY, false);
    }
    #endregion

    #region COINS
    public static int IncreaseCoins(int count)
    {
        var value = xPrefs.GetInt(COINS_KEY);
        value += count;
        xPrefs.SetInt(COINS_KEY, value);
        if (OnCoinsRefresgEvent != null)
        {
            OnCoinsRefresgEvent.Invoke(value);
        }
        PlayerPrefs.Save();
        return value;
    }

    public static int DecreaseCoins(int count)
    {
        var value = xPrefs.GetInt(COINS_KEY);

        if ((value - count) >= 0)
        {
            value -= count;
            xPrefs.SetInt(COINS_KEY, value);
            if (OnCoinsRefresgEvent != null)
            {
                OnCoinsRefresgEvent.Invoke(value);
            }
        }
        else
        {
            Debug.LogWarning("Decrease fail, new value is " + (value -= count));
        }
        PlayerPrefs.Save();
        return value;
    }

    public static bool CheckEnoughCoins(int decrease)
    {
        var value = xPrefs.GetInt(COINS_KEY);
        var enought = (value - decrease) >= 0;
        if (!enought)
        {
          //  OnNoEnoughtEvent.Invoke();
        }
        return enought;
    }

    public static int GetCoins()
    {
        return xPrefs.GetInt(COINS_KEY);
    }
    #endregion


    #region SCPRE
    public static void SetBestScore(int score)
    {
        xPrefs.SetInt(BEST_SCORE_KEY, score);
    }

    public static int GetBestScore()
    {
        return xPrefs.GetInt(BEST_SCORE_KEY, 0);
    }
    #endregion


    #region LEVEL
    public static void SetCurrentLevel(int levelIndex)
    {
        Debug.Log("setedLevel"+levelIndex);
        xPrefs.SetInt(CURRENT_LEVEL_KEY, levelIndex);
    }

    public static int GetCurrentLevel()
    {
        return xPrefs.GetInt(CURRENT_LEVEL_KEY, 0);
    }
    #endregion

    #region Player

    public static void SetCurentPowerUpgrade(int power)
    {
        xPrefs.SetInt(CurentPowers,power);
    }
    public static int GetCurentPowerUpgrade()
    {
     return    xPrefs.GetInt(CurentPowers,0);
    }

    public static void IncresePowerUpgrade()
    {
        xPrefs.SetInt(CurentPowers,GetCurentPowerUpgrade()+1);
    }

    public static void IncreseOfflineEarnings()
    {
        xPrefs.SetInt(OfflineEarningsUpgrade, GetOfflineEarnings() + 1);
    }

    public static int  GetOfflineEarnings()
    {
      return  xPrefs.GetInt(OfflineEarningsUpgrade,0);
    }

    #endregion

}
