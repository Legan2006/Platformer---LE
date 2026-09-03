using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    [SerializeField] private float runspeed = 5;

    [SerializeField] private InputActionAsset inputActions;

    InputAction moveAction;
    public Vector2 MoveInput { get; private set; }

    Rigidbody2D player;
    void Awake()
    {
        player = GetComponent<Rigidbody2D>();

        InputActionMap playerMap = inputActions.FindActionMap("PlayerCharacter" , true);

        moveAction = playerMap.FindAction("Move" , true);

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
    }

    private void Run()
    {
        float hMovement = MoveInput.x;
        player.linearVelocity = new Vector2(hMovement * runspeed, player.linearVelocity.y);
    }

}
