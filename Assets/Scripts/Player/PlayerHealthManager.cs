using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : HealthManager
{
    [SerializeField] Slider HPBar;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject[] toDisable;
    protected override void OnEnable()
    {
        base.OnEnable();
        HPBar.value = 1;
    }
    protected override void Die()
    {
        foreach (GameObject go in toDisable)
            go.SetActive(false);
        gameOver.SetActive(true);
        base.Die();
    }
    public override void TakeDamage(float f)
    {
        base.TakeDamage(f);
        HPBar.value = Health / MaxHealth;
    }
}
