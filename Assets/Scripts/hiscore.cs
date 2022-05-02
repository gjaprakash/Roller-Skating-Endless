using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hiscore : MonoBehaviour
{

    public Text HIScores;


    //public GameObject GOPanel;
    //float timer;
    //float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        HIScores.text = "High Score : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";


    }

    // Update is called once per frame
    void Update()
    {
        HIScores.text = "High Score : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";

            
    }
}