using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SCoinManager : MonoBehaviour
{
    [Header("Coin management")]
    [SerializeField] private int mCurrentCoins = 0;

    [SerializeField] private int mCoinsCollectedThisRun = 0;

    private TextMeshProUGUI mCurrentCoinsText;

    [Header("Coin Spawning")]
    [SerializeField] private List<GameObject> mPrefabList;
    [SerializeField] private int mNumberOfCoinsSpawned = 0;
    private float[] mLanes = { -2, 0, 2 };

    [SerializeField] private Transform mPrefabSpawnPoint;

    [Header("Coin visual")]
    [SerializeField] private Transform mCoinVisualSpawnPoint;
    [SerializeField] private GameObject mCoinVisualPrefab;
    private TextMeshProUGUI mCoinVisualText;
    private float mzOffset = -75;
    public int CurrentCoins //getter and setter for coins manager
    {
        get { return mCurrentCoins; }
        set
        {
            int delta = value - mCurrentCoins;
            CoinsManager(delta);
        }
    }
    private void Start()
    {
        mCurrentCoinsText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();  
        mCoinVisualText = mCoinVisualPrefab?.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        UpdateCoinUI();
        CoinSpawningManager();
        if(SceneManager.GetActiveScene().name == "MainMenu_Scene") //checking if the player is in the right scene to load there coins that being the main menu
        {
            LoadCoins();
        }
    }
    private void CoinsManager(int CoinsToAdd) //managing math and amount of coins that the player has
    {
        mCoinsCollectedThisRun += CoinsToAdd;

        mCurrentCoins += CoinsToAdd;
        FindFirstObjectByType<SChallengeManager>().AddProgressToType(ChallengeType.CollectCoins, 1f);
        mCurrentCoins = Mathf.Clamp(mCurrentCoins, 0, 10000);
        mCoinVisualText.text = $"+{CoinsToAdd.ToString()}";
        StartCoroutine(mCoinVisual());
        UpdateCoinUI();
    }
    private IEnumerator mCoinVisual() //spawning a visual show of how many coins were added
    {
        GameObject clone = Instantiate(mCoinVisualPrefab, mCoinVisualSpawnPoint);
        yield return new WaitForSeconds(0.5f);
        Destroy(clone.gameObject);
    }
    #region Coin spawning
    private GameObject GetRandomObject(List<GameObject> list) //picking a random pattern of coins
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
    public void CoinSpawnGetter()
    {
        CoinSpawningManager();
    }
    private void CoinSpawningManager() //reworked coin system to spawn forward
    {
        for (int i = 0; i < mNumberOfCoinsSpawned; i++)
        {
            mzOffset += 50;
            Vector3 SpawnPOS = new Vector3(mLanes[Random.Range(0, mLanes.Length)], 0f, mzOffset); //selects random lane and offsets a bit 
            GameObject RandomPrefab = GetRandomObject(mPrefabList); //selecting a random coin pattern to spawn

            GameObject spawnedCoinOBJ = GameObject.Instantiate(RandomPrefab, mPrefabSpawnPoint.transform.position, Quaternion.identity);
            spawnedCoinOBJ.transform.position = SpawnPOS;
            if(i == 0) //resetting the offset back to original spawn pos
            {
                mzOffset = -75;
            }
        }
    }
    #endregion
    #region Coin Saving
    public void SaveCoins()
    {
        int totalcoins = PlayerPrefs.GetInt("SaveCoins", 0); //setting the save coins get int to be the variable totalcoins
        totalcoins += mCoinsCollectedThisRun; //adding the total coins to the total coins got that run **for adding the number of coins got ona  run to your total**

        mCurrentCoins = totalcoins;
        mCoinsCollectedThisRun = 0; //reseting it back to zero

        PlayerPrefs.SetInt("SaveCoins", mCurrentCoins);
        PlayerPrefs.Save(); //actually saving the current coins 
    }
    public void LoadCoins()
    {
        mCurrentCoins = PlayerPrefs.GetInt("SaveCoins", 0);

        mCoinsCollectedThisRun = 0;

        UpdateCoinUI();
        //ResetCoins(); **testing**
    }
    public void ResetCoins() //for testing reseting the coins back to 0
    {
        PlayerPrefs.SetInt("SaveCoins", 0); 
        PlayerPrefs.Save();                 
        mCurrentCoins = 0;                  
        UpdateCoinUI();                     
    }
    private void UpdateCoinUI() //instead of calling this a bunch of times just call the function to handle it
    {
        mCurrentCoinsText.text = $"Coins : {mCurrentCoins.ToString()}";
    }
    #endregion
}
