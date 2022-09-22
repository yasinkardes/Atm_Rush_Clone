using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, ATM.Instance.Total_Count, transform.position.z), 1 * Time.deltaTime);
    }
}
