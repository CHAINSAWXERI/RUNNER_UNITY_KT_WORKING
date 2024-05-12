using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] public TileSpawner tileSpawner;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            tileSpawner.removeTitle();
            tileSpawner.SpawnTitle();
        }
    }
}
