using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ATM : MonoBehaviour
{
    public static ATM Instance;

    public int ATM_Count;
    public int Total_Count;
    public int tempCount;

    public TextMeshPro Money_Text;
    public TextMeshProUGUI Money_Text2;

    void Start()
    {
        Instance = this;
    }

    public void Update()
    {
        Total_Count = ATM_Count + Stack.Instance.Balls.Count - 1 + tempCount;

        Money_Text.text = Total_Count.ToString();
        Money_Text2.text = Total_Count.ToString();
    }
}
