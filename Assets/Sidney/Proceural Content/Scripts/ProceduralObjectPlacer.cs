using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralPlacement
{
    public class ProceduralObjectPlacer : MonoBehaviour
    {
        [SerializeField] private Texture2D placementTexture;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float gridSpacing = 1f;

        private void Start()
        {
            if (placementTexture != null)
            {
                PlaceObjects();
            }
        }

        private void PlaceObjects()
        {
            Color[] pixels = placementTexture.GetPixels();
            int width = placementTexture.width;

            for (int i = 0; i < pixels.Length; i++)
            {
                Vector3 position = CalculatePosition(i, width);

                if (pixels[i] == Color.white)
                {
                    Instantiate(enemyPrefab, position, Quaternion.identity);
                }
            }
        }

        private Vector3 CalculatePosition(int index, int width)
        {
            int x = index % width;
            int z = index / width;
            return new Vector3(x * gridSpacing, 0, z * gridSpacing);
        }
    }

}

