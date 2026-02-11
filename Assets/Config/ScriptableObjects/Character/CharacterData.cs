using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterData", order = 0)]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int health;
    public int shield;
    public int damage;
}
