using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltraController : MonoBehaviour
{
    public static UltraController instance;
    [SerializeField] Slider progress;
    [SerializeField] Image bar;

    float value;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        value = 0;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            UltraBegin();
        }
    }
    public void Add(float f)
    {
        value = Mathf.Min(1f, value + f);
        progress.value = value;
        if(value < 0.95f)
        {
            bar.color = new Color(1, 0, 1);
        }
        else
        {
            bar.color = new Color(1, 1, 0);
        }
    }
    void UltraBegin()
    {
        weapons[current + weapons.Length / 2].SetActive(true);
        light.SetActive(true);
        Invoke(nameof(UltraEnd), 5f);
    }
    void UltraEnd()
    {
        weapons[current + weapons.Length / 2].SetActive(false);
        light.SetActive(false);
    }
}
