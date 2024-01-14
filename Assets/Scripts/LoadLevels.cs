using UnityEngine;
using UnityEngine.UI;
using PrimeTween;


public class LoadLevels : MonoBehaviour
{
    public GameObject SecondarypanelToClose;
    public GameObject SecondarypanelToOpen;
    public GameObject ThirdpanelToOpen;
    public GameObject FourthpanelToOpen;



    public void LevelsLoader()
    {
  
        if (SecondarypanelToClose.activeSelf)
        {
            SecondarypanelToClose.SetActive(false);
        }


        SecondarypanelToOpen.SetActive(true);
        ThirdpanelToOpen.SetActive(true);
        FourthpanelToOpen.SetActive(true);


    }
}