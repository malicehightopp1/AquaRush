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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
    private GameObject mPlayerLose;

    [Header("Player hit effetcs")]
    [SerializeField] private MeshRenderer mPlayerRenderer;
    private Color mPlayerColor = Color.red;
    private float mHitEffetcDuration = 0.2f;

    private Color mOriginalColor;
    private Coroutine playerHitEffect;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
<<<<<<< HEAD
=======
    private GameObject mPlayerLose;
>>>>>>> 1bdc505 (Main menu rework and general bug fixes)
>>>>>>> 51e0c283b6d0f5a913a4895f1a032ffd5ed5b6c2
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
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

<<<<<<< HEAD
        mPlayerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeshRenderer>();
        mOriginalColor = mPlayerRenderer.material.color; //setting the players original color

=======
<<<<<<< HEAD
        mPlayerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeshRenderer>();
        mOriginalColor = mPlayerRenderer.material.color; //setting the players original color

=======
<<<<<<< HEAD
        mPlayerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MeshRenderer>();
        mOriginalColor = mPlayerRenderer.material.color; //setting the players original color

=======
>>>>>>> 51e0c283b6d0f5a913a4895f1a032ffd5ed5b6c2
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
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
<<<<<<< HEAD
        mDistanceManager.GetSaveDistance();
=======
<<<<<<< HEAD
        mDistanceManager.GetSaveDistance();
=======
<<<<<<< HEAD
        mDistanceManager.GetSaveDistance();
=======
        mDistanceManager.SaveDistance();
        mCoinManager.SaveCoins();
        IsPlayerDead = true;
        mPlayerLoseScreen.SetActive(true);

>>>>>>> 51e0c283b6d0f5a913a4895f1a032ffd5ed5b6c2
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
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
