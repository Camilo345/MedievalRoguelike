using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    [Range(0, 100)] public int health;
    [Range(0, 100)] public int shield;
    [Range(0, 100)] public int damage;
    [Range(0, 15)] public float AttackCooldown;
    [Range(0, 100)] public float movementSpeed;
}
