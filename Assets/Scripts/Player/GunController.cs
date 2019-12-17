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
    float nextTimeToShoot = 0;
    private void Start()
    {
        InvokeRepeating(nameof(FindTarget), 1f, 0.2f);
        FindTarget();
    }
    void Update()
    {
        if (target != null && (sr.flipX && target.position.x < transform.position.x) || (!sr.flipX && target.position.x > transform.position.x))
        {
            transform.right = (target.position - transform.position) * (sr.flipX ? -1f:1f);
        }
        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if(Time.time>nextTimeToShoot)
            {
                Shoot();
                nextTimeToShoot = Time.time + reloadTime;
            }
        }
        
    }

    void FindTarget()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 10,mask.value);
        if (colls != null)
        {
            int minIndex = 0;
            for (int i = 0; i < colls.Length; i++)
            {
                if (Vector2.Distance(colls[i].transform.position, transform.position) < Vector2.Distance(colls[minIndex].transform.position, transform.position))
                    if ((!sr.flipX && colls[i].transform.position.x > transform.position.x) || (sr.flipX && colls[i].transform.position.x < transform.position.x))
                        minIndex = i;
            }

            target = colls[minIndex].transform;
        }
        else
        {

        }
    }
    void Shoot()
    {
        Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180 * (sr.flipX ? 1 : 0f))), 3f);
    }
}
