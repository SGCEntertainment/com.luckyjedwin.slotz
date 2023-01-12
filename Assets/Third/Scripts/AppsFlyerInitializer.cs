using AppsFlyerSDK;
using UnityEngine;

public class AppsFlyerInitializer : MonoBehaviour
{
    [SerializeField] string id;

    private void Start()
    {
        AppsFlyer.setIsDebug(true);
        AppsFlyer.initSDK(id, "");
        AppsFlyer.startSDK();
    }
}
