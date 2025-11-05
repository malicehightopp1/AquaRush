using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SObjectSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> mPrefabList;
    [SerializeField] private int mNumberOfOBJSpawned = 0;
    private float[] mLanes = { -2, 0, 2 };

    [SerializeField] private Transform mPrefabSpawnPoint;

    private float mZOffset = -75;
    void Start()
    {
        ObjectSpawnManager();
    }
    private void ObjectSpawnManager()
    {
        for (int i = 0; i < mNumberOfOBJSpawned; i++)
        {
            mZOffset += 50;
            Vector3 SpawnPOS = new Vector3(mLanes[Random.Range(0, mLanes.Length)], 0f, mZOffset); //selects random lane and offsets a bit 
            GameObject RandomPrefab = GetRandomOBJ(mPrefabList); //selecting a random coin pattern to spawn

            GameObject spawnedCoinOBJ = GameObject.Instantiate(RandomPrefab, mPrefabSpawnPoint.transform.position, Quaternion.identity);
            spawnedCoinOBJ.transform.position = SpawnPOS;
            if (i == 0)
            {
                mZOffset = -75;
            }
        }
    }
    GameObject GetRandomOBJ(List<GameObject> objs)
    {
        int index = Random.Range(0, objs.Count);
        return objs[index];
    }
    public void GetObjSpawner()
    {
        ObjectSpawnManager();
    }
}
