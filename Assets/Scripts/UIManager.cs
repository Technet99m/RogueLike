using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text[] Texts;
    [SerializeField] GameObject[] dialogPanels;
    [SerializeField] GameObject dialog,tutorial,boss;
    [SerializeField] string[] texts;
    [SerializeField] SceneManager sm;
    [SerializeField] PlayerController pc;
    [SerializeField] GameObject MobileUI;
    [SerializeField] AudioSource keyBoard;
    int stage;
    static int index;
    public static UIManager instance;
    void OnEnable()
    {
        instance = this;
        if (index==0)
        {
            if (Application.isMobilePlatform)
                MobileUI.SetActive(true);
            StartCoroutine(TypeText1());
        }
        else if(index == 1)
        {
            StartCoroutine(TypeText2());
        }
    }
    private void Update()
    {
        if (tutorial.activeSelf && Input.anyKeyDown)
        {
            tutorial.SetActive(false);
            dialog.SetActive(false);
        }
    }
    IEnumerator TypeText1()
    {
        pc.enabled = false;
        dialogPanels[0].SetActive(true);
        for(int i = 0;i<texts[0].Length;i++)
        {
            Texts[0].text += texts[0][i];
            keyBoard.Play();
            if(Input.anyKeyDown)
            {
                Texts[0].text = texts[0];
                break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.3f);
        dialogPanels[1].SetActive(true);
        for (int i = 0; i < texts[1].Length; i++)
        {
            Texts[1].text += texts[1][i];
            keyBoard.Play();
            if (Input.anyKeyDown)
            {
                Texts[1].text = texts[1];
                break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.3f);
        dialogPanels[2].SetActive(true);
        for (int i = 0; i < texts[2].Length; i++)
        {
            Texts[2].text += texts[2][i];
            keyBoard.Play();
            if (Input.anyKeyDown)
            {
                Texts[2].text = texts[2];
                break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        pc.enabled = true;
        while (true)
        {
            if (Input.anyKey)
            {
                FinishDialog1();
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator TypeText2()
    {
        pc.Stop();
        pc.enabled = false;
        dialog.GetComponent<Image>().color = new Color(0, 0, 0, 150f/255f);
        dialogPanels[0].SetActive(true);
        for (int i = 0; i < texts[3].Length; i++)
        {
            Texts[0].text += texts[3][i];
            keyBoard.Play();
            if (Input.anyKeyDown)
            {
                Texts[0].text = texts[3];
                break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.3f);
        dialogPanels[1].SetActive(true);
        for (int i = 0; i < texts[4].Length; i++)
        {
            Texts[1].text += texts[4][i];
            if (Input.anyKeyDown)
            {
                Texts[1].text = texts[4];
                keyBoard.Play();
                break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        pc.enabled = true;
        while (true)
        {
            if (Input.anyKey)
            {
                FinishDialog2();
                break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    void FinishDialog1()
    {
        dialog.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        index = 1;
        foreach(GameObject g in dialogPanels)
            g.SetActive(false);
        foreach (Text t in Texts)
            t.text = "";
        if (!Application.isMobilePlatform)
            tutorial.SetActive(true);
        else
            dialog.SetActive(false);
    }
    void FinishDialog2()
    {
        sm.Init();
        boss.SetActive(false);
        dialog.SetActive(false);
    }
    public void ResetIndex()
    {
        index = 0;
    }

}
