using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float Health;
    public float MaxHealth;

    protected virtual void OnEnable()
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
