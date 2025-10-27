using TMPro;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    [Header("Player hits")]
    [SerializeField] private int mPlayerHits = 0;
    [SerializeField] private int mPlayerMaxHits = 3;
    private bool mIsPlayerIsDead = false;
    private TextMeshProUGUI mPlayerHitsText;
    private GameObject mPlayerLoseScreen;

    [Header("References")]
    private SCameraRig mRig;
    private SDistanceManager mDistanceManager;
    private SCoinManager mCoinManager;
    public bool IsPlayerDead
    {
        get => mIsPlayerIsDead;
        private set => mIsPlayerIsDead = value;
    }

    private void Awake()
    {
        mDistanceManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SDistanceManager>();
        mRig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SCameraRig>();
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
        mRig.SetFollowTransform(transform);
    }
    void Start()
    {
        mPlayerHitsText = GameObject.FindGameObjectWithTag("HitText").GetComponent<TextMeshProUGUI>();
        mPlayerLoseScreen = GameObject.FindGameObjectWithTag("PlayerLost");
        mPlayerLoseScreen.SetActive(false);
        mIsPlayerIsDead = false;
        mPlayerHits = mPlayerMaxHits;
        mPlayerHitsText.text = mPlayerHits.ToString();

        FindAnyObjectByType<SPauseManager>()?.SetPlayer(this);
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

        mDistanceManager.SaveDistance();
        mCoinManager.SaveCoins();
        IsPlayerDead = true;
        mPlayerLoseScreen.SetActive(true);

        mCoinManager.SaveCoins();

        IsPlayerDead = true;
        mPlayerLoseScreen.SetActive(true);

        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
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
