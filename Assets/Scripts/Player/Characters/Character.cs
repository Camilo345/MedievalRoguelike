using System;
using Unity.Mathematics;
using UnityEngine;

public  class Character : MonoBehaviour
{
    [Header("Character Config")]
    [SerializeField] private CharacterInputs input; 
    [SerializeField] private CharacterData data;
    [SerializeField] private CharacterAttack attack;
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private PlayerDamageController damageController;

    [Header("Character Data")]
    private int _currentHealth =0;
    private int _defense = 0;
    private int _damage = 0;
    private float _coolDown = 0;

    [Header("Character Data Get/Set")]
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public float CoolDown { get => _coolDown; set => _coolDown = value; }

    public Action OnPlayerDead;

    void Start()
    {
        CurrentHealth = data.health;
        Defense = data.shield;
        Damage = data.damage;
        CoolDown = data.Cooldown;
        attack.Initialize(this);

        input.OnAttack += Attack;
        damageController.OnDamage += ApplyDamage;
    }
    
    public void Attack()
    {
        attack.Execute();
    }

    public void ApplyDamage(int damage)
    {
        float k = 50f;
        int realDamage = (int)((damage * k) / (k + Defense));
        CurrentHealth -= realDamage;
        Debug.Log(damage + " - " + Defense + " - " + realDamage + " - " + CurrentHealth);
        if (CurrentHealth > 0)
        {
            return;
        }
        Debug.Log("El jugador Murio");
        CurrentHealth = 0;
        movement.AddBlock(MovementBlockReason.Dead);
        OnPlayerDead?.Invoke();
    }
}
[Flags]
public enum MovementBlockReason
{
    None = 0,
    Attack = 1,
    Dead = 2,
    Stunned = 4,
    Dialogue = 8
}