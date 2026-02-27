using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterData", order = 0)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    [Range(0, 100)] public int health;
    [Range(0, 100)] public int shield;
    [Range(0, 100)] public int damage;
    [Range(0, 5)] public float Cooldown;
}
