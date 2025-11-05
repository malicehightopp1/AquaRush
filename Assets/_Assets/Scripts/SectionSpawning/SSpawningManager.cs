using System.Collections.Generic;
using UnityEngine;
public class SSpawningManager : MonoBehaviour
{
    [Header("Section Spawning")]
    [SerializeField] private float mSectionMovespeed = 5;
    [SerializeField] private float mSectionOffset = 1000;
    [SerializeField] private List<GameObject> mSectionPrefabs;
    [SerializeField] private Transform mSectionSpawn;

    [Header("Decor spawning")]
    [SerializeField] private List<GameObject> mDecorPrefabs;
    [SerializeField] private Transform mDecorSpawn;
    [SerializeField] private float mDecorOffset = 100;
    public float MoveSpeed
    {
        get { return mSectionMovespeed; }
        set { mSectionMovespeed = value; }
    }
    private void SpawnHandling()
    {
        GameObject Child = GetRandomObject(mSectionPrefabs);
        Instantiate(Child, new Vector3(0, 0 , mSectionOffset), Quaternion.identity);
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
    #region Decor Spawning
    private void SpawnDecorManager()
    {
        GameObject Child = GetRandomObject(mDecorPrefabs);
        Instantiate(Child, new Vector3(0, 0, mDecorOffset), Quaternion.identity);
    }
    public void SpawnDecorManagerGetter()
    {
        SpawnDecorManager();
    }
    #endregion
}
