using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform Forward;
    public Transform Back;
    public Transform Left;
    public Transform Right;

    public void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        viewPos.z = Mathf.Clamp(viewPos.z, Back.transform.position.z, Forward.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x, Left.transform.position.x, Right.transform.position.x);

        transform.position = viewPos;
    }
}
