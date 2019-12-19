using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float speed, distanceToPlayer;
    [SerializeField] Animator anim;
    [SerializeField] EnemyGunController gun;
    Transform player;
    Vector2 leftBottom = new Vector2(-6.68f, -4.43f);
    Vector2 rightTop = new Vector2(5.81f, 4.35f);
    Vector2 targetPos;

    bool onPos, inCorner, isActive;
    void Start()
    {
        player = PlayerController.player;
        bool isOk = false;
        do
        {
            float angle = Random.Range(0, 2 * Mathf.PI);
            float r = Random.Range(2, 5);
            targetPos = new Vector2(Mathf.Sin(angle) * r, Mathf.Cos(angle) * r) + (Vector2)transform.position;
            if (Bounds.CheckBounds(targetPos, leftBottom, rightTop))
                isOk = true;
        } while (!isOk);
        onPos = false;
        InvokeRepeating(nameof(LookAtPlayer), 1f, 1f);
        Invoke(nameof(MakeActive), 1f);
    }
    void MakeActive()
    {
        isActive = true;
    }
    private void Update()
    {
        if (isActive)
        {
            if (!onPos)
            {
                Vector2 dir = (targetPos - (Vector2)transform.position).normalized;
                rb.velocity = dir * Time.deltaTime * speed;
                anim.SetFloat("velocityX", dir.x);
                anim.SetFloat("velocity", dir.magnitude);
                if (Vector2.Distance(transform.position, targetPos) < 0.1f)
                {
                    anim.SetFloat("velocityX", 0);
                    anim.SetFloat("velocity", 0);
                    onPos = true;
                    LookAtPlayer();
                }
            }
            else
            {
                rb.velocity = Vector2.zero;
                anim.SetFloat("velocity", 0);
            }
            if (distanceToPlayer > Vector2.Distance(transform.position, player.position) && !inCorner)
            {
                targetPos = transform.position - (player.position - transform.position).normalized;
                onPos = false;
            }
            else if (Vector2.Distance(transform.position, player.position) > (distanceToPlayer * 2f))
            {
                targetPos = transform.position + (player.position - transform.position).normalized * 1.5f;
                onPos = false;
                inCorner = false;
            }
            gun.canShoot = onPos;
        }

    }

    void LookAtPlayer()
    {
        if (player.position.x > transform.position.x)
        {
            anim.Play("IdleRight");
        }
        else if (player.position.x < transform.position.x)
        {
            anim.Play("IdleLeft");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bounds"))
        {
            inCorner = true;
            onPos = true;
        }
    }

}
