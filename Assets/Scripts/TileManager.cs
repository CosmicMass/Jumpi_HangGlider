using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    public List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    private Queue<GameObject> tilePool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 50 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject tile;

        if (tilePool.Count > 0)
        {
            tile = tilePool.Dequeue();
            tile.SetActive(true);
            tile.transform.position = transform.forward * zSpawn;
            tile.transform.rotation = transform.rotation;
        }
        else
        {
            tile = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        }

        activeTiles.Add(tile);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        GameObject tileToRemove = activeTiles[0];
        activeTiles.RemoveAt(0);

        tileToRemove.SetActive(false);
        tilePool.Enqueue(tileToRemove);
    }
}
