using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Button mStartButton, mQuitButton, mMainMenuButton, mPlayAgainButton;

    [SerializeField] SSkinSelection mSkinSelection;
    private SCoinManager mCoinManager;
<<<<<<< HEAD
    private SDistanceManager mDistanceManager;
=======
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

<<<<<<< HEAD
        mDistanceManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SDistanceManager>();
=======
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();

        mStartButton?.onClick.AddListener(StartOnClick);
        mQuitButton?.onClick.AddListener(QuitOnClick);
        mMainMenuButton?.onClick.AddListener(MainMenuOnClick);
        mPlayAgainButton?.onClick.AddListener(PlayAgain);
    }
    private void StartOnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }
    private void QuitOnClick()
    {
        mCoinManager.SaveCoins();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Quitting game");
        Application.Quit();
    }
    private void MainMenuOnClick()
    {
<<<<<<< HEAD
        mDistanceManager.SaveDistance();
=======
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
        mCoinManager.SaveCoins();
        Debug.Log("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
<<<<<<< HEAD
        mDistanceManager.LoadDistance();
        mCoinManager.LoadCoins();
=======
        mCoinManager.LoadCoins();
<<<<<<< HEAD
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
    }
    private void PlayAgain()
    {
        mCoinManager.SaveCoins();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        SceneManager.LoadScene(1);
<<<<<<< HEAD
=======
=======
>>>>>>> 62b0d270a1dad68aa1ab653d35e6fe36ac6a0234
>>>>>>> b34aba7ec8f3571ac5d389ddadbc2c699825478a
    }
}
