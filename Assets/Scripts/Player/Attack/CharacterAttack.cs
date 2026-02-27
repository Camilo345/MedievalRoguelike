using System;
using UnityEngine;

public class CharacterAttack : MonoBehaviour, IAttack
{
    [SerializeField] private CharacterMovement characterMovement;

    protected Character _character;
    protected int _damage;
    protected float _cooldown = 0;
    protected bool _canAttack = true;
    public Action OnAttack;
    public virtual void Execute()
    {
        if (!_canAttack) return;
        Invoke("CanAttackAgain", _cooldown);
        characterMovement.AddBlock(MovementBlockReason.Attack);
        _canAttack = false;
        OnAttack?.Invoke();
    }
    public virtual void Initialize(Character character)
    {
        _character = character;
        _damage = _character.Damage;
        _cooldown = _character.CoolDown;
    }
    public virtual void Hit(Collider collider)
    {
        Debug.Log("Golpee a " + collider.gameObject.name + " y le hice " + _damage + " de daño");
    }
    public virtual void CanAttackAgain()
    {
        _canAttack = true;
        characterMovement.RemoveBlock(MovementBlockReason.Attack);
    }
}
