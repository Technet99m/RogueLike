using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    protected float Health;
    public float MaxHealth;

    private void Start()
    {
        Health = MaxHealth;
    }
    public virtual void TakeDamage(float f)
    {
        Health -= f;
        if (Health <= 0)
            Die();
    }
    protected virtual void Die()
    {

    }
}
