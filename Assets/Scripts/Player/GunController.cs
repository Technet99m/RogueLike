using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] SpriteRenderer sr;
    void Update()
    {
        if ((sr.flipX && target.position.x < transform.position.x) || (!sr.flipX && target.position.x > transform.position.x))
        {
            transform.right = (target.position - transform.position) * (sr.flipX ? -1f:1f);
        }
    }
}
