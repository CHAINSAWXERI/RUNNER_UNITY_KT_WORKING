using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] public TilePool tilePool;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] public float zOffset = 10f;
    private List<int> numsMoving = new List<int>();
    private List<int> numsFalse = new List<int>();
    private int movingIndex;
    private int falseMovingIndex = -1;
    private List<GameObject> TakenTiles = new List<GameObject>();
    private GameObject TakenTileToSpawn;
    private GameObject TakenTileToRemove;

    private void Start()
    {
        int n = 0;
        for (int i = 0; i < tilePool.tilePool.Count; i++)
        {
            numsMoving.Add(n);
            n++;
        }
        SpawnTitle();
        SpawnTitle();
        SpawnTitle();
    }

    public void SpawnTitle()
    {
        do
        {
            movingIndex = Random.Range(0, tilePool.tilePool.Count);
        } while (movingIndex == falseMovingIndex);

        numsFalse.Add(movingIndex);
        numsMoving.Remove(movingIndex);
        TakenTileToSpawn = tilePool.GetItem(movingIndex);
        falseMovingIndex = movingIndex;
        TakenTiles.Add(TakenTileToSpawn);
        TakenTileToSpawn.SetActive(true);
        TakenTileToSpawn.transform.position = new Vector3(0, 0, zOffset);
        zOffset += 10f;
    }

    public void removeTitle()
    {
        TakenTileToRemove = TakenTiles[0];
        tilePool.ReturnItem(TakenTileToRemove);
        TakenTileToRemove.SetActive(false);
        numsMoving.Add(numsFalse[0]);
        numsFalse.Remove(0);
        TakenTiles.RemoveAt(0);
    }

}
//tilePool.RemoveAt(movingTitle);