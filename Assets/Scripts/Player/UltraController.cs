using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltraController : MonoBehaviour
{
    public static UltraController instance;
    [SerializeField] Slider progress;
    [SerializeField] Image bar;
    [SerializeField] GameObject light,ultralight;
    public bool ulta;
    float value;

    private void Awake()
    {
        instance = this;
    }
    void OnEnable()
    {
        value = 0f;
        progress.value = 0;
    }
    private void Update()
    {
        if (!Application.isMobilePlatform && Input.GetMouseButtonDown(1))
        {
            UltraCheck();
        }
    }
    public void UltraCheck()
    {
        if(value > 0.98f)
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
            ultralight.SetActive(false);
        }
        else
        {
            ultralight.SetActive(true);
        }
    }
    void UltraBegin()
    {
        value = 0;
        ultralight.SetActive(false);
        progress.value = value;
        if (value < 0.98f)
        {
            bar.color = new Color(1, 0, 1);
        }
        else
        {
            bar.color = new Color(1, 1, 0);
        }
        ulta = true;
        light.SetActive(true);
        Invoke(nameof(UltraEnd), 5f);
    }
    void UltraEnd()
    {
        ulta = false;
        light.SetActive(false);
    }
}
