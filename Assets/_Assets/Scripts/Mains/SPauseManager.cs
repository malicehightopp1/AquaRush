using UnityEngine;
using UnityEngine.InputSystem;

public class SPauseManager : MonoBehaviour
{
    [SerializeField] private GameObject mPauseMenu;

    [Header("Components")]
    private PlayerActions mPlayerActions;

    private void Awake()
    {
        mPlayerActions = new PlayerActions();

        mPlayerActions.Gameplay.Pause.performed += GamePaused;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
        mPauseMenu.SetActive(false);
    }
    private void OnEnable()
    {
        mPlayerActions.Enable();
    }
    private void OnDisable()
    {
        mPlayerActions.Disable();
    }
    private void GamePaused(InputAction.CallbackContext context)
    {
        bool mIsPaused = !mPauseMenu.activeSelf;
        mPauseMenu.SetActive(mIsPaused);

        Time.timeScale  = mIsPaused ? 0f : 1f;
        Cursor.lockState = mIsPaused ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = mIsPaused ? true : false;
        Debug.Log("Game paused");
    }
}
