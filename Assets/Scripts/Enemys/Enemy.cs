using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Data")]
    [SerializeField] private EnemyData data;
    [SerializeField] private EnemyAnimationController animationController;
    [SerializeField, Range(0, 20)] private float distanceToAction = 10f;
    [SerializeField, Range(0, 20)] private float distanceToAttack = 10f;

    [Header("Character Data")]
    private int _currentHealth = 0;
    private int _defense = 0;
    private int _damage = 0;
    private float _coolDown = 0;
    private float _movementSpeed=0;
    public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public int Damage { get => _damage; set => _damage = value; }
    public float CoolDown { get => _coolDown; set => _coolDown = value; }
    public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
    public float DistanceToAction { get => distanceToAction; set => distanceToAction = value; }
    public float DistanceToAttack { get => distanceToAttack; set => distanceToAttack = value; }
    

    public EnemyAnimationController GetAnimationController() {  return animationController; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CurrentHealth = data.health;
        Defense = data.shield;
        Damage = data.damage;
        CoolDown = data.AttackCooldown;
        MovementSpeed = data.movementSpeed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DistanceToAction);
        Gizmos.DrawWireSphere(transform.position, DistanceToAttack);
    }
}
