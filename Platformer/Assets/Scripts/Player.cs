using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5.0f;

    [SerializeField] private float runAcceleration = 30f;

    [SerializeField] private float runDeceleration = 40f;
    
    [SerializeField] private InputActionAsset inputActions;

    [SerializeField] private float jumpSpeed = 5f;

    [SerializeField] private LayerMask groundLayer;
    InputAction moveAction;

    InputAction jumpAction;

    public bool jumpPressedThisFrame => jumpAction != null && jumpAction.WasPressedThisFrame();
    public LayerMask GroundLayer => groundLayer.value != 0 ? groundLayer : LayerMask.GetMask("Ground");
    public Vector2 MoveInput { get; private set; }
    
    Rigidbody2D playerCharacter;
    
    Animator playerAnimator;

    BoxCollider2D playerFeetCollider;

    // Initializes its contents before the game begins
    void Awake()
    {
        playerCharacter = GetComponent<Rigidbody2D>();

        playerAnimator = GetComponentInChildren<Animator>();
        
        InputActionMap playerMap = inputActions.FindActionMap("Player", true);

        moveAction = playerMap.FindAction("Move", true);

        jumpAction = playerMap.FindAction("Jump", true);

        playerFeetCollider = GetComponent<BoxCollider2D>();

        playerMap.Enable();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();

        Run();
        FlipSprite();
        Jump();
    }

    private void Run()
    {
        float hMovement = MoveInput.x;

        float targetSpeed = MoveInput.x * runSpeed;

        float speedChange;

        if(Mathf.Abs(targetSpeed) > Mathf.Epsilon)
        {
            speedChange = runAcceleration;
        }
        else
        {
            speedChange = runDeceleration;
        }

        float newSpeed = Mathf.MoveTowards(playerCharacter.linearVelocity.x, targetSpeed, speedChange * Time.deltaTime);

        playerCharacter.linearVelocity = new Vector2(newSpeed, playerCharacter.linearVelocity.y);

        bool hSpeed = Mathf.Abs(playerCharacter.linearVelocity.x) > Mathf.Epsilon;

        playerAnimator.SetBool("run", hSpeed);
    }

    private void FlipSprite()
    {
        Boolean hMovement = Mathf.Abs(playerCharacter.linearVelocity.x) > Mathf.Epsilon;

        if (hMovement)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerCharacter.linearVelocity.x), 1f);
        }
    }
    
    private void Jump()
    {
        bool isGrounded = playerFeetCollider.IsTouchingLayers(GroundLayer);

        if (jumpPressedThisFrame && isGrounded)
        {
            playerCharacter.linearVelocity = new Vector2(playerCharacter.linearVelocityX, jumpSpeed) ;
        }
    }



}
