using UnityEngine;

public class EnemyWaitState : EnemyBaseState
{
    [SerializeField] protected EnemyStatesType nextState;
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position,transform.position);
        if (distance < _enemy.DistanceToAction)
        {
            _stateMachine.UpdateState(nextState);
        }
    }
}
