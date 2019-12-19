using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    Transform target;
    float initVert;
    bool down;
    [SerializeField] Animator anim;
    [SerializeField] float speed,time;
    void OnEnable()
    {
        target = PlayerController.player;
        Invoke(nameof(ChangeDirection), time/2);
        Invoke(nameof(Boom), time);
        initVert = transform.position.y;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    void ChangeDirection()
    {
        transform.Rotate(0, 0, 180);
        down = true;
        transform.position = new Vector3(target.position.x, transform.position.y + target.position.y - initVert );
    }
    void Boom()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, 1);
        foreach (Collider2D coll in colls)
            if (coll.CompareTag("Player"))
                coll.GetComponent<HealthManager>().TakeDamage(0.3f);
        transform.rotation = Quaternion.identity;
        enabled = false;
        anim.Play("Boom");
        Destroy(gameObject, 1f);
    }

}
