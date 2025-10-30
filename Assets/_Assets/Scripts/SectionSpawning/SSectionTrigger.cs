using System.Collections;
using UnityEngine;
public class SSectionTrigger : MonoBehaviour
{
    SSpawningManager mSpawnManager;
    SCoinManager mCoinManager;
    SObjectSpawnManager mObjectSpawnManager;
    [SerializeField] private bool mCanBeTriggered = true;
    private void Start()
    {
        mCanBeTriggered = true;
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>(); 
        mSpawnManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SSpawningManager>();
        mObjectSpawnManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SObjectSpawnManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(mCanBeTriggered == true && other.gameObject.CompareTag("Player"))
        {
            mCanBeTriggered = false;
            mCoinManager.CoinSpawnGetter();
            mObjectSpawnManager.GetObjSpawner();
            mSpawnManager.SpawnHandlingGetter();

            mSpawnManager.SpawnDecorManagerGetter();

            StartCoroutine(RestartBool());
        }
    }
    private IEnumerator RestartBool()
    {
        yield return new WaitForSeconds(1f);
        mCanBeTriggered = true;
    }
}
