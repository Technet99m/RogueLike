using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenSetter : MonoBehaviour
{
    
    public void Set()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        gameObject.SetActive(false);
    }

}
