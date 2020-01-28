using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject bullet;
    [SerializeField] float reloadTime;
    [SerializeField] LayerMask mask;
    [SerializeField] SpriteRenderer player;
    [SerializeField] bool ultra;
    [SerializeField] AudioSource audio;
    float nextTimeToShoot = 0;
    private void Start()
    {
        InvokeRepeating(nameof(FindTarget), 1f, 0.2f);
        sr.flipX = player.flipX;
        sr.flipX ^= ultra;
        FindTarget();

    }
    void Update()
    {
        if (target != null)
        {
            if ((sr.flipX && target.position.x < transform.position.x) || (!sr.flipX && target.position.x > transform.position.x))
            {
                transform.right = (target.position - transform.position) * (sr.flipX ? -1f : 1f);
            }
            if ((Application.isMobilePlatform && PlayerController.Shooting) || (!Application.isMobilePlatform && Input.GetMouseButton(0)))
            {
                if (Time.time > nextTimeToShoot)
                {
                    Shoot();
                    nextTimeToShoot = Time.time + reloadTime;
                }
            }
        }
        
    }

    private void LateUpdate()
    {
        
        if (target == null)
        {
            sr.flipX = player.flipX;
            transform.rotation = Quaternion.identity;
        }
        else if (!target.gameObject.activeSelf)
        {
            target = null;
            sr.flipX = player.flipX;
            transform.rotation = Quaternion.identity;
            
        }
        else
            sr.flipX = target.position.x < transform.position.x;

    }
    void FindTarget()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 10,mask.value);
        if (colls.Length>0)
        {
            int minIndex = 0;
            for (int i = 0; i < colls.Length; i++)
            {
                if (Vector2.Distance(colls[i].transform.position, transform.position) < Vector2.Distance(colls[minIndex].transform.position, transform.position))
                        minIndex = i;
            }

            target = colls[minIndex].transform;
        }
    }
    void Shoot()
    {
        audio.Play();
        Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180 * (sr.flipX ? 1 : 0f))), 3f);
    }
}
