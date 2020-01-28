using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AudioSource audio;
    public void BoomInit(float time)
    {
        Invoke(nameof(Boom), time);
    }
    void Boom()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 1);
        foreach (Collider2D coll in colls)
            if (coll.CompareTag("Player"))
                coll.GetComponent<HealthManager>().TakeDamage(0.3f);
        transform.rotation = Quaternion.identity;
        enabled = false;
        audio.Play();
        anim.Play("Boom");
    }
}
