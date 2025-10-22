using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SMenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] Button mStartButton, mQuitButton, mMainMenuButton;

    [SerializeField] SSkinSelection mSkinSelection;
    private SCoinManager mCoinManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        mCoinManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SCoinManager>();

        mStartButton?.onClick.AddListener(StartOnClick);
        mQuitButton?.onClick.AddListener(QuitOnClick);
        mMainMenuButton?.onClick.AddListener(MainMenuOnClick);
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Quitting game");
        Application.Quit();
    }
    private void MainMenuOnClick()
    {
        mCoinManager.SaveCoins();
        Debug.Log("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        mCoinManager.LoadCoins();
    }
}
