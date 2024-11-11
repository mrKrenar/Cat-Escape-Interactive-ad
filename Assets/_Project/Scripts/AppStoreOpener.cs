using UnityEngine;

public class AppStoreOpener : MonoBehaviour
{
    [SerializeField] private string playStoreLink, appStoreLink, falloutLink;

    public void OpenStore()
    {
        //This will open falloutLink on WebGL.
        //If we want to open correct store from WebGL a custom javascript plugin should be written to detect device OS as described in documentation: https://docs.unity3d.com/Manual/web-interacting-code-example.html  
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.OpenURL(playStoreLink);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)  
        {
            Application.OpenURL(appStoreLink);
        }
        else
        {
            Application.OpenURL(falloutLink);
        }
    }
}
