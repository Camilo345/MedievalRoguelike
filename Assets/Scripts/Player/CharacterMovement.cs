using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [Header("Move Config")]
    [SerializeField] private CharacterInputs characterInputs;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float rotationSpeed = 5;
    public float dashDistance = 2;
    
    private CharacterController _controller;
    private bool isMovement;
    private Vector3 _currentMovement;
    private MovementBlockReason _blockReasons;
    private bool isDashing = false;
    private bool canDash = true;
    private Vector3 _dashDirection;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        characterInputs.OnMove += MovePlayer;
        characterInputs.OnDash += tryDash;
    }

    private void Update()
    {
        if (!CanMove() || isDashing) return; 
        
        _controller.Move(_currentMovement * (Time.deltaTime * moveSpeed));
        HandleRotation();
        HandleGravity();
    }

    private void MovePlayer(Vector2 moveVector)
    {
        _currentMovement.x = moveVector.x;
        _currentMovement.z = moveVector.y;
        isMovement = moveVector.x != 0 || moveVector.y != 0;
    }

    private void tryDash()
    {
        if (!canDash||isDashing) return;
        _dashDirection = _currentMovement;
        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;

        float dashDuration = 0.2f;
        float elapsed = 0f;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + _dashDirection * dashDistance;
        while (elapsed < dashDuration)
        {
            float t = elapsed / dashDuration;
            Vector3 nextPosition = Vector3.Lerp(startPosition, targetPosition, t);

            Vector3 move = nextPosition - transform.position;
            _controller.Move(move);

            elapsed += Time.deltaTime;
            yield return null;
        }
        isDashing=false;
        yield return new WaitForSeconds(0.5f);
        canDash = true;
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

    public void AddBlock(MovementBlockReason reason)
    {
        _blockReasons |= reason;
    }

    public void RemoveBlock(MovementBlockReason reason)
    {
        _blockReasons &= ~reason;
    }

    private bool CanMove()
    {
        return _blockReasons == MovementBlockReason.None;
    }

    private void OnDisable()
    {
        characterInputs.OnMove -= MovePlayer;
        characterInputs.OnDash -= tryDash;
    }
}
