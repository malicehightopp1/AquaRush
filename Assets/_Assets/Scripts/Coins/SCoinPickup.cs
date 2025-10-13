using UnityEngine;
public class SCoinPickup : MonoBehaviour
{
    SCoinManager mCoinManager;
    private void Start()
    {
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            int coins = mCoinManager.CurrentCoins; 
            mCoinManager.CurrentCoins += 1; 
            if(other.CompareTag("Coin"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
