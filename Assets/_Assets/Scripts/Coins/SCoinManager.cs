using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SCoinManager : MonoBehaviour
{
    [Header("Coin management")]
    [SerializeField] private int mCurrentCoins = 0;
<<<<<<< HEAD
    [SerializeField] private int mCoinsCollectedThisRun = 0;
=======
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
    private TextMeshProUGUI mCurrentCoinsText;

    [Header("Coin Spawning")]
    [SerializeField] private List<GameObject> mPrefabList;
    [SerializeField] private int mNumberOfCoinsSpawned = 0;
    private float[] mLanes = { -2, 0, 2 };

    [SerializeField] private Transform mPrefabSpawnPoint;
    private float mzOffset = -75;
    public int CurrentCoins //getter and setter for coins manager
    {
        get { return mCurrentCoins; }
        set
        {
            int delta = value - mCurrentCoins;
            CoinsManager(delta);
            SaveCoins();
        }
    }
    private void Start()
    {
        mCurrentCoinsText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();  
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            LoadCoins();
        }
<<<<<<< HEAD
        UpdateCoinUI();
=======
        mCurrentCoinsText.text = "Coins : " + mCurrentCoins.ToString();
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
        CoinSpawningManager();
    }
    private void CoinsManager(int CoinsToAdd)
    {
        mCoinsCollectedThisRun += CoinsToAdd;
        mCurrentCoins = Mathf.Clamp(mCurrentCoins, 0, 10000);
        UpdateCoinUI();
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
            if(i == 0)
            {
                mzOffset = -75;
            }
        }
    }
    #endregion
    #region Coin Saving
    public void SaveCoins()
    {
<<<<<<< HEAD
        int totalcoins = PlayerPrefs.GetInt("SaveCoins", 0);
        totalcoins += mCoinsCollectedThisRun;

        PlayerPrefs.SetInt("SaveCoins", totalcoins);

        mCurrentCoins = totalcoins;
        mCoinsCollectedThisRun = 0;
        PlayerPrefs.Save();

        Debug.Log($"Saving {totalcoins}");
=======
        Debug.Log($"saved players coins : {mCurrentCoins} coins saved");
        PlayerPrefs.SetInt("SaveCoins", mCurrentCoins);
        PlayerPrefs.Save();
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
    }
    public void LoadCoins()
    {
        mCurrentCoins = PlayerPrefs.GetInt("SaveCoins", 0);
<<<<<<< HEAD
        mCoinsCollectedThisRun = 0;

        UpdateCoinUI();
        //ResetCoins(); **testing**
        Debug.Log($"Loading {mCurrentCoins}");
    }
    private void UpdateCoinUI()
    {
        mCurrentCoinsText.text = $"Coins : {mCurrentCoins.ToString()}";
    }
    public void ResetCoins() //for testing reseting the coins back to 0
    {
        PlayerPrefs.SetInt("SaveCoins", 0); 
        PlayerPrefs.Save();                 
        mCurrentCoins = 0;                  
        UpdateCoinUI();                     
        Debug.Log("Coins reset to 0");
=======
        mCurrentCoinsText.text = "Coins : " + mCurrentCoins.ToString();
        Debug.Log($"Loading coins : {mCurrentCoins} Coins loaded");
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
    }
    #endregion
}
