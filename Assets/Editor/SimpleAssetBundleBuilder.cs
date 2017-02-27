using UnityEditor;

public class SimpleAssetBundleBuilder  {

	[MenuItem("Assets/AssetBundle")]
	static void CreateStandAloneAssetBundles()
	{
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundles", 
		BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
	}
}
