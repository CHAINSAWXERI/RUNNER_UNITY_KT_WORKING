using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileSettings", menuName = "Tile Settings", order = 1)]
public class TileSettings : ScriptableObject
{
    [System.Serializable]
    public class TileInfo
    {
        public GameObject prefab;
    }

    public TileInfo[] possibleTiles;
}
