using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerModel
{
    private string playerName;
    private int lev;
    private int money;
    private int gem;
    private int power;

    private int hp;
    private int atk;
    private int def;
    private int crit;
    private int miss;
    private int luck;

    //通过事件与外部建立联系而不是直接操纵UI
    private event UnityAction<PlayerModel> updateEvent;

    private static PlayerModel data = null;
    public static PlayerModel Data
    {
        get
        {
            if (data == null)
            {
                data = new PlayerModel();
                data.Init();
            }
            return data;
        }
    }

    public string PlayerName { get => playerName;}
    public int Lev { get => lev; }
    public int Money { get => money; }
    public int Gem { get => gem;  }
    public int Power { get => power;  }
    public int Hp { get => hp;}
    public int Atk { get => atk;}
    public int Def { get => def; }
    public int Crit { get => crit;}
    public int Miss { get => miss; }
    public int Luck { get => luck; }

    public void Init()
    {
        playerName = PlayerPrefs.GetString("PlayerName", "Limoyu");
        lev = PlayerPrefs.GetInt("PlayerLev", 1);
        money = PlayerPrefs.GetInt("PlayerMoney", 9999);
        gem = PlayerPrefs.GetInt("PlayerGem", 8888);
        power = PlayerPrefs.GetInt("PlayerPower", 99);

        hp = PlayerPrefs.GetInt("PlayerHp", 100);
        atk = PlayerPrefs.GetInt("PlayerAtk", 100);
        def = PlayerPrefs.GetInt("PlayerDef", 100);
        crit = PlayerPrefs.GetInt("PlayerCrit", 100);
        miss = PlayerPrefs.GetInt("PlayerMiss", 100);
        luck = PlayerPrefs.GetInt("PlayerLuck", 100);

        SaveData();
    }

    public void LevUp()
    {
        lev += 1;
        hp += Lev;
        atk += Lev;
        def += Lev;
        crit += Lev;
        miss += Lev;
        luck += Lev;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerLev", Lev);
        UpdateInfo();
    }

    public void AddEventListener(UnityAction<PlayerModel> function)
    {
        updateEvent += function;
    }

    public void RemoveEventListener(UnityAction<PlayerModel> function)
    {
        updateEvent -= function;
    }

    private void UpdateInfo()
    {
        if (updateEvent != null)
            updateEvent(this);
    }
}
