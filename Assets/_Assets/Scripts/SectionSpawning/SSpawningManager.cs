using UnityEngine;
public class SSpawningManager : MonoBehaviour
{
    [SerializeField] private float mSectionMovespeed = 5;
    [SerializeField] private float mSectionOffset = 100;
    [SerializeField] private GameObject mSectionPrefab;
    [SerializeField] private Transform mSectionSpawn;

    public float MoveSpeed
    {
        get { return mSectionMovespeed; }
        set { mSectionMovespeed = value; }
    }
    private void SpawnHandling()
    {
        GameObject Child = Instantiate(mSectionPrefab , mSectionSpawn);
        Instantiate(Child, new Vector3(0, 0 , mSectionOffset), Quaternion.identity);
    }
    public void SpawnHandlingGetter()
    {
        SpawnHandling();
    }
}
