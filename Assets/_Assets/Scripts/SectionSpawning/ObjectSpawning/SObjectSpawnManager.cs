using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SObjectSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> mObjectPrefabs;
    private float mZOffset;
    void Start()
    {
        ObjectSpawnManager();
    }
    private void ObjectSpawnManager()
    {
        for(int i = 0; i < 5; i ++)
        {
            Quaternion random = Quaternion.Euler(0f, Random.Range(179, -179), Random.Range(79, -79));
            Vector3 ObjSpawnx = new Vector3(Random.Range(1.5f, -1.5f), 0.2f,mZOffset);
            GameObject ObjSpawn = GetRandomOBJ(mObjectPrefabs);
            GameObject SpawnedBadOBJ = Instantiate(ObjSpawn, ObjSpawnx, random);
            Vector3 newObjPostion = SpawnedBadOBJ.transform.position;
            newObjPostion.z = mZOffset;
            newObjPostion.z = mZOffset;
            mZOffset += 40;
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
