using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterInputs characterInputs;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;

    private CharacterController _controller;
    private bool isMovement;
    private Vector3 _currentMovement;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        characterInputs.OnMove += MovePlayer;
    }

    private void Update()
    {
        _controller.Move(_currentMovement * (Time.deltaTime*moveSpeed));
        HandleRotation();
        HandleGravity();
    }

    private void MovePlayer(Vector2 moveVector)
    {
        _currentMovement.x = moveVector.x;
        _currentMovement.z = moveVector.y;
        isMovement = moveVector.x != 0 || moveVector.y != 0;
    }
   
    private void HandleRotation()
    {
        Vector3 positionToLookAt = new Vector3();
        positionToLookAt.x = _currentMovement.x;
        positionToLookAt.y = 0f;
        positionToLookAt.z = _currentMovement.z;
        Quaternion rotation =transform.rotation;
        if (isMovement)
        {
            Quaternion newRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation= Quaternion.Slerp(rotation, newRotation, rotationSpeed*Time.deltaTime);
        }
    }
    private void HandleGravity()
    {
        if (!_controller.isGrounded) _currentMovement.y = -9.8f;
        else _currentMovement.y = 0f;
    }
    private void OnDisable()
    {
        characterInputs.OnMove -= MovePlayer;
    }
}
