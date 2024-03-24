using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public static StageController instance;

    public float timer;

    public int itemCount;

    private bool isPlay;

    public AudioSource a1;
    public AudioSource a2;

    public string[] goalIn = new string[2];

    public Text centerText;
    public Text time;
    public Text money;

    public GameObject resultDisplay;
    public GameObject shopPage;

    public GameObject NPC;
    public Transform NPCSpawn;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        GameManager.Instance.Stop();
        StartCoroutine(Play());
    }
    private void Update()
    {
        if(isPlay)
            timer += Time.deltaTime;
        time.text = $"{(int)instance.timer / 60} : {(int)instance.timer % 60}";
        money.text = string.Format("{0:N0}", GameManager.Instance.money);

        if (GameManager.Instance.playerLogic.isGoal)
        {
            Time.timeScale = 0f;
            if (itemCount > 0)
                GameManager.Instance.score += (1 / itemCount) * (3000 - ((int)timer * 10));
            else
                GameManager.Instance.score = 3000 - (int)timer * 10;
            resultDisplay.SetActive(true);
        }
    }
    IEnumerator Play()
    {
        Time.timeScale = 1f;
        a1.Play();
        Debug.Log(Time.deltaTime);
        yield return new WaitForSeconds(0.15f);
        centerText.text = 3f+"";
        yield return new WaitForSeconds(0.85f);
        a1.Play();
        yield return new WaitForSeconds(0.15f);
        centerText.text = 2f+"";
        yield return new WaitForSeconds(0.85f);
        a1.Play();
        yield return new WaitForSeconds(0.15f);
        centerText.text = 1f+"";
        yield return new WaitForSeconds(0.85f);
        a2.Play();
        yield return new WaitForSeconds(0.15f);
        centerText.text = "Go!";
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.isPlay = true;
        GameManager.Instance.Play();
        yield return new WaitForSeconds(0.5f);
        centerText.text = "";
        isPlay = true;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        Instantiate(NPC, NPCSpawn.position + transform.right, Quaternion.Euler(1, 1, 1f));
        yield return new WaitForSeconds(Random.Range(2, 4));
        Instantiate(NPC, NPCSpawn.position + -transform.right, Quaternion.Euler(1, 1, 1f));
        StartCoroutine(Spawn());
    }

    public IEnumerator SetText(string text)
    {
        centerText.text = text;
        for (int i = 10; i >= 0; i--)
        {
            centerText.color = new Color(1f, 1f, 1f, 0.1f * i);
            yield return new WaitForSeconds(0.1f);
        }
        centerText.text = string.Empty;
    }
}
