using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MVP_MainView : MonoBehaviour
{
    public Button btnRole;
    public Button btnSkill;
    public Text txtName;
    public Text txtLev;
    public Text txtMoney;
    public Text txtGem;
    public Text txtPower;

    public void UpdateInfo(string name,int lev,int money,int gem,int power)
    {
        txtName.text = name;
        txtLev.text = lev.ToString();
        txtMoney.text = money.ToString();
    }

}
