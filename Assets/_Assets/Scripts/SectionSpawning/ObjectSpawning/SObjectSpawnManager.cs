using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SObjectSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> mPrefabList;
    [SerializeField] private int mNumberOfOBJSpawned = 0;
    private float[] mLanes = { -2, 0, 2 };

    [SerializeField] private Transform mPrefabSpawnPoint;
    private float mZOffset;
    void Start()
    {
        ObjectSpawnManager();
    }
    private void ObjectSpawnManager()
    {
        for (int i = 0; i < mNumberOfOBJSpawned; i++)
        {

            Vector3 SpawnPOS = new Vector3(mLanes[Random.Range(0, mLanes.Length)], 0f, mZOffset); //selects random lane and offsets a bit 
            GameObject RandomPrefab = GetRandomOBJ(mPrefabList); //selecting a random OBJ to spawn in lanes

            GameObject spawnedCoinOBJ = GameObject.Instantiate(RandomPrefab, mPrefabSpawnPoint.transform.position, Quaternion.identity);
            spawnedCoinOBJ.transform.position = SpawnPOS;
        }
        mZOffset += mNumberOfOBJSpawned * 2f;
        if (mZOffset >= 50f)
        {
            mZOffset = 0;
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
