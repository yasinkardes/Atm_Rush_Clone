using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Stack : MonoBehaviour
{
    public static Stack Instance;

    [SerializeField]
    [Header("Attribute")]
    public float SwipeSpeed;
    public float Distance;
    private bool isScaling;

    [Header("List")]
    public List<Transform> Balls = new List<Transform>();

    private void Start()
    {
        Instance = this;
        Balls.Add(gameObject.transform);
    }

    private void Update()
    {
        if (Balls.Count > 1)
        {
            for (int i = 1; i < Balls.Count; i++)
            {
                var FirstBall = Balls.ElementAt(i - 1);
                var SecBall = Balls.ElementAt(i);

                var DesireDistance = Vector3.Distance(SecBall.position, FirstBall.position);

                if (DesireDistance <= Distance)
                {
                    SecBall.position = new Vector3(Mathf.Lerp(SecBall.position.x, FirstBall.position.x, SwipeSpeed * Time.deltaTime), 
                                                   SecBall.position.y,
                                                   Mathf.Lerp(SecBall.position.z, FirstBall.position.z + 0.7f, SwipeSpeed * Time.deltaTime));
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.transform.parent = null;
            other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            //MakeObjectBigger
            StartCoroutine(MakeObjectBigger());
            other.tag = gameObject.tag;         
            Balls.Add(other.transform);
        }
    }

    public IEnumerator MakeObjectBigger()
    {
        if (Balls.Count > 0)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                Vector3 mainScale = new Vector3(1.4f, 0.3f, 0.5f);
                Vector3 scale = new Vector3(1.4f, 0.3f, 0.5f);
                scale *= 1.5f;

                Balls[i].transform.DOScale(scale, 0.05f);
                yield return new WaitForSeconds(0.1f);
                Balls[i].transform.DOScale(mainScale, 0.05f);
            }
        }
    }
}
