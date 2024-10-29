using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    [SerializeField] List<SpawnObject> spawnObjects;
    void Start()
    {
        GetComponentInParent<WorldLoop>().Add(gameObject,tilePosition);

        transform.position = new Vector2(-100,-100);
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].Spawn();
        }
    }
}
