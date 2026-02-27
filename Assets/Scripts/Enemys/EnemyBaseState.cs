using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    protected Transform player;
    protected EnemyStateMachine _stateMachine;
    protected Enemy _enemy;
    protected EnemyAnimationController _animationController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _stateMachine = GetComponent<EnemyStateMachine>();
        _enemy = GetComponent<Enemy>();
        _animationController = _enemy.GetAnimationController();
    }

    private void Reset()
    {
        this.enabled = false;
    }
}
