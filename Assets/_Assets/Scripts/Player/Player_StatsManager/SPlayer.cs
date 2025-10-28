using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    private GameObject mPlayerLose;

    [Header("Player hit effetcs")]
    [SerializeField] private MeshRenderer mPlayerRenderer;
    private Color mPlayerColor = Color.red;
    private float mHitEffetcDuration = 0.2f;

    private Color mOriginalColor;
    private Coroutine playerHitEffect;
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
        mPlayerLose = GameObject.FindGameObjectWithTag("LostText");
        mPlayerLose.SetActive(false);

        mPlayerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeshRenderer>();
        mOriginalColor = mPlayerRenderer.material.color; //setting the players original color

        mPlayerLoseScreen.SetActive(false);
        mIsPlayerIsDead = false;
        mPlayerHits = mPlayerMaxHits;
        mPlayerHitsText.text = mPlayerHits.ToString();


        FindAnyObjectByType<SPauseManager>()?.SetPlayer(this);
    }
    private void PlayerHits(int hits) //handling player damage
    {
        mPlayerHits -= hits;
        mPlayerHits = Mathf.Clamp(mPlayerHits, 0, mPlayerMaxHits);
        mPlayerHitsText.text = mPlayerHits.ToString();
        if(mPlayerHits <= 0)
        {
            PlayerLose();
        }
    }
    void PlayerLose() //handling all actions once player dies/loses
    {
        mDistanceManager.GetSaveDistance();
        mCoinManager.SaveCoins();

        IsPlayerDead = true;
        mPlayerLoseScreen.SetActive(true);
        mPlayerLose.SetActive(true);

        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private void OnTriggerEnter(Collider other) //when player hits a badobj take health from player
    {
        if (other.gameObject.CompareTag("HitOBJ"))
        {
            PlayerHits(1);
            Destroy(other.gameObject);
            if(playerHitEffect != null) //avoiding overlapping flashes
            {
                StopCoroutine(playerHitEffect);
            }
            playerHitEffect = StartCoroutine(PlayerHitEffect());
        }
    }
    private IEnumerator PlayerHitEffect()
    {
        mPlayerRenderer.material.color = mPlayerColor;
        yield return new WaitForSeconds(mHitEffetcDuration);
        mPlayerRenderer.material.color = mOriginalColor;
        playerHitEffect = null;
    }
}
