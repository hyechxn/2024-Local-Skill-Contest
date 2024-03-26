using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (GameManager.Instance.inventoty[i])
                transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            else
                transform.GetChild(i).GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);

        }
    }
}
