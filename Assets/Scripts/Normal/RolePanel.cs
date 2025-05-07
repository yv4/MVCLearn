using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolePanel : MonoBehaviour
{
    public Text txtLev;
    public Text txtHp;
    public Text txtAtk;
    public Text txtDef;
    public Text txtCrit;
    public Text txtMiss;
    public Text txtLuck;

    public Button btnClose;
    public Button btnLevUp;

    private static RolePanel panel;

    // Start is called before the first frame update
    void Start()
    {
        btnClose.onClick.AddListener(ClickClose);

        btnLevUp.onClick.AddListener(ClickLvUp);
    }

    public static void ShowMe()
    {
        if (panel == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = GameObject.Instantiate(res);
            obj.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform, false);
            panel = obj.GetComponent<RolePanel>();
        }
        panel.gameObject.SetActive(true);
        panel.UpdateInfo();
    }

    public static void HideMe()
    {
        if (panel != null)
        {
            //Destroy(panel.gameObject);
            //panel = null;

            panel.gameObject.SetActive(false);
        }
    }

    public void ClickClose()
    {
        HideMe();
    }

    public void ClickLvUp()
    {
        int lev = PlayerPrefs.GetInt("PlayerLev", 1);
        int hp = PlayerPrefs.GetInt("PlayerHp", 100);
        int atk = PlayerPrefs.GetInt("PlayerAtk", 20);
        int def = PlayerPrefs.GetInt("PlayerDef", 100);
        int crit = PlayerPrefs.GetInt("PlayerCrit", 100);
        int miss = PlayerPrefs.GetInt("PlayerMiss", 100);
        int luck = PlayerPrefs.GetInt("PlayerLuck", 100);

        lev += 1;
        hp+= 1;
        atk+= 1;
        def += 1;
        crit += 1;
        miss += 1;
        luck += 1;

        PlayerPrefs.SetInt("PlayerLev", lev);
        PlayerPrefs.SetInt("PlayerHp", lev);
        PlayerPrefs.SetInt("PlayerAtk", lev);
        PlayerPrefs.SetInt("PlayerDef", lev);
        PlayerPrefs.SetInt("PlayerCrit", lev);
        PlayerPrefs.SetInt("PlayerMiss", lev);
        PlayerPrefs.SetInt("PlayerLuck", lev);

        UpdateInfo();

        MainPanel.Panel.UpdateInfo();
    }

    public void UpdateInfo()
    {
        txtLev.text = "Lv"+PlayerPrefs.GetInt("PlayerLev",1);
        txtHp.text = PlayerPrefs.GetInt("Hp",100).ToString();
        txtAtk.text = PlayerPrefs.GetInt("PlayerAtk", 100).ToString();
        txtDef.text = PlayerPrefs.GetInt("PlayerDef",100).ToString() ;
        txtCrit.text = PlayerPrefs.GetInt("PlayerCrit", 100).ToString();
        txtMiss.text = PlayerPrefs.GetInt("PlayerMiss", 100).ToString();
        txtLuck.text = PlayerPrefs.GetInt("PlayerLuck", 100).ToString();
    }
}
