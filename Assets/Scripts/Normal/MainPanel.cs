using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    //1.获得控件
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtGem;
    public Text txtPower;

    public Button btnRole;

    private static MainPanel panel;

    public static MainPanel Panel
    {
        get { return panel; }
    }

    //2.添加事件
    //3.更新信息
    //4.动态显隐

    // Start is called before the first frame update
    void Start()
    {
        btnRole.onClick.AddListener(() =>
        {
            Debug.Log("BtnClick");
            RolePanel.ShowMe();
        });

    }

  
 
    private void ClickBtnRole()
    {
        RolePanel.ShowMe();
    }

    public void UpdateInfo()
    {
        txtName.text = PlayerPrefs.GetString("PlayerName","Limoyu");
        txtLev.text = PlayerPrefs.GetInt("PlayerLev", 1).ToString();
        txtMoney.text = PlayerPrefs.GetInt("PlayerMoney",1000).ToString();
        txtPower.text = PlayerPrefs.GetInt("PlayerPower",999).ToString();
        txtGem.text = PlayerPrefs.GetInt("PlayerGem", 999).ToString();
    }

    public static void ShowMe()
    {
        if(panel == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = GameObject.Instantiate(res);
            obj.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform,false);
            panel = obj.GetComponent<MainPanel>();
        }
        panel.gameObject.SetActive(true);
        panel.UpdateInfo();
    }

    public static void HideMe()
    {
        if(panel!=null)
        {
            //Destroy(panel.gameObject);
            //panel = null;

            panel.gameObject.SetActive(false);
        }
    }
}
