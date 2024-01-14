using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class BackLevels : MonoBehaviour
{
    public GameObject panelToClose;
    public GameObject SecondarypanelToClose;
    public GameObject ThirdpanelToClose;
    public GameObject panelToOpen;



    public void BackLeveling()
    {
  
        if (panelToClose.activeSelf)
        {
            panelToClose.SetActive(false);
            SecondarypanelToClose.SetActive(false);
            ThirdpanelToClose.SetActive(false);
        }


        panelToOpen.SetActive(true);
        


    }
}