using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player myPlayer;

    Transform target;

    public Vector3 offset;
    Vector3 mainPos;
    void Start()
    {
        mainPos = transform.position;
        target = myPlayer.transform;
    }

    void Update()
    {
        /*
        if (myPlayer.isStart == true)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 2);
        }


        else
        {
            transform.position = mainPos;
        }
        */

        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 5);
        
    }
}
