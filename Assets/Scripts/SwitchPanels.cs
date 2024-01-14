using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class PanelSwitcher : MonoBehaviour
{
    public GameObject panelToClose;
    public GameObject panelToOpen;

 //   public GameObject panel2ToOpen;

    public void SwitchPanels()
    {
  
        if (panelToClose.activeSelf)
        {
            panelToClose.SetActive(false);
        }


       panelToOpen.SetActive(true);
  //      panel2ToOpen.SetActive(true);


    }
}