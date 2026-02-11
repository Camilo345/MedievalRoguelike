using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CharacterInputs : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    public Action<Vector2> OnMove;
    public Action OnAttack;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.CharacterController.Enable();
    }
    void Start()
    {
        _playerInputs.CharacterController.Move.started += MovePlayer;
        _playerInputs.CharacterController.Move.performed += MovePlayer;
        _playerInputs.CharacterController.Move.canceled += MovePlayerCanceled;
        _playerInputs.CharacterController.Attack.started += PlayerAttack;
    }

    private void PlayerAttack(InputAction.CallbackContext context)
    {
        OnAttack?.Invoke();
    }

    private void MovePlayer(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }

    private void MovePlayerCanceled(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(Vector2.zero);
    }
    private void OnDisable()
    {
        _playerInputs.CharacterController.Move.started -= MovePlayer;
        _playerInputs.CharacterController.Move.performed -= MovePlayer;
        _playerInputs.CharacterController.Move.canceled -= MovePlayerCanceled;
        _playerInputs.CharacterController.Attack.started -= PlayerAttack;
        _playerInputs.CharacterController.Disable();
    }
}
