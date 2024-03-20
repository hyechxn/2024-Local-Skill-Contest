using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StageController : MonoBehaviour
{
    public static StageController instance;

    public AudioSource a1;
    public AudioSource a2;

    public GameObject[] gallIn = new GameObject[2];

    public Text t;

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

    IEnumerator Play()
    {
        a1.Play();
        yield return new WaitForSeconds(0.15f);
        t.text = 3f+"";
        yield return new WaitForSeconds(0.85f);
        a1.Play();
        yield return new WaitForSeconds(0.15f);
        t.text = 2f+"";
        yield return new WaitForSeconds(0.85f);
        a1.Play();
        yield return new WaitForSeconds(0.15f);
        t.text = 1f+"";
        yield return new WaitForSeconds(0.85f);
        a2.Play();
        yield return new WaitForSeconds(0.15f);
        t.text = "Go!";
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.isPlay = true;
        GameManager.Instance.Play();
        yield return new WaitForSeconds(0.5f);
        t.text = "";
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
}
