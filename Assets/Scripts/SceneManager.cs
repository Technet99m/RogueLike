using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    [SerializeField] GameObject[] enemies;
    [SerializeField] int packSize;
    int left, index;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
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
        if (left == 0)
            Invoke(nameof(SpawnNewPack),1f);
    }
    void NewScene()
    {

    }

}
