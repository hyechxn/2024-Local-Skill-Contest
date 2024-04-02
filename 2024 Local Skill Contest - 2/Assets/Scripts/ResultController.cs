using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    public Text rank;
    public Text timer;
    public Text scoreText;

    private void OnEnable()
    {
        Time.timeScale = 0f;
        if (StageController.instance.goalIn[0] == "Player")
        {
            rank.text = "1위";
            winPanel.SetActive(true);
            losePanel.SetActive(false);
        }
        else
        {
            rank.text = "2위";
            losePanel.SetActive(true);
            winPanel.SetActive(false);
        }
        timer.text = "시간 " + (int)StageController.instance.time / 60 + $" : " +
            (((int)StageController.instance.time % 60) < 10 ? ("0" + (int)StageController.instance.time % 60) : ((int)StageController.instance.time % 60));

        GameManager.Instance.preScore = 3000 - (int)StageController.instance.time;
        scoreText.text = "점수 "+ (GameManager.Instance.preScore + GameManager.Instance.score);
    }


    public void NextStage()
    {
        GameManager.Instance.preScore += GameManager.Instance.score;
        if (StageController.instance.curStage == StageController.Map.Desert)
            SceneManager.LoadScene("2_Mountain");
        else if(StageController.instance.curStage == StageController.Map.Mountain)
            SceneManager.LoadScene("3_City");
        else if(StageController.instance.curStage == StageController.Map.City)
            SceneManager.LoadScene("Ranking");
    }
    public void ReTry()
    {
        GameManager.Instance.score = 0;
        if (StageController.instance.curStage == StageController.Map.Desert)
            SceneManager.LoadScene("1_Desert");
        else if (StageController.instance.curStage == StageController.Map.Mountain)
            SceneManager.LoadScene("2_Mountain");
        else if (StageController.instance.curStage == StageController.Map.City)
            SceneManager.LoadScene("3_City");
    }
}
