using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRocketController : MonoBehaviour
{
    [SerializeField] GameObject rocket;
    [SerializeField] float reloadTime;
    void Start()
    {
        StartCoroutine(Reload());
    }
    IEnumerator Reload()
    {
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(reloadTime);
                Shoot();
            }
            yield return new WaitForSeconds(reloadTime * 5);
        }
    }
    void Shoot()
    {
        GameObject go = Instantiate(rocket, rocket.transform.position, rocket.transform.rotation);
        go.GetComponent<RocketController>().enabled = true;
    }
}
