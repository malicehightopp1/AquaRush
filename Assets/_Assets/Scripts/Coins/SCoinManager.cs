using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class SCoinManager : MonoBehaviour
{
    [Header("Coin management")]
    private int mCurrentCoins = 0;
    private TextMeshProUGUI mCurrentCoinsText;

    [Header("Coin Spawning")]
    [SerializeField] private List<GameObject> mPrefabList;
    [SerializeField] private int mNumberOfCoinsSpawned = 0;
    private float[] mLanes = { -2, 0, 2 };

    [SerializeField] private Transform mPrefabSpawnPoint;
    private float mzOffset = 0;
    public int CurrentCoins //getter and setter for coins manager
    {
        get { return mCurrentCoins; }
        set
        {
            int delta = value - mCurrentCoins;
            CoinsManager(delta);
        }
    }
    void Start()
    {
        mCurrentCoinsText = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();         
        mCurrentCoins = 0;
        mCurrentCoinsText.text = "Coins : " + mCurrentCoins.ToString();
        CoinSpawningManager();
    }
    private void CoinsManager(int CoinsToAdd)
    {
        mCurrentCoins += CoinsToAdd;
        mCurrentCoins = Mathf.Clamp(mCurrentCoins, 0, 10000);
        mCurrentCoinsText.text = "Coins : " + mCurrentCoins.ToString();
    }
    GameObject GetRandomObject(List<GameObject> list) //picking a random pattern of coins
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
            if(i >= 3)
            {
            }
            mzOffset = 0;
            Vector3 SpawnPOS = new Vector3(mLanes[Random.Range(0, mLanes.Length)], 0f, mzOffset); //selects random lane and offsets a bit 
            GameObject RandomPrefab = GetRandomObject(mPrefabList);
            GameObject spawnedCoinOBJ = GameObject.Instantiate(RandomPrefab, mPrefabSpawnPoint.transform.position, Quaternion.identity);
            spawnedCoinOBJ.transform.position = SpawnPOS;
            mzOffset += 40;
            //the offset is offsetting but when it resets spawns back at 0 and cause the coins to double up 
            //making lots of coins to spawn and get overcrowded
        }
    }
}
