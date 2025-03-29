using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width = 100;  // Ancho del mapa
    public int height = 100; // Altura del mapa
    public float scale = 20f; // Escala de ruido (más alto para más "detalles")
    public float offsetX = 0f; // Desplazamiento en X
    public float offsetY = 0f; // Desplazamiento en Y

    public GameObject terrainObject; // Prefab para el terreno (si lo necesitas)

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        // Genera el terreno usando ruido Perlin
        Terrain terrain = terrainObject.GetComponent<Terrain>(); // Si estás usando un Terrain de Unity
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Genera alturas usando ruido Perlin
                float xCoord = (float)x / width * scale + offsetX;
                float yCoord = (float)y / height * scale + offsetY;

                // El ruido Perlin devuelve valores entre -1 y 1, los normalizamos a 0 y 1
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                heights[x, y] = sample;
            }
        }
        return heights;
    }
}
