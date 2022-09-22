using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject myPlayer;
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void close_Sound()
    {
        AudioListener.volume = 1 - AudioListener.volume;
    }

    public void doRed()
    {
        myPlayer.transform.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
    }

    public void doGreen()
    {
        myPlayer.transform.GetComponent<Renderer>().material.color = new Color(9, 121, 105);
    }

    public void doBlue()
    {
        myPlayer.transform.GetComponent<Renderer>().material.color = new Color(0, 255, 255);
    }
}
