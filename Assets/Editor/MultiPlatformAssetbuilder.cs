using System.IO;
using UnityEditor;
using UnityEngine;

public class MultiPlatformAssetbuilder  
{

	[MenuItem("Assets/MultiPlatformAssetbuilder")]
	static void CreateAssetBundles()
	{
		var path = Path.Combine(Application.dataPath, "AssetBundles");
		bool BundlesPathExists = Directory.Exists(path);
		if(!BundlesPathExists)
			Directory.CreateDirectory(path);

		var path2 = Path.Combine(path, "Platforms");
		bool PlatformsPathExists = Directory.Exists(path2);

		if(!PlatformsPathExists)
			Directory.CreateDirectory(path2);

		CreateiOSBundles(path2);
		CreateStandAloneAssetBundles(path2);
		CreateAndroidBundles(path2);
	}
	static void CreateStandAloneAssetBundles(string path)
	{

		string subPath ="Standalone"; // your code goes here
		var fullPath = GetSubPath(path, subPath);

		BuildPipeline.BuildAssetBundles (fullPath, 
		BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);

	}

	static void CreateiOSBundles(string path)
	{
		string subPath ="iOS"; // your code goes here
		var fullPath = GetSubPath(path, subPath);

		BuildPipeline.BuildAssetBundles(fullPath, BuildAssetBundleOptions.None, BuildTarget.iOS);
	}

	static void CreateAndroidBundles(string path)
	{
		string subPath ="Android"; // your code goes here
		var fullPath = GetSubPath(path, subPath);

		BuildPipeline.BuildAssetBundles(fullPath, BuildAssetBundleOptions.None, BuildTarget.Android);
	}


	#region Helpers
	static string GetSubPath(string path, string subPathDirectoryName)
	{
		string fullPath = Path.Combine(path, subPathDirectoryName);

		bool exists = System.IO.Directory.Exists(fullPath);

		if(!exists)
			System.IO.Directory.CreateDirectory(fullPath);

			return fullPath;
	}
	#endregion
}
