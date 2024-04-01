using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
        if (StageController.instance.goalIn[0] == "Player")
        {
            rank.text = "1À§";
        }
        else
        {
            rank.text = "2À§";
        }
        timer
        
    }

}
