using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class bannerad : MonoBehaviour
{
    //public string placementId;
    bool testMode = false;
    string placementId;
    //string gameId;

#if UNITY_ANDROID
    string gameId = "4446768";
#elif UNITY_IPHONE
    string gameId = "4446769";
#else
    string gameId = "4446768";
#endif

    void Start()
    {
        if (gameId == "4446769")
        {
            placementId = "Banner_iOS";
        }
        if (gameId == "4446768")
        {
            placementId = "Banner_Android";

        }


        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {

        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
            Debug.Log("Initialize banner");


    }
}