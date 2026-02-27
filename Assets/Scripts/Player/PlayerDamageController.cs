using System;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour
{
    public Action<int> OnDamage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyWeapon"))
        {
            OnDamage?.Invoke(other.GetComponent<Enemy>().Damage);
        }
    }
}
