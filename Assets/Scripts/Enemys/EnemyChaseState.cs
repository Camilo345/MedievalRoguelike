using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyBaseState
{
    [SerializeField] private NavMeshAgent agent;

    private void OnEnable()
    {
        _animationController.RunAnimation(true);
        agent.isStopped = false;
        agent.speed = _enemy.MovementSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        CheckPlayerDistance();
        ChasePlayer();
    }

    private void CheckPlayerDistance()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance > _enemy.DistanceToAction)
        {
            _stateMachine.UpdateState(EnemyStatesType.wait);
        }
        
        if (distance < _enemy.DistanceToAttack)
        {
            StopMovement();
            _stateMachine.UpdateState(EnemyStatesType.attack);

        }
    }

    private void ChasePlayer()
    {
        agent.destination = player.position;
    }
    private void StopMovement()
    {
        _animationController.RunAnimation(false);
        agent.isStopped = true;
        agent.destination = transform.position;
        agent.velocity = Vector3.zero;
        agent.speed = 0;
        agent.ResetPath();
    }

    private void OnDisable()
    {
       StopMovement();
    }
}
