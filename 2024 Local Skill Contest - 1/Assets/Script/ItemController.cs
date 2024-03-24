using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Turn());
    }

    IEnumerator Turn()
    {
        transform.Rotate(new Vector3(0f, 10f, 0f));
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(Turn());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StageController.instance.centerText.fontSize = 150;
            int itemNum = Random.Range(0, 6);
            Debug.Log(itemNum);
            switch (itemNum)
            {
                case 0:
                    StageController.instance.SetText("1,000¸¸¿ø È¹µæ!");
                    break;
                case 1:
                    StageController.instance.SetText("500¸¸¿ø È¹µæ!");
                    break;
                case 2:
                    StageController.instance.SetText("100¸¸¿ø È¹µæ!");
                    break;
                case 3:
                    StageController.instance.SetText("¼ÒÇü ºÎ½ºÅÍ!");
                    break;
                case 4:
                    StageController.instance.SetText("´ëÇü ºÎ½ºÅÍ!");
                    break;
                case 5:
                    StageController.instance.shopPage.SetActive(true);
                    break;
            }
            StageController.instance.centerText.fontSize = 300;
            Destroy(gameObject);
        }
    }
}
