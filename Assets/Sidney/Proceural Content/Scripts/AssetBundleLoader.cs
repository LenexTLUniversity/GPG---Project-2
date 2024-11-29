using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    public string assetBundlePath = "Assets/AssetBundles/DLC/enemybundle";  // Path to the Asset Bundle
    public string prefabName = "DLC Spitter";  // Name of the prefab you want to load from the Asset Bundle

    void Start()
    {
        LoadAssetBundle();
    }

    void LoadAssetBundle()
    {
        // Load the Asset Bundle from the specified path
        AssetBundle bundle = AssetBundle.LoadFromFile(assetBundlePath);
        if (bundle == null)
        {
            Debug.LogError("Failed to load Asset Bundle!");
            return;
        }

        // Load the "DLC Spitter" prefab from the Asset Bundle
        GameObject enemyPrefab = bundle.LoadAsset<GameObject>(prefabName);
        if (enemyPrefab != null)
        {
            // Instantiate the prefab at the position of the object this script is attached to
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Debug.Log("DLC Spitter prefab loaded and instantiated!");
        }
        else
        {
            Debug.LogError("Failed to load the DLC Spitter prefab from the Asset Bundle.");
        }

        // Optionally unload the Asset Bundle after usage to free memory
        bundle.Unload(false);
    }
}
