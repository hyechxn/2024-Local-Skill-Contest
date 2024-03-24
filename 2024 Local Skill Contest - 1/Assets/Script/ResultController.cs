using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public GameObject winPage;
    public GameObject losePage;

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
        StageController.instance.shopPage.SetActive(true);
        ShopForTire();
    }
    public void ExitShop()
    {
        StageController.instance.shopPage.SetActive(false);
    }

    public void ShopForEngine()
    {
        engineShop.SetActive(true);
        tireShop.SetActive(false);
    }

    public void ShopForTire()
    {
        tireShop.SetActive(true);
        engineShop.SetActive(false);
    }

    public void TryBuy(int inputItem)
    {
        GameManager.Item item = (GameManager.Item)inputItem;
        int cost = 0;
        switch (item)
        {
            case GameManager.Item.dTire:
                cost = 5000000;
                break;
            case GameManager.Item.mTire:
                cost = 15000000;
                break;
            case GameManager.Item.cTire:
                cost = 25000000;
                break;
            case GameManager.Item.engine6:
                cost = 20000000;
                break;
            case GameManager.Item.engine8:
                cost = 30000000;
                break;
        }
        if (cost <= GameManager.Instance.money)
        {
            GameManager.Instance.money -= cost;
            GameManager.Instance.inventoty[(int)item] = true;
        }
    }


    public void NextStage(int curStage)
    {
        if (curStage == 1)
            SceneManager.LoadScene("2_Mountain");
        else if (curStage == 2)
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