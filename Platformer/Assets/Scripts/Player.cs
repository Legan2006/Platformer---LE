using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    InputAction moveAction;

    void Awake()
    {
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
        
    }
}
