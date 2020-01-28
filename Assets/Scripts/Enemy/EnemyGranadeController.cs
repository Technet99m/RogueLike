using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGranadeController : EnemyGunController
{
    

    protected override void Shoot()
    {
        audio.Play();
        Vector2 highPoint = new Vector2(Mathf.Abs((transform.position.x - target.position.x) * (transform.position.y > target.position.y ? 0.7f : 1.1f)),
            (transform.position.y > target.position.y ? transform.position.y : target.position.y) + 0.5f - transform.position.y);
        float angle = Mathf.Atan(2 * highPoint.y);
        float magnitude = Mathf.Sqrt(highPoint.x * Physics2D.gravity.y * -1f / Mathf.Sin(2 * angle));
        Rigidbody2D rigid = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        float vy = magnitude * Mathf.Sin(angle);
        float time = (vy + Mathf.Sqrt(vy * vy + 2 * Physics2D.gravity.y * -1f * (transform.position.y - target.position.y))) / Physics2D.gravity.y * -1f;
        reloadTime = time + 1;
        if (float.IsNaN(reloadTime))
        {
            reloadTime = 3f;
            time = 2f;
        }
        rigid.GetComponent<GranadeController>().BoomInit(time);
        rigid.AddTorque(120f);
        rigid.velocity = new Vector2(magnitude * Mathf.Cos(angle) * (transform.position.x > target.position.x ? -1f : 1f), magnitude * Mathf.Sin(angle));
        Destroy(rigid.gameObject, reloadTime);
        
    }
}
