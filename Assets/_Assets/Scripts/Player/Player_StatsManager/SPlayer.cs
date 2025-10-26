using TMPro;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    private bool mIsPlayerIsDead = false;
    [SerializeField] private int mPlayerHits = 0;
    [SerializeField] private int mPlayerMaxHits = 3;

    [SerializeField] private SCameraRig mRig;

    [SerializeField] private TextMeshProUGUI mPlayerHitsText;
<<<<<<< HEAD
    [SerializeField] private GameObject mPlayerLoseScreen;

    [Header("References")]
    [SerializeField] private SCoinManager mCoinManager;
    private SDistanceManager mDistanceManager;
=======
<<<<<<< HEAD
    [SerializeField] private GameObject mPlayerLoseScreen;
    [Header("References")]
    [SerializeField] private SCoinManager mCoinManager;
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
    public bool IsPlayerDead
    {
        get => mIsPlayerIsDead;
        private set => mIsPlayerIsDead = value;
    }
<<<<<<< HEAD
=======
=======

    [Header("References")]
    [SerializeField] private SCoinManager mCoinManager;
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
    private void Awake()
    {
        mDistanceManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SDistanceManager>();
        mRig = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SCameraRig>();
        mPlayerHitsText = GameObject.FindGameObjectWithTag("HitText").GetComponent<TextMeshProUGUI>();
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();
        mRig.SetFollowTransform(transform);
    }
    void Start()
    {
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
<<<<<<< HEAD
        mDistanceManager.SaveDistance();
        mCoinManager.SaveCoins();
        IsPlayerDead = true;
        mPlayerLoseScreen.SetActive(true);
=======
        mCoinManager.SaveCoins();
<<<<<<< HEAD
        IsPlayerDead = true;
        mPlayerLoseScreen.SetActive(true);
=======
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
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
