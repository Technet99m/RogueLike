using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : HealthManager
{
    [SerializeField] Slider HPBar;
    protected override void Die()
    {
        print("Die");
        base.Die();
    }
    public override void TakeDamage(float f)
    {
        base.TakeDamage(f);
        HPBar.value = Health / MaxHealth;
    }
}
