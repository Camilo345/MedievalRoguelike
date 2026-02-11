using UnityEngine;

public abstract class CharacterAttack : MonoBehaviour, IAttack
{
    public abstract void Execute(int damage);
}
