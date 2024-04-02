using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public Text centerText;

    public Text money;
    public Text gainMoney;

    public float time;
    public Text timer;

    public AudioSource beeb;
    public AudioSource peeb;

    public Map curStage;

    public GameObject shop;
    public GameObject result;

    public string[] goalIn = new string[2];
    private void Start()
    {
        StartCoroutine(CountDown());
    }

    private void Update()
    {
        time += Time.deltaTime;
        timer.text = (int)time / 60 + " : " + (int)time % 60;

        money.text = GameManager.Instance.money + "만원";
    }


    IEnumerator CountDown()
    {
        GameManager.Instance.enemyLogic.enabled = false;
        Time.timeScale = 0f;
        //GameManager.Instance.playerLogic.enabled = false;
        beeb.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        centerText.text = "3";
        yield return new WaitForSecondsRealtime(0.75f);
        beeb.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        centerText.text = "2";
        yield return new WaitForSecondsRealtime(0.75f);
        beeb.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        centerText.text = "1";
        yield return new WaitForSecondsRealtime(0.75f);
        peeb.Play();
        yield return new WaitForSecondsRealtime(0.25f);
        centerText.text = "GO!";
        //GameManager.Instance.playerLogic.enabled = false;
        Time.timeScale = 1f;
        GameManager.Instance.enemyLogic.enabled = true;
        yield return new WaitForSecondsRealtime(0.5f);
        centerText.text = "";
    }

    public IEnumerator Gain(int money)
    {
        gainMoney.text = "+" + money + "만원";
        GameManager.Instance.money += money;
        for (int i = 10; i >= 0; i--)
        {
            gainMoney.color = new Color(0.6f, 0.6f, 0.6f, i * 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    public IEnumerator ItemText(string item)
    {
        centerText.text = item;
        for (int i = 10; i >= 0; i--)
        {
            centerText.color = new Color(0.6f, 0.6f, 0.6f, i * 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ShopGo()
    {
        shop.SetActive(true);
    }

    public enum Map
    {
        Desert,
        Mountain,
        City
    }

    public static StageController instance;

    private void Awake()
    {
        instance = this;
    }
}
