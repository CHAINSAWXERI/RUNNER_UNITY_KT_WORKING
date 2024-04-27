using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] public TilePool tilePool;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] public float zOffset = 10f;
    private List<int> numsMoving = new List<int>();
    private int movingIndex;
    private int falseMovingIndex = -1;
    private GameObject TakenTile;

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

        numsMoving.Remove(movingIndex);
        TakenTile = tilePool.GetItem(movingIndex);
        falseMovingIndex = movingIndex;
        TakenTile.SetActive(true);
        TakenTile.transform.position = new Vector3(0, 0, zOffset);
        zOffset += 10f;
    }

    public void removeTitle()
    {
        Debug.Log("Yeyo");
        tilePool.ReturnItem(TakenTile);
        TakenTile.SetActive(false);
    }

}
