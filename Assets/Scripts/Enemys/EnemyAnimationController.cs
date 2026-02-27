using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private string HIT_PARAMETER = "Hit";
    private string RUN_PARAMETER = "Run";
    private string DIE_PARAMETER = "Die";
    private string ATTACK_PARAMETER = "Attack";


    public void RunAnimation(bool value)
    {
        animator.SetBool(RUN_PARAMETER, value);
    }
    public void AttackAnimation()
    {
        animator.SetTrigger(ATTACK_PARAMETER);
    }

    public void HitAnimation(int damage)
    {
        animator.SetTrigger(HIT_PARAMETER);
    }

    public void DieAnimation()
    {
        animator.SetTrigger(DIE_PARAMETER);
    }

    public float GetCurrentAnimationLenght()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length;
    }
}
