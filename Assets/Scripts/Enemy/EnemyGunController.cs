using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    protected Transform target;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected GameObject bullet;
    public bool canShoot,triple;
    protected void Start()
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
    protected virtual void Shoot()
    {
        if (triple)
        {
            Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 15 + 180 * (sr.flipX ? 1 : 0f))), 3f);
            Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180 * (sr.flipX ? 1 : 0f))), 3f);
            Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 15 + 180 * (sr.flipX ? 1 : 0f))), 3f);
        }
        else
            Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180 * (sr.flipX ? 1 : 0f))), 3f);
    }
    protected virtual IEnumerator Reload()
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
