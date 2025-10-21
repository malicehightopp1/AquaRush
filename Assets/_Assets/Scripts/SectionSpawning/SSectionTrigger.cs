using System.Collections;
using UnityEngine;
public class SSectionTrigger : MonoBehaviour
{
    SSpawningManager mSpawnManager;
    SCoinManager mCoinManager;
    [SerializeField] private bool mCanBeTriggered = true;
    private void Start()
    {
        mCanBeTriggered = true;
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>(); 
        mSpawnManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SSpawningManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(mCanBeTriggered == true && other.gameObject.CompareTag("Trigger"))
        {
            mCanBeTriggered = false;
            mCoinManager.CoinSpawnGetter();
            mSpawnManager.SpawnHandlingGetter();

            StartCoroutine(RestartBool());
        }
    }
    private IEnumerator RestartBool()
    {
        yield return new WaitForSeconds(1f);
        mCanBeTriggered = true;
    }
}
