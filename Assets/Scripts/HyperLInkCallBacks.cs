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
        Application.OpenURL("https://drive.google.com/file/d/1_lGYaMHaYYgkoTpoLo9XVJ5Z4uT8UVeA/view?usp=sharing");
    }
}
