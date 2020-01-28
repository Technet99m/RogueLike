using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : HealthManager
{
    [SerializeField] GameObject panel,player;
    [SerializeField] AudioListener al;
    protected override void Die()
    {
        if(gameObject.name == "Boss")
        {
            GetComponent<Animator>().SetBool("isDead",true);
            GetComponent<BossController>().enabled = false;
            GetComponent<BossRocketController>().enabled = false;
            transform.GetChild(0).GetComponent<BossLaserController>().enabled = false;
            transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            Invoke(nameof(BossDying), 2.5f);
            GetComponent<AudioSource>().Play();
            return;
        }
        gameObject.SetActive(false);
        UltraController.instance.Add(Random.Range(0.2f, 0.5f));
        SceneManager.instance.DieAgain();
        base.Die();
    }
    public override void TakeDamage(float f)
    {
        base.TakeDamage(f);
    }
    void BossDying()
    {
        al.enabled = false;
        panel.SetActive(true);
        player.SetActive(false);
        gameObject.SetActive(false);
    }
}
