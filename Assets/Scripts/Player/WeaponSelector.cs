using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject manager,point;
    [SerializeField] AudioSource audio;
    public static int current = -1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Vending"))
        {
            point.SetActive(false);
            col.enabled = false;
            if(current<0)
                manager.GetComponent<SceneManager>().Init();
            GetNewWeapon();
        }
    }
    void GetNewWeapon()
    {
        audio.Play();
        if(current<0)
        {
            current = 0;
            weapons[current].SetActive(true);
        }
        else
        {
            weapons[current].SetActive(false);
            current = 1;
            weapons[current].SetActive(true);
        }
    }


}
