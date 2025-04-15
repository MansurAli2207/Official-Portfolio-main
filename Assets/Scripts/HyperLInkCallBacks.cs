using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLInkCallBacks : MonoBehaviour
{
    public void OpenLinkedInProfile()
    {
        Application.OpenURL("https://www.linkedin.com/in/mansur-ali-4405791ab/");
    }

    public void DownloadResume()
    {
        Application.OpenURL("https://drive.google.com/file/d/1mP-V90OK2JFSDVvErTfcdgoL28WsR64T/view?usp=sharing");
    }

    public void PortfolioSiteOpen()
    {
         Application.OpenURL("https://mansurali.framer.website/");
    }
}
