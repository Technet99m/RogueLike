using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed;
    int col = 0;

    void Update()
    {
        transform.Translate(Vector3.left*Time.deltaTime*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        col++;
        if (col > 1)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            else if (collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }

}
