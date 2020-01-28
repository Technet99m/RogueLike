using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] string targetTag;
    [SerializeField] float damage;
    [SerializeField] Animator anim;
    int col = 0;

    private void Start()
    {
        if(targetTag == "Enemy" && UltraController.instance.ulta)
        {
            transform.localScale = new Vector3(transform.localScale.x * 3f, 3f, 1);
            damage *= 2;
        }
            
    }
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        col++;
        if (col > 1)
        {
            if (collision.CompareTag(targetTag))
            {
                if (CompareTag("Rocket"))
                {
                    anim.Play("Boom");
                    GetComponent<AudioSource>().Play();
                    Destroy(gameObject, 1f);
                    Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 1);
                    foreach (Collider2D coll in colls)
                        if (coll.CompareTag(targetTag))
                            coll.GetComponent<HealthManager>().TakeDamage(damage);
                    transform.rotation = Quaternion.identity;
                    enabled = false;
                }
                else
                {
                    collision.GetComponent<HealthManager>().TakeDamage(damage);
                    Destroy(gameObject);
                }
            }
        }
    }

}
