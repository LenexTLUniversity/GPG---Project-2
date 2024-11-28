#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class AssetBundleBuilder
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string path = "Assets/AssetBundles";
        if (!System.IO.Directory.Exists(path))
            System.IO.Directory.CreateDirectory(path);

        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
#endif
