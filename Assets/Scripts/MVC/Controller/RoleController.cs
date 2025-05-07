using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : MonoBehaviour
{
    private RoleView roleView;

    private static RoleController controller = null;

    public static RoleController Controller
    {
        get { return controller; }
    }

    // Start is called before the first frame update
    void Start()
    {
        roleView = this.GetComponent<RoleView>();
        roleView.UpdateInfo(PlayerModel.Data);
        roleView.btnClose.onClick.AddListener(ClickCloseBtn);
        roleView.btnLevUp.onClick.AddListener (ClickLevUpBtn);

        PlayerModel.Data.AddEventListener(UpdateInfo);
    }


    public static void ShowMe()
    {
        if (controller == null)
        {
            GameObject res = Resources.Load<GameObject>("UI/RolePanel");
            GameObject obj = GameObject.Instantiate(res);
            obj.transform.SetParent(GameObject.FindObjectOfType<Canvas>().gameObject.transform, false);
            controller = obj.GetComponent<RoleController>();
        }
        controller.gameObject.SetActive(true);
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
        if (controller != null)
        {
            //Destroy(panel.gameObject);
            //panel = null;
             
            controller.gameObject.SetActive(false);
        }
    }

    private void UpdateInfo(PlayerModel data)
    {
        if(roleView!= null)
        {
            roleView.UpdateInfo(data);
        }
    }

    private void OnDestroy()
    {
        PlayerModel.Data.RemoveEventListener(UpdateInfo);
    }
}
