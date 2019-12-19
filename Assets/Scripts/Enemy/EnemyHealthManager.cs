using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    protected override void Die()
    {
        gameObject.SetActive(false);
        UltraController.instance.Add(Random.Range(0.15f, 0.35f));
        SceneManager.instance.DieAgain();
        base.Die();
    }
    public override void TakeDamage(float f)
    {
        base.TakeDamage(f);
    }
}
