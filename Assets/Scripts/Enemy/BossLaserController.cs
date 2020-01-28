using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserController : EnemyGunController
{
    protected override IEnumerator Reload()
    {
        while (true)
        {
            if (canShoot)
            {
                for (int i = 0; i < 5; i++)
                {
                    yield return new WaitForSeconds(reloadTime);
                    Shoot();
                }
                yield return new WaitForSeconds(reloadTime*12);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    protected override void Shoot()
    {
        audio.Play();
        transform.right = (target.position - transform.position) * ((transform.position.x > target.position.x) ? -1f : 1f);
        Destroy(Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 180 * ((transform.position.x > target.position.x) ? 1 : 0f))), 3f);
    }

}
