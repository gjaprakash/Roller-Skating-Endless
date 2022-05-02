using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour
{
    public Text trackscore;
    public Text trackscore2;
    public Text highscore;
    public Text highscore2;
    public Text calories;
    public Text heart;
    public Text co2;
    int scores;
    int trackscoress;
    int caloriescal;
    int heartcal;
    int co2cal;
    Text scoreText;
    bool newbest = true;

    //public GameObject GOPanel;
    public AudioClip claps;

    public GameObject obstaclesobj;
    public GameObject NewBest;
    public GameObject Canvas;
    public obstacles obstacles;
    float timer;
    float maxTime;
    float timescale;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        obstaclesobj = GameObject.Find("obstacles").gameObject;
        obstacles = obstaclesobj.GetComponent<obstacles>();
        NewBest = Canvas.transform.Find("newbest").gameObject;
        timescale = 1;
        highscore.text = "High Score : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";
        highscore2.text = "High Traveled Distance : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";
        scores = 0;
        caloriescal = 10;
        heartcal = 80;
        co2cal = 1;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            scores++;
            scoreText.text = "Your Distance" + scores.ToString("") + " m";
            timer = 0;
            trackscore.text = scores.ToString("") + " m";
            trackscore2.text = "Your Distance : " + scores.ToString("") + " m";

            if (scores % 100 == 0) {

                caloriescal += 10;
                heartcal += 4;
                co2cal += 1;

                timescale += 0.10f;
                Time.timeScale = timescale;

            }

            calories.text = "Burned calories : " + caloriescal.ToString("");
            heart.text = "Max Heart rate : " + heartcal.ToString("") + " BPM";
            co2.text = "Air polluted : " + co2cal.ToString("") + " Litters(CO2)";
        }

        if (scores > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", scores);
            highscore.text = "High Score : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";
            highscore2.text = "High Traveled Distance : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";
            if (newbest == true)
            {
                StartCoroutine(startcountdown());
                Debug.Log("play claps");
                newbest = false;
            }

        }

        if (Time.timeScale == 0) {
            if (scores > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", scores);
                highscore.text = "High Score : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";
                highscore2.text = "High Traveled Distance : " + PlayerPrefs.GetInt("highscore", 0).ToString("") + " m";
            }
        }


    }

    public IEnumerator startcountdown()
    {
        
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(claps);
            for (int i = 1; i > 0; i--)
            {
                NewBest.SetActive(true);
                yield return new WaitForSeconds(1.5f);

            }
            NewBest.SetActive(false);
        
    }
    public void readtimescale()
    {

        Time.timeScale = timescale;

    }
    public void trackscores()
    {

        if (scores >= 400) {
            obstacles.slowtimescale();
        } 

    }
    public void slowdown()
    {
        if (timescale >= 2.0)
        {
            Debug.Log(timescale + "down 1");
            timescale -= 0.40f;
            Time.timeScale = timescale;
            Debug.Log(timescale + "down 1");

        }
        else if (timescale >= 1.15)
        {
            Debug.Log(timescale + "down 2");
            timescale -= 0.15f;
            Time.timeScale = timescale;
            Debug.Log(timescale + "down 2");
            
        }

    }
    public void speedup()
    {
        if (timescale <= 3)
        {
            Debug.Log(timescale + "up 1");
            timescale += 0.05f;
            Time.timeScale = timescale;
        }

    }
    
}
