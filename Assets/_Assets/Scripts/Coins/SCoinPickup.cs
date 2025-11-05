using UnityEngine;
public class SCoinPickup : MonoBehaviour
{
    SCoinManager mCoinManager;
    private float mRotationSpeed = 100f;
    private Transform mTransform;
    private void Start()
    {
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
    }
    private void Update()
    {
        mTransform = transform;
        mTransform.Rotate(0f, mRotationSpeed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) //actually detecting coins
        {
            int coins = mCoinManager.CurrentCoins; 
            mCoinManager.CurrentCoins += 1; 
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("HitOBJ"))
        {
            Destroy(this.gameObject);
        }
    }
}
