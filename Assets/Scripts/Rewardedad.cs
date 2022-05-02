using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class Rewardedad : MonoBehaviour, IUnityAdsListener
{
    bool testMode = false;

    string placementId;

#if UNITY_ANDROID
    string gameId = "4446768";
#elif UNITY_IPHONE
    string gameId = "4446769";
#else
    string gameId = "4446768";
#endif

    //public GameObject boyObject;
    void Start()
    {
        if (gameId == "4446769") {
        placementId = "Rewarded_iOS";

        }
        if (gameId == "4446768") {
        placementId = "Rewarded_Android";

        }
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        Debug.Log("Initialize rewarded");
    }


    public void ShowAd()
    {

        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
            Debug.Log("show");
        }

    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Ad error");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //throw new System.NotImplementedException();
        if (showResult == ShowResult.Finished)
        {
            //reward
            GameObject.Find("GameManager").GetComponent<GameManager>().Continue();
            //GameObject.Find("GameManager").GetComponent<GameManager>().StartCoroutine(GameObject.Find("GameManager").GetComponent<GameManager>().startcountdown());
            Debug.Log("Finished");
        }
        else if (showResult == ShowResult.Failed || showResult == ShowResult.Skipped)
        {
            //gameManager.Continue();
            Debug.Log("Failed");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Ad starts");
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Ad ready");

    }


}
