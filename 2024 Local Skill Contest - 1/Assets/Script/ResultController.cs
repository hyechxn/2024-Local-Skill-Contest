using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public GameObject winPage; 
    public GameObject losePage;

    public GameObject shopPage;
    public GameObject engineShop;
    public GameObject tireShop;

    public Text record;
    public Text score;

    private void OnEnable()
    {
        if (StageController.instance.goalIn[0] == "Player")
            winPage.SetActive(true);
        else
            losePage.SetActive(true);

        score.text = $"Score : {GameManager.Instance.score}";
        record.text = $"Record {(int)StageController.instance.timer / 60} : {(int)StageController.instance.timer % 60}";
    }


    public void GoShop()
    {
        shopPage.SetActive(true);
    }

    public void ShopForEngine()
    {

    }

    public void ShopForTire()
    {

    }


    public void NextStage(int curStage)
    {
        if (curStage == 1)
            SceneManager.LoadScene("2_Mountain");
        else if(curStage == 2)
            SceneManager.LoadScene("3_City");
    }

    public void ReTry(int curStage)
    {
        if (curStage == 1)
            SceneManager.LoadScene("1_Desert");
        else if (curStage == 2)
            SceneManager.LoadScene("2_Mountain");
        else if (curStage == 3)
            SceneManager.LoadScene("3_City");
    }
}