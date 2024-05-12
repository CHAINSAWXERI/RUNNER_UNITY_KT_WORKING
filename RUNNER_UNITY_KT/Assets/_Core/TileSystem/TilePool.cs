using System.Collections.Generic;
using UnityEngine;

public class TilePool : MonoBehaviour
{
    [SerializeField] public List<GameObject> tilePool;

    public GameObject GetItem(int movingTitle)
    {
        if (tilePool.Count > 0)
        {
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
