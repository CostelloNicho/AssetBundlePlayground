using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;

public class LoadFileAsyncExample : MonoBehaviour
{

    IEnumerator Start()
    {
        var bundleLoadRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, "dailyworkout"));
        yield return bundleLoadRequest;

        var myLoadedAssetBundle = bundleLoadRequest.assetBundle;
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            yield break;
        }

        var allAssets = myLoadedAssetBundle.LoadAllAssetsAsync();
        yield return allAssets;

        allAssets.allAssets.ToList().ForEach(asset => { Debug.Log(asset.name); });
    }
}