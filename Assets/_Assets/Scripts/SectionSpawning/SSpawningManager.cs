using System.Collections.Generic;
using UnityEngine;
public class SSpawningManager : MonoBehaviour
{
    [SerializeField] private float mSectionMovespeed = 5;
    [SerializeField] private float mSectionOffset = 1000;
    [SerializeField] private List<GameObject> mSectionPrefabs;
    [SerializeField] private Transform mSectionSpawn;
    public float MoveSpeed
    {
        get { return mSectionMovespeed; }
        set { mSectionMovespeed = value; }
    }
    private void SpawnHandling()
    {
        GameObject Child = GetRandomObject(mSectionPrefabs);
        Instantiate(Child, new Vector3(0, 0 , mSectionOffset), Quaternion.identity);
        Debug.Log($"Spawned : {Child.gameObject.name}");
    }
    public void SpawnHandlingGetter()
    {
        SpawnHandling();
    }
    private GameObject GetRandomObject(List<GameObject> list) //picking a random gameobject
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
}
