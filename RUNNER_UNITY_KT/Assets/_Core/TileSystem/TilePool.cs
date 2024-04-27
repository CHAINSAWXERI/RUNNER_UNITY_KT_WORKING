using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    [SerializeField] public List<GameObject> tilePool;

    public TilePool(params GameObject[] prefabs)
    {
        foreach (var prefab in prefabs)
        {
            tilePool.Add(Instantiate(prefab));
        }
    }

    public GameObject GetItem(int movingTitle)
    {
        if (tilePool.Count > 0)
        {
            movingTitle = tilePool.Count - 1;
            GameObject item = tilePool[movingTitle];
            tilePool.RemoveAt(movingTitle);
            return item;
        }
        else
        {
            return null;
        }
    }

    public void ReturnItem(GameObject item)
    {
        if (item != null && !tilePool.Contains(item))
        {
            tilePool.Add(item);
        }
    }
}
