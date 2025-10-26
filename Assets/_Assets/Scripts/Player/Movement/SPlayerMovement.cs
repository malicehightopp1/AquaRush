using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(CharacterController))]
public class SPlayerMovement : MonoBehaviour
{
    [Header("Lane Control")]
    [SerializeField] private int mLaneCount = 3; //number of lanes
    [SerializeField] private float mLaneDistance = 2; //distance between lanes
    [SerializeField] private int mCurrentLane;
    [SerializeField] private float mLaneChangeSpeed = 10; //how fast the player goes between lanes

    [Header("Components")]
    private PlayerActions mPlayerActions;
    private CharacterController mCharacterController;

    [Header("Vectors")]
    private Vector3 mHorizontalVelocity;
    private Vector3 mTargetPOS;
    private Vector2 mMoveInput;
    void Awake()
    {
        mPlayerActions = new PlayerActions();

        mCharacterController = GetComponent<CharacterController>();

        mPlayerActions.Gameplay.Move.performed += HandleInput;
        mPlayerActions.Gameplay.Move.canceled += HandleInput;
    }
    private void Start()
    {
        mCurrentLane = mLaneCount / 2; //setting starting position to be the middle lane
        mTargetPOS = transform.position;
    }
    private void HandleInput(InputAction.CallbackContext context)
    {
        mMoveInput = context.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        mPlayerActions.Enable();
    }
    private void OnDisable()
    {
        mPlayerActions.Disable();
    }
    void Update()
    {
        Vector3 FinalMov = mHorizontalVelocity;
        mCharacterController.Move(FinalMov);
        HorizontalMovement();
        HandleLaneInput();
        UpdatePlayerPOS();
    }
    Vector3 PlayerInputToWorldDir(Vector2 inputval) //finds the cross for the camera to always be facing the player
    {
        Vector3 rightDir = Camera.main.transform.right;
        Vector3 fwdDir = Vector3.Cross(rightDir, Vector3.up);

        return rightDir * inputval.x + fwdDir * inputval.y;
    }
    #region LaneHandling
    private void HandleLaneInput()
    {
        if(mMoveInput.x > 0.5f) //changing to the right lane
        {
            ChangeLane(1);
            
            mMoveInput = Vector2.zero; //preventing the player from spamming the button
        }
        else if(mMoveInput.x < -0.5f) //changing to the left lane
        {
            ChangeLane(-1);
            mMoveInput = Vector2.zero;//preventing the player from spamming the button
        }
    }
    private void ChangeLane(int direction)
    {
        mCurrentLane = Mathf.Clamp(mCurrentLane + direction, 0 , mLaneCount - 1); //actually changing the index of the lanes and keeping the player within the 3 lanes
    }
    private void HorizontalMovement()
    {
        Vector3 moveDir = PlayerInputToWorldDir(mMoveInput); //updating for camera to follow the camera

        Vector3 pos = transform.position;
        float newX = Mathf.MoveTowards(pos.x, mTargetPOS.x, mLaneChangeSpeed * Time.deltaTime); //moving the player smoothly between lanes

        float deltaX = newX - pos.x;
        mHorizontalVelocity = new Vector3(deltaX, 0, 0);
    }
    private void UpdatePlayerPOS() //calculating the x postion for the current lane
    {
        float center = (mLaneCount - 1) * 0.5f; //finds center of index
        float DesiredX = (mCurrentLane - center) * mLaneDistance; //calculates target x pos
        mTargetPOS = new Vector3(DesiredX, transform.position.y, transform.position.z); //creates target pos vector
    }
    private void OnDrawGizmos() //for visual representation
    {
        if(!Application.isPlaying)
        {
            return;
        }
        float center = (mLaneCount - 1) * 0.5f;
        for(int i = 0; i < mLaneCount; i++)
        {
            float x = (i - center) * mLaneDistance;
            Gizmos.color = (i == mCurrentLane) ? Color.red : Color.green; //setting the color that the player is currently in to red
            Gizmos.DrawWireCube(new Vector3(x, transform.position.y + 1, transform.position.z + 5), new Vector3(1,2,1));
        }
    }
    #endregion
}
