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


    public enum Item{
        dTire,
        mTire,
        cTire,
        engine6,
        engine8
    }

    public Item item;

    public bool[] inventoty = new bool[5];


    public int score;
    public long money;
    public bool isPlay;
}
