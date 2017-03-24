using System.Collections;
using UnityEngine;
using System;

public class TestDownloadingMechanimStateMachines : MonoBehaviour
{

    public string BundleURL;
    public string AssetName;
    public int version;

    public Animator targetAnimator;

    void Start()
    {
        StartCoroutine(DownloadAndCache());
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator DownloadAndCache()
    {
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload(BundleURL, version))
        {
            yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = www.assetBundle;
      
            var controller = bundle.LoadAsset<RuntimeAnimatorController>(AssetName);

            if (controller is RuntimeAnimatorController)
                targetAnimator.runtimeAnimatorController = controller;
            else
                Debug.Log("Incorrect asset");

            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }
}
