using Unity.Mathematics;
using UnityEngine;

public  class Character : MonoBehaviour
{
    [Header("Character Config")]
    [SerializeField] private CharacterInputs input; 
    [SerializeField] private CharacterData data;
    [SerializeField] private CharacterAttack attack;

    [Header("Character Data")]
    private int _currentHealth =0;
    private int _shield = 0;
    private int _damage = 0;

    [Header("Character Data Get/Set")]
    public int CurrentHealth { get => _currentHealth; set => _currentHealth += value; }
    public int Shield { get => _shield; set => _shield += value; }
    public int Damage { get => _damage; set => _damage += value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = data.health;
        Shield = data.shield;
        Damage = data.damage;

        input.OnAttack += Attack;
    }
    
    public void Attack()
    {
        attack.Execute(Damage);
    }

    public bool ApplyDamage(int damage)
    {
        int realDamage = math.abs(Shield - damage);
        CurrentHealth -= realDamage;
        if (CurrentHealth > 0)
        {
            return false;
        }

        CurrentHealth = 0;
        return true;
    }
}
