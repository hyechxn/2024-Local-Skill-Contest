using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatKeyManager : MonoBehaviour
{
    bool isPause;

    void Update()
    {

    }

    public void Cheat1()
    {

    }

    public void Cheat2()
    {

    }

    public void Cheat3()
    {
        if (StageController.instance.map == StageController.Map.Desert)
            SceneManager.LoadScene("1_Desert");
        else if (StageController.instance.map == StageController.Map.Mountain)
            SceneManager.LoadScene("2_Mountain");
        else if (StageController.instance.map == StageController.Map.City)
            SceneManager.LoadScene("3_City");
    }

    public void Cheat4()
    {
        if (StageController.instance.map == StageController.Map.Desert)
            SceneManager.LoadScene("2_Mountain");
        else if (StageController.instance.map == StageController.Map.Mountain)
            SceneManager.LoadScene("3_City");
        else if (StageController.instance.map == StageController.Map.City)
            SceneManager.LoadScene("1_Desert");
    }

    public void Cheat5()
    {
        isPause = !isPause;

        if (isPause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
