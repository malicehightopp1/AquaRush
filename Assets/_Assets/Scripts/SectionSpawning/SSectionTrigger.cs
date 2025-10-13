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
        if (other.gameObject.CompareTag("Trigger") && mCanBeTriggered == true)
        {
            mCanBeTriggered = false;
            Debug.Log($"Hit {other.gameObject.name}");
            mCoinManager.CoinSpawnGetter();
            mSpawnManager.SpawnHandlingGetter();
            RestartBool();
        }
    }
    private void RestartBool()
    {
        mCanBeTriggered = true;
    }
}
