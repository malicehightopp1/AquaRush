using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
public class SPlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float mMaxMoveSpeed = 300;
    [SerializeField] float mForwardSpeed = 300;
    [SerializeField] float mMoveSpeedAcceleration = 10;
    [SerializeField] float mDistance = 0;

    [Header("Components")]
    private PlayerActions mPlayerActions;
    private CharacterController mCharacterController;
    [SerializeField] private TextMeshProUGUI mDistanceText;

    [Header("Vectors")]
    private Vector3 mHorizontalVelocity;
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
        mDistanceText = GameObject.FindGameObjectWithTag("DistanceText").GetComponent<TextMeshProUGUI>();
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
        Vector3 forwardMove = transform.forward * mForwardSpeed;
        Vector3 FinalMov = forwardMove + mHorizontalVelocity;
        mCharacterController.Move(FinalMov * Time.deltaTime);
        HorizontalMovement();

        PlayerDistance();
    }
    private void HorizontalMovement()
    {
        Vector3 moveDir = PlayerInputToWorldDir(mMoveInput);
        transform.position += moveDir * mForwardSpeed * Time.deltaTime; //constantly moving the player forward
        if(moveDir.sqrMagnitude > 0)
        {
            mHorizontalVelocity += moveDir * mMoveSpeedAcceleration * Time.deltaTime;
            mHorizontalVelocity = Vector3.ClampMagnitude(mHorizontalVelocity, mMaxMoveSpeed);
        }
        else
        {
            if(mHorizontalVelocity.sqrMagnitude > 0)
            {
                mHorizontalVelocity -= mHorizontalVelocity.normalized * mMoveSpeedAcceleration * Time.deltaTime;
                if(mHorizontalVelocity.sqrMagnitude < 0.1f)
                {
                    mHorizontalVelocity = Vector3.zero;
                }
            }
        }
    }
    Vector3 PlayerInputToWorldDir(Vector2 inputval)
    {
        Vector3 rightDir = Camera.main.transform.right;
        Vector3 fwdDir = Vector3.Cross(rightDir, Vector3.up);

        return rightDir * inputval.x + fwdDir * inputval.y;
    }
    private void PlayerDistance()
    {
        mDistance += (1 * 3f) * Time.deltaTime;
        mDistanceText.text = "Distance : "+ mDistance.ToString("F2");
    }
}
