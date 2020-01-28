using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject wall,pointer;
    [SerializeField] int packSize;
    int left, index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            if (gameObject.name == "ThirdScene")
            {
                UIManager.instance.gameObject.SetActive(true);
                return;
            }
            Init();
            
        }
    }
    public void Init()
    {
        instance = this;
        index = 0;
        print(instance.gameObject.name);
        SpawnNewPack();
    }
    void SpawnNewPack()
    {
        left = packSize;
        if(index == enemies.Length)
        {
            NewScene();
            return;
        }
        for (int i = 0; i < packSize; i++)
            enemies[index + i].SetActive(true);
        index += packSize;
    }
    public void DieAgain()
    {
        left--;
        print("Left: " + left);
        if (left <= 0)
            Invoke(nameof(SpawnNewPack),1f);
    }
    void NewScene()
    {
        pointer.SetActive(true);
        wall.SetActive(false);
    }

}
