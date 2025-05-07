using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPresenter : MonoBehaviour
{
    private MVP_MainView mainView;

    private static MainPresenter presenter;

    public static MainPresenter Presenter
    {
        get { return presenter; }
    }

    private void Start()
    {
        mainView = this.GetComponent<MVP_MainView>();
        //mainView.UpdateInfo(PlayerModel.Data);
        UpdateInfo(PlayerModel.Data); 
        mainView.btnRole.onClick.AddListener(ClickRoleBtn);
        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    private void ClickRoleBtn()
    {
        RoleController.ShowMe();
    }

    private void UpdateInfo(PlayerModel data)
    {
        if (mainView != null)
        {
            // mainView.UpdateInfo(data);
            mainView.txtName.text = data.PlayerName;
            mainView.txtLev.text = data.Lev.ToString();
        }
    }

    public static void ShowMe()
    {
        if (presenter == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = GameObject.Instantiate(res);
            obj.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform, false);
            presenter = obj.GetComponent<MainPresenter>();
        }
        presenter.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (presenter != null)
        {
            presenter.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
