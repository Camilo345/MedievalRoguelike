using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterInputs characterInputs;

    private string HIT_PARAMETER = "Hit";
    private string RUN_PARAMETER = "Run";
    private string DIE_PARAMETER = "Die";
    private string ATTACK_PARAMETER = "Attack";

    private bool isMovement;
    private void OnEnable()
    {
        characterInputs.OnMove += MovePlayer;
        characterInputs.OnAttack += AttackAnimation;
    }

    private void MovePlayer(Vector2 moveVector)
    {
        if (moveVector.x != 0 || moveVector.y != 0) RunAnimation(true);
        else RunAnimation(false);
    }

    public void RunAnimation(bool value)
    {
        animator.SetBool(RUN_PARAMETER, value);
    }
    public void AttackAnimation()
    {
        animator.SetTrigger(ATTACK_PARAMETER);
    }

    public void HitAnimation()
    {
        animator.SetTrigger(HIT_PARAMETER);
    }

    public void DieAnimation()
    {
        animator.SetTrigger(DIE_PARAMETER);
    }

    public bool GetRunBool()
    {
        return animator.GetBool(RUN_PARAMETER);
    }
    private void OnDisable()
    {
        characterInputs.OnMove -= MovePlayer;
    }
}
