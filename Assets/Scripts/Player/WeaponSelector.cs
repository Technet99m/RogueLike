using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject manager,light;
    public static int current = -1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Vending"))
        {
            col.enabled = false;
            manager.SetActive(true);
            GetNewWeapon();
        }
    }
    void GetNewWeapon()
    {
        if(current<0)
        {
            current = Random.Range(0, weapons.Length);
            weapons[current].SetActive(true);
        }
        else
        {
            weapons[current].SetActive(false);
            current = current + (Random.value > 0.5f ? 1 : -1);
            if (current < 0)
                current = weapons.Length - 1;
            else if (current == weapons.Length)
                current = 0;
            weapons[current].SetActive(true);
        }
    }


}
