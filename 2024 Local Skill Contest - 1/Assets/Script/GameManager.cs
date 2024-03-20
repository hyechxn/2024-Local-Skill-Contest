using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject tempObj = new GameObject("GameManager");
                instance = tempObj.AddComponent<GameManager>();
                DontDestroyOnLoad(tempObj);
            }
            return instance;
        }

    }

    public void Stop()
    {
        playerLogic.enabled = false;
        enemyLogic.enabled = false;
    }

    public void Play()
    {
        playerLogic.enabled = true;
        enemyLogic.enabled = true;
    }

    public Transform playerCar;
    public Transform enemyCar;
    public PlayerController playerLogic;
    public EnemyController enemyLogic;

    public bool isPlay;
}
