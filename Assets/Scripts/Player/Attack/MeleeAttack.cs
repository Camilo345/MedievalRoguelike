using UnityEngine;

public class MeleeAttack : CharacterAttack
{
    [SerializeField] protected CollisionTriggerEvent collisionTrigger;
    public override void Initialize(Character character)
    {
        base.Initialize(character);
        collisionTrigger.OnTriggerEntered += Hit;
    }
    public override void Execute()
    {
        base.Execute();
        collisionTrigger.CanDetect = true;
    }

    public override void Hit(Collider collider)
    {
        base.Hit(collider);
        collisionTrigger.CanDetect = false;
    }
    public override void CanAttackAgain()
    {
        base.CanAttackAgain();
        collisionTrigger.CanDetect = false;
    }
    private void OnDestroy()
    {
        collisionTrigger.OnTriggerEntered -= Hit;
    }
}
