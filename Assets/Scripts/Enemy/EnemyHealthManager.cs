using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    protected override void Die()
    {
        gameObject.SetActive(false);
        base.Die();
    }
    public override void TakeDamage(float f)
    {
        base.TakeDamage(f);
    }
}
