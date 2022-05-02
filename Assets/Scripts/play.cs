using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene("Games");
        Time.timeScale = 1;
        //Debug.Log("play");
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
