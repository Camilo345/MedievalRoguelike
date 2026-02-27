using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyStatesType enemyState;
    [SerializeField] private List<EnemyState> states;

    private MonoBehaviour _currentState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        InitializeEnemy();
    }

    public void InitializeEnemy()
    {
        foreach (EnemyState state in states)
          if(state.stateScript!=null)  state.stateScript.enabled = false;

        UpdateState(EnemyStatesType.wait);
    }

    public void UpdateState(EnemyStatesType newState)
    {

        if (_currentState != null) _currentState.enabled = false;
        foreach(EnemyState state in states)
        {
            if(state.state == newState)
            {
                enemyState = newState;
                _currentState = state.stateScript;
                _currentState.enabled = true;
                break;
            }
        }
    }
}
[Serializable]
public class EnemyState
{
    public EnemyStatesType state;
    public MonoBehaviour stateScript;
}

public enum EnemyStatesType
{
    iddle,
    wait,
    chase,
    attack,
    damage,
    die
}


