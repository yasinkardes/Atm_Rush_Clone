using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private GameObject Idle;

    [Header("Player Settings")]
    public float forwardSpeed;
    public float slideSpeed;

    [Header("Bounds")]
    public Transform Forward;
    public Transform Back;

    [Header("Necessary")]
    public bool isStart;

    [Header("Start_After_False")]
    public GameObject market;
    public GameObject Upgrade_1;
    public GameObject Upgrade_2;
    public GameObject Air;

    Vector3 firstPos;
    Vector3 lastPos;

    private void Start()
    {
        Idle = GameObject.Find("Idle");
        Instance = this;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0) && isStart == false)
        {
            forwardSpeed = 0;
            Idle.GetComponent<Animator>().SetFloat("vertical", 0);
        }

        else
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                isStart = true;
                forwardSpeed = 5f;
                Idle.GetComponent<Animator>().SetFloat("vertical", 1f);
                market.SetActive(false);
                Upgrade_1.SetActive(false);
                Upgrade_2.SetActive(false);
                Air.SetActive(true);
            }
        }

        //Main Movement
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

        //Slide
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;

            firstPos = Camera.main.ScreenToWorldPoint(pos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 10;

            lastPos = Camera.main.ScreenToWorldPoint(pos);

            Vector3 dif = lastPos - firstPos;
            transform.position += new Vector3(dif.x, 0, 0) * Time.deltaTime * slideSpeed;     //It tells you which direction to go.
            firstPos = lastPos;
        }

        //Bounds
        Forward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        Back.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Thief"))
        {
            gameObject.transform.DOLocalMove(new Vector3(gameObject.transform.position.x,
                                gameObject.transform.position.y,
                                gameObject.transform.position.z - 17f), 0.3f);
        }

        if (other.CompareTag("Finish"))
        {
            Idle.GetComponent<Animator>().SetFloat("vertical", 0f);
            GetComponent<Player>().enabled = false;
            StartCoroutine(FinishLevel());
        }
    }

    public IEnumerator FinishLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("FinishScene");
    }
}
