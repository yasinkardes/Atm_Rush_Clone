using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Machines : MonoBehaviour
{
    [Header("Color")]
    public bool Color = false;
    public int tempCount;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ATM"))
        {
            ATM.Instance.ATM_Count += 1;
            Stack.Instance.Balls.Remove(gameObject.transform);
            Destroy(gameObject);
        }


        if (other.CompareTag("Portal"))
        {
            if (Color == false)
            {
                gameObject.transform.GetComponent<Renderer>().material.color = new Color(255, 223, 0); //GOLD
                StartCoroutine(myTime());
            }

            else 
            {
                gameObject.transform.GetComponent<Renderer>().material.color = new Color(100, 0, 100); //RUBY
            }
        }


        if (other.CompareTag("Split") || other.CompareTag("Thief"))
        {
            Stack.Instance.Balls.Remove(gameObject.transform);
            gameObject.transform.DOLocalMove(new Vector3(gameObject.transform.position.x,
                                                    gameObject.transform.position.y,
                                                    gameObject.transform.position.z + 7f), 0.3f);

            Destroy(gameObject.transform.GetComponent<Rigidbody>());
            gameObject.tag = "Collectable";
        }

        if (other.CompareTag("Finish"))
        {
            Stack.Instance.Balls.Remove(gameObject.transform);
            gameObject.GetComponent<Last_Finish>().enabled = true;
        }

        if (other.CompareTag("Respawn"))
        {
            ATM.Instance.tempCount += 1;
            Destroy(gameObject);
        }
    }

    public IEnumerator myTime()
    {
        yield return new WaitForSeconds(1);
        Color = true;
    }
}
