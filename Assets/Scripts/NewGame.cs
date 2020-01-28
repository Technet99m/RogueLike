using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] Vector2 PlayerPos;

    [SerializeField] GameObject player;
    [SerializeField] Transform cam;
    [SerializeField] GameObject[] MakeActive;
    [SerializeField] GameObject[] MakeDisactive;
    [SerializeField] BoxCollider2D vm, vm1;
    
    public void Reload()
    {
        player.transform.position = PlayerPos;
        cam.SetParent(null);
        vm.enabled = true;
        vm1.enabled = true;
        player.SetActive(false);
        UIManager.instance.ResetIndex();
        WeaponSelector.current = -1;
        foreach (GameObject g in MakeActive)
            g.SetActive(true);
        foreach (GameObject g in MakeDisactive)
            g.SetActive(false);
    }

}
