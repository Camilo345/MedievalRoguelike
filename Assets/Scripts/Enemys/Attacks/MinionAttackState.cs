using System.Collections;
using UnityEngine;

public class MinionAttackState : EnemyBaseState
{
    private void OnEnable()
    {
        StartCoroutine(AttackRoutine());
    }
    private void Update()
    {
        ChangeStateIfPlayerIsOutOfRange();
    }

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(1);
        if (IsPlayerInAttackRange())
        {
            _animationController.AttackAnimation();
        }
   
        yield return new WaitForSeconds(_animationController.GetCurrentAnimationLenght());
        StartCoroutine(AttackRoutine());
    }
    private void ChangeStateIfPlayerIsOutOfRange()
    {
        if (!IsPlayerInAttackRange())
            _stateMachine.UpdateState(EnemyStatesType.wait);
    }
    private bool IsPlayerInAttackRange()
    {
        bool isPlayerInAttackRange = false;
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < _enemy.DistanceToAttack)
        {
            isPlayerInAttackRange = true;
        }

        return isPlayerInAttackRange;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
