using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr,weapon;
    [SerializeField] float speed, distanceToPlayer;
    [SerializeField] Animator anim;
    [SerializeField] EnemyGunController gun;
    Transform player;
    Vector2 leftBottom = new Vector2(-6.68f, -4.43f);
    Vector2 rightTop = new Vector2(5.81f, 4.35f);
    Vector2 targetPos;

    bool onPos, inCorner;
    void Start()
    {
        player = PlayerController.player;
        transform.position = new Vector3(Random.Range(leftBottom.x, rightTop.x), Random.Range(leftBottom.y, rightTop.y));
        bool isOk = false;
        do
        {
            float angle = Random.Range(0, 2*Mathf.PI);
            float r = Random.Range(2, 5);
            targetPos = new Vector2(Mathf.Sin(angle) * r, Mathf.Cos(angle) * r) + (Vector2) transform.position;
            if (Bounds.CheckBounds(targetPos,leftBottom,rightTop))
                isOk = true;
        } while (!isOk);
        onPos = false;
        InvokeRepeating(nameof(LookAtPlayer), 1f, 1f);
    }

    private void Update()
    {
        if (!onPos)
        {
            Vector2 dir = (targetPos - (Vector2)transform.position).normalized;
            rb.velocity =  dir * Time.deltaTime * speed;
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
        }
        if (distanceToPlayer > Vector2.Distance(transform.position, player.position) && !inCorner)
        {
            targetPos = transform.position - (player.position - transform.position).normalized;
            if(!Bounds.CheckBounds(targetPos, leftBottom, rightTop))
            {
                targetPos = new Vector2(Mathf.Clamp(targetPos.x, leftBottom.x, rightTop.x), Mathf.Clamp(targetPos.y, leftBottom.y, rightTop.y));
            }
            onPos = false;
        }
        else if(Vector2.Distance(transform.position, player.position) > distanceToPlayer*2f)
        {
            targetPos = transform.position + (player.position - transform.position).normalized * 3f;
            onPos = false;
            inCorner = false;
        }
        gun.canShoot = onPos;

    }
    private void LateUpdate()
    {
        weapon.flipX = sr.flipX;
        if (Vector2.Distance(transform.position, leftBottom) < 0.1f || Vector2.Distance(transform.position, rightTop) < 0.1f || Vector2.Distance(transform.position, new Vector2(leftBottom.x, rightTop.y)) < 0.1f || Vector2.Distance(transform.position, new Vector2(rightTop.x, leftBottom.y)) < 0.1f)
            inCorner = true;
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
}

public class Bounds
{
    /// <summary>
    /// Checks if dot is in area defined by left and right vector
    /// </summary>
    /// <param name="dot"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool  CheckBounds(Vector2 dot, Vector2 left, Vector2 right)
    {
        return dot.x > left.x && dot.x < right.x && dot.y > left.y && dot.y < right.y;
    }
}
