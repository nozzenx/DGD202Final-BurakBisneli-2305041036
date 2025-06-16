using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [Header("Movement Parameters")]
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [SerializeField] private float turnSpeed;
    
    [Header("Input Configurations")]
    private PlayerInput _playerInput;
    private InputActionMap _playerActionMap;
    private InputAction _moveAction;
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _playerActionMap = _playerInput.actions.FindActionMap("Player");
        _moveAction = _playerActionMap.FindAction("Movement");
        
        _playerActionMap.Enable();
        
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 moveVector = _moveAction.ReadValue<Vector2>();
        Move(moveVector);
    }

    public void Move(Vector2 direction)
    {
        float moveX = direction.x;
        float moveZ = direction.y;

        transform.Rotate(Vector3.up, moveX * turnSpeed * Time.deltaTime, Space.World);
        
        _rigidbody.linearVelocity = transform.forward * (moveZ * MoveSpeed);
    }
}
