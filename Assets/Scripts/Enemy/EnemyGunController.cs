using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    Transform target;
    [SerializeField] float reloadTime;
    [SerializeField] GameObject bullet;
    public bool canShoot;
    private void Start()
    {
        target = PlayerController.player;
        StartCoroutine(Reload());
    }
    void Update()
    {
        if ((sr.flipX && target.position.x < transform.position.x) || (!sr.flipX && target.position.x > transform.position.x))
        {
            transform.right = (target.position - transform.position) * (sr.flipX ? -1f : 1f);
        }
    }
    void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.Euler(0,0,transform.rotation.eulerAngles.z +180 * (sr.flipX ? 0 : 1f)));
        print((target.position - transform.position).normalized);
    }
    IEnumerator Reload()
    {
        while(true)
        {
            if (canShoot)
            {
                yield return new WaitForSeconds(reloadTime);
                Shoot();
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
