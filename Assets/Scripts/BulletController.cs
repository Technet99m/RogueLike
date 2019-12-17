using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] string targetTag;
    [SerializeField] float damage;
    int col = 0;

    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        col++;
        if (col > 1)
        {
            if (collision.CompareTag(targetTag))
            {
                collision.GetComponent<HealthManager>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}
