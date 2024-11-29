using UnityEditor;
using UnityEngine;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build Asset Bundles")]
    public static void BuildAllAssetBundles()
    {
        string outputPath = "Assets/AssetBundles/DLC";

        // Clear the previous bundles
        if (System.IO.Directory.Exists(outputPath))
        {
            System.IO.Directory.Delete(outputPath, true);
        }

        System.IO.Directory.CreateDirectory(outputPath);

        // Build the Asset Bundles
        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        Debug.Log("Asset Bundles built and saved to: " + outputPath);
    }
}
