using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject tirePane;
    public GameObject enginePane;


    private void OnEnable()
    {
        Time.timeScale = 0f;
        GoTire();
        int cnt = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < transform.GetChild(0).GetChild(0).GetChild(i).childCount; j++, cnt++)
            {
                Debug.Log(transform.GetChild(0).GetChild(0).GetChild(i).GetChild(j).name);
                Debug.Log(GameManager.Instance.inventory[cnt]);
                transform.GetChild(0).GetChild(0).GetChild(i).GetChild(j).GetComponent<Button>().interactable = !GameManager.Instance.inventory[cnt];
            }
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }

    public void GoTire()
    {
        tirePane.SetActive(true);
        enginePane.SetActive(false);
    }
    
    public void GoEngine()
    {
        tirePane.SetActive(false);
        enginePane.SetActive(true);
    }

    public void Buy(int index)
    {
        int cost = 0;
        switch (index)
        {
            case 0:
                cost = 750;
                break;
            case 1:
                cost = 1500;
                break;
            case 2:
                cost = 2500;
                break;
            case 3:
                cost = 1500;
                break;
            case 4:
                cost = 3000;
                break;
        }
        if (Input.GetKey(KeyCode.F2))
            cost = 0;
        if(cost <= GameManager.Instance.money)
        {
            GameManager.Instance.money -= cost;
            GameManager.Instance.inventory[index] = true;
        }

        int cnt = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < transform.GetChild(0).GetChild(0).GetChild(i).childCount; j++, cnt++)
            {
                Debug.Log(transform.GetChild(0).GetChild(0).GetChild(i).GetChild(j).name);
                Debug.Log(GameManager.Instance.inventory[cnt]);
                transform.GetChild(0).GetChild(0).GetChild(i).GetChild(j).GetComponent<Button>().interactable = !GameManager.Instance.inventory[cnt];
            }
        }
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
