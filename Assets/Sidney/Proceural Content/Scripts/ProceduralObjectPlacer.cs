using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralObjectPlacer : MonoBehaviour
{
    public Texture2D textureMap; // The texture Map

    public GameObject objectToSpawn;

    public float spawnDepth; // z pos
    public float spawnWidth; // x pos
    public float spawnCount; // how many red pixels = 1 object

    private void Start()
    {
        if (textureMap == null)
        {
            Debug.LogError("Texture map not assigned in the inspector.");
            return;
        }
        SpawnObjectsFromTexture();
    }

    private void Update()
    {

    }

    void SpawnObjectsFromTexture()
    {
        if (textureMap == null)
        {
            Debug.Log("No Texture found!");
            return;
        }

        bool[,] occupiedPixels = new bool[textureMap.width, textureMap.height];
        int objectCount = 0;

        // Traverse every pixel in the texture map
        for (int y = 0; y < textureMap.height; y++)
        {
            for (int x = 0; x < textureMap.width; x++)
            {
                Color pixelColor = textureMap.GetPixel(x, y);

                if (IsRed(pixelColor))
                {
                    Debug.Log($"Found red pixel at: {x}, {y}");  // Debugging red pixel location

                    if (CanSpawnObjects(textureMap, x, y, occupiedPixels))
                    {
                        MarkOccupied(x, y, occupiedPixels);

                        // Adjust spawn position to align horizontally
                        Vector3 spawnPosition = new Vector3(x * spawnWidth, spawnDepth, y * spawnWidth) + transform.position;
                        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

                        objectCount++;
                        Debug.Log("Objects spawned: " + objectCount);
                    }
                }
            }
        }

        Debug.Log($"Total objects spawned: {objectCount}");
    }

    // Checks to see if there are any spaces to spawn object
    bool CanSpawnObjects(Texture2D image, int startX, int startY, bool[,] occupied)
    {
        int redPixelCount = 0;

        // Only checking this one pixel for now, you can later expand if needed
        if (occupied[startX, startY])
        {
            return false;
        }

        Color pixelColor = image.GetPixel(startX, startY);
        if (IsRed(pixelColor))
        {
            redPixelCount++;
        }

        return redPixelCount >= spawnCount;
    }

    // Marks occupied spaces
    void MarkOccupied(int startX, int startY, bool[,] occupied)
    {
        occupied[startX, startY] = true;
    }

    private bool IsRed(Color color)
    {
        // Adjust the thresholds for red pixels
        return color.r > 0.5f && color.g < 0.5f && color.b < 0.5f;
    }
}
