using UnityEngine;

public class BarbarianAttack : CharacterAttack
{
    public override void Execute(int damage)
    {
        Debug.Log("El Barbaro ataco y hizo "+damage+" de daño");
    }
}
