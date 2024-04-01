using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money;


    public int preScore;
    public int score;

    public string p_Name;

    public Transform player;
    public PlayerController playerLogic;
    public Transform enemy;
    public EnemyController enemyLogic;


    public bool[] inventory = new bool[5];



    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject gmObj = new GameObject("GameManger");
                instance = gmObj.AddComponent<GameManager>();
                DontDestroyOnLoad(gmObj);
            }
                
            return instance;
        }
    }
}