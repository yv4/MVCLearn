using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private MainView mainView;

    private static MainController controller;

    private void Start()
    {
        mainView = this.GetComponent<MainView>();
        mainView.UpdateInfo(PlayerModel.Data);
        mainView.btnRole.onClick.AddListener(ClickRoleBtn);
        PlayerModel.Data.AddEventListener(UpdateInfo);
    }

    private void ClickRoleBtn()
    {
        RoleController.ShowMe();
    }

    private void UpdateInfo(PlayerModel data)
    {
        if(mainView != null)
        {
            mainView.UpdateInfo(data);

        }
    }

    public static MainController Controller
    {
        get { return controller; }
    }

    public static void ShowMe()
    {
        if (controller == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/MainPanel");
            GameObject obj = GameObject.Instantiate(res);
            obj.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform, false);
            controller = obj.GetComponent<MainController>();
        }
        controller.gameObject.SetActive(true);
    }

    public static void HideMe()
    {
        if (controller != null)
        {
            controller.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}