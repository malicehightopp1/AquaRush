using TMPro;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    [SerializeField] private int mPlayerHits = 0;
    [SerializeField] private int mPlayerMaxHits = 3;

    [SerializeField] private SCameraRig mRig;

    [SerializeField] private TextMeshProUGUI mPlayerHitsText;

    [Header("References")]
    [SerializeField] private SCoinManager mCoinManager;
    private void Awake()
    {
        mRig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SCameraRig>();
        mPlayerHitsText = GameObject.FindGameObjectWithTag("HitText").GetComponent<TextMeshProUGUI>();
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
        mRig.SetFollowTransform(transform);
    }
    void Start()
    {
        mPlayerHits = mPlayerMaxHits;
        mPlayerHitsText.text = mPlayerHits.ToString();
    }
    private void PlayerHits(int hits)
    {
        mPlayerHits -= hits;
        mPlayerHits = Mathf.Clamp(mPlayerHits, 0, mPlayerMaxHits);
        mPlayerHitsText.text = mPlayerHits.ToString();
        if(mPlayerHits <= 0)
        {
            PlayerLose();
        }
    }
    void PlayerLose()
    {
        mCoinManager.SaveCoins();
        Time.timeScale = 0.0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HitOBJ"))
        {
            PlayerHits(1);
            Destroy(other.gameObject);
        }
    }
}
