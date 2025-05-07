using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolePresenter : MonoBehaviour
{
    private MVP_RoleView roleView;

    private static RolePresenter presenter = null;

    public static RolePresenter Presenter
    {
        get { return presenter; }
    }

    // Start is called before the first frame update
    void Start()
    {
        roleView = this.GetComponent<MVP_RoleView>();
        UpdateInfo(PlayerModel.Data);
        roleView.btnClose.onClick.AddListener(ClickCloseBtn);
        roleView.btnLevUp.onClick.AddListener(ClickLevUpBtn);

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }


    public static void ShowMe()
    {
        if (presenter == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = GameObject.Instantiate(res);
            obj.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform, false);
            presenter = obj.GetComponent<RolePresenter>();
        }
        presenter.gameObject.SetActive(true);
    }

    private void ClickCloseBtn()
    {
        HideMe();
    }

    private void ClickLevUpBtn()
    {
        PlayerModel.Data.LevUp();

    }

    public static void HideMe()
    {
        if (presenter != null)
        {
            //Destroy(panel.gameObject);
            //panel = null;

            presenter.gameObject.SetActive(false);
        }
    }

    private void UpdateInfo(PlayerModel data)
    {
        if (roleView != null)
        {
            roleView.txtAtk.text = data.Atk.ToString();
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
