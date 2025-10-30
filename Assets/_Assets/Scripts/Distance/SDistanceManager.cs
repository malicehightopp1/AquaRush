using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SDistanceManager : MonoBehaviour
{
    [Header("Distance Settings")]
    [SerializeField] float mDistance = 0;
    private float mMaxDistance;
    private int mNextSpeedChange = 400;

    [Header("Components")]
    private TextMeshProUGUI mDistanceText;
    private TextMeshProUGUI mMaxDistanceText;

    [Header("References")]
    private SSpawningManager mSpawningManager;
<<<<<<< HEAD
    public void GetSaveDistance() => SaveDistance();
    public void GetLoadDistance() => LoadDistance();
=======
<<<<<<< HEAD
    public void GetSaveDistance() => SaveDistance();
    public void GetLoadDistance() => LoadDistance();
=======
<<<<<<< HEAD
    public void GetSaveDistance() => SaveDistance();
    public void GetLoadDistance() => LoadDistance();
=======
>>>>>>> 51e0c283b6d0f5a913a4895f1a032ffd5ed5b6c2
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
    private void Start()
    {
        mDistanceText = GameObject.FindGameObjectWithTag("DistanceText")?.GetComponent<TextMeshProUGUI>();
        mMaxDistanceText = GameObject.FindGameObjectWithTag("MaxDistanceText")?.GetComponent<TextMeshProUGUI>();
<<<<<<< HEAD
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<SSpawningManager>();
=======
<<<<<<< HEAD
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<SSpawningManager>();
=======
<<<<<<< HEAD
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<SSpawningManager>();
=======
<<<<<<< HEAD
=======
        mSpawningManager = GameObject.FindGameObjectWithTag("GameController")?.GetComponent<SSpawningManager>();
>>>>>>> 1bdc505 (Main menu rework and general bug fixes)
>>>>>>> 51e0c283b6d0f5a913a4895f1a032ffd5ed5b6c2
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
        if(SceneManager.GetActiveScene().name == "MainMenu_Scene")
        {
            LoadDistance();
        }
    }
    private void Update()
    {
        SpeedChange();
<<<<<<< HEAD
        if(SceneManager.GetActiveScene().name != "MainMenu_Scene")
=======
<<<<<<< HEAD
        if(SceneManager.GetActiveScene().name != "MainMenu_Scene")
=======
<<<<<<< HEAD
        if(SceneManager.GetActiveScene().name != "MainMenu_Scene")
=======
        if(SceneManager.GetActiveScene().name != "MainMenu")
>>>>>>> 51e0c283b6d0f5a913a4895f1a032ffd5ed5b6c2
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
        {
            PlayerDistance();
        }
    }
    private void PlayerDistance() //handling the players distance 
    {
        mDistance += (1 * 3f) * Time.deltaTime;
        mDistanceText?.SetText($"Distance : {mDistance.ToString("F2")}");
<<<<<<< HEAD
        FindFirstObjectByType<SChallengeManager>().AddProgressToType(ChallengeType.ReachDistance, 1);
=======
<<<<<<< HEAD
        FindFirstObjectByType<SChallengeManager>().AddProgressToType(ChallengeType.ReachDistance, 1);
=======
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
    }
    private void SaveDistance() //not currently doing this
    {
        LoadDistance();
        if(mDistance > mMaxDistance) //updating when the distance is higher than the max distance
        {
            mMaxDistance = mDistance;
            Debug.Log($"New Max Distance Achieved: {mMaxDistance}");
            PlayerPrefs.SetFloat("Distance", mMaxDistance);
            PlayerPrefs.Save();
        }
    }
    private void LoadDistance() //currently loads the distance 
    {
        mMaxDistance = PlayerPrefs.GetFloat("Distance", 0f);
        Debug.Log($"Loading Max Distance: {mMaxDistance}");
        mMaxDistanceText?.SetText($"Distance : {mMaxDistance.ToString("F2")}");
    }
    private void SpeedChange() //changes speed based on distance the player has got to
    {
        if (mDistance >= mNextSpeedChange)
        {
            Debug.Log($"Current Distance is: {mDistance} and Current Speed if: {mSpawningManager.MoveSpeed}");
            mSpawningManager.MoveSpeed += 5f;
            mNextSpeedChange += 400;
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
    }
    private void SpeedChange()
    {
        if (mDistance >= mNextSpeedChange)
        {
            Debug.Log($"Current Distance is: {mDistance} and Current Speed if: {mSpawningManager.MoveSpeed}");
            mSpawningManager.MoveSpeed += 5f;
            mNextSpeedChange += 400;
        }
>>>>>>> 8b580aee80f936907271dfac4924fcb1ad414cf6
>>>>>>> a909adbd4b7370d33cfc4d4a898e92614d94b53b
    }
}