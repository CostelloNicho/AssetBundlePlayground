using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System;
using System.IO;

public class AssetBundleBuilderSpecific : EditorWindow
{

    UnityEngine.Object[] objects;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Assets/Build Specific Asset Bundles")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        AssetBundleBuilderSpecific window = 
            (AssetBundleBuilderSpecific)GetWindow(typeof(AssetBundleBuilderSpecific));
        window.Show();
    }

    public AssetBundleBuilderSpecific() : base()
    {
        Selection.selectionChanged = OnSelectionChanged;
    }

    void OnGUI()
    {
        if(objects != null)
        {
            objects.ToList().ForEach(obj => { AddCell(obj); });
        }
    }

    void OnSelectionChanged()
    {
        objects = Selection.objects;
    }

    void AddCell(UnityEngine.Object obj)
    {
        var name = obj.name;
        EditorGUILayout.LabelField(name);
    }

    void Footer()
    {
        GUI.BeginGroup(new Rect(0, position.height - 30, position.width, 30));
        if(GUILayout.Button("Build Asset Bundle"))
        {
            BuildAssetBundle();
        }
        GUI.EndGroup();
    }

    private void BuildAssetBundle()
    {
        string[] names = objects.Select(obj => obj.name).ToArray();
      
        //BuildPipeline.BuildAssetBundleExplicitAssetNames(objects, names, Path.Combine(Application.dataPath, "AssetBundles/Platforms/Standalone"));
    }
}
