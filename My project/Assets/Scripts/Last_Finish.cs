using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_Finish : MonoBehaviour
{
    public GameObject[] wayPoints;
    int current = 0;
    float rotSpeed;
    public float Speed;
    float wPradius = 1;

    public void Update()
    {
            if (Vector3.Distance(wayPoints[current].transform.position, transform.position) < wPradius)
            {
                current++;

                if (current >= wayPoints.Length)
                {
                    current = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[current].transform.position, Time.deltaTime * Speed);
    }
}
