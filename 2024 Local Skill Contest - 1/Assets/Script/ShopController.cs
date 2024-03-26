using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    Transform tirePane;
    Transform enginePane;

    private void OnEnable()
    {
        tirePane = transform.GetChild(0).GetChild(0);
        enginePane = transform.GetChild(0).GetChild(1);

        for (int i = 0; i < tirePane.childCount; i++)
        {
            Button child = tirePane.GetChild(i).GetComponent<Button>();
            child.interactable = !GameManager.Instance.inventoty[i];
        }

        for (int i = 0; i < enginePane.childCount; i++)
        {
            Button child = enginePane.GetChild(i).GetComponent<Button>();
            child.interactable = !GameManager.Instance.inventoty[i + 2];
        }

        tirePane.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
