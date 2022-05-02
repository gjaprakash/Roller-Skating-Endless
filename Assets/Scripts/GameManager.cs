using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    AudioSource bgSound;
    public GameObject GOPanel;
    public GameObject Canvas;
    public GameObject Countdown;
    public GameObject trackscoreobj;
    public GameObject highscoreobj;
    public GameObject NewBest;

    //public boy boy;
    //public score score;
    public static GameManager instance;

    Text Countdowntext;
    public boy Boy;
    public score trackscore;
    //private Animator anim;
    //public GameObject Menu; 

    //Start is called before the first frame update

    int Countdowntimer;

    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        GOPanel = Canvas.transform.Find("GO panel").gameObject;
        NewBest = Canvas.transform.Find("newbest").gameObject;
        Countdown = Canvas.transform.Find("countdown").gameObject;
        Countdowntext = Canvas.transform.Find("countdown").gameObject.GetComponent<Text>();

        bgSound = GameObject.Find("GameManager").GetComponent<AudioSource>();
        ////anim = GetComponent<Animator>();

        Boy = GameObject.Find("boy").GetComponent<boy>();

        trackscoreobj = Canvas.transform.Find("trackscore").gameObject;
        highscoreobj = Canvas.transform.Find("highscorepanel").gameObject;
        
        trackscore = trackscoreobj.GetComponent<score>();
        GOPanel.SetActive(false);

    }


    //void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //        Debug.Log("if");
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //        Debug.Log("else");
    //    }
    //}


    public void GameOver()
    {
        Start();
        Time.timeScale = 0;
        GOPanel.SetActive(true);
        trackscoreobj.SetActive(false);
        highscoreobj.SetActive(false);
        NewBest.SetActive(false);
        bgSound.Stop();


    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Games");

        Time.timeScale = 1;

        bgSound.Play();
    }


    public void Continue()
    {
        Start();
        trackscoreobj.SetActive(true);
        highscoreobj.SetActive(true);
        GOPanel.SetActive(false);
        Countdown.SetActive(true);
        
        StartCoroutine(startcountdown());
        
    }

    public IEnumerator startcountdown()
    {


        for (int i = 3; i > 0; i--)
        {
            Time.timeScale = 0.001f;

            Countdowntext.text = i.ToString();

            yield return new WaitForSeconds(0.0008f);

        }
        Countdowntext.text = "Go!";
        yield return new WaitForSeconds(0.0008f);
        Countdown.SetActive(false);
        trackscore.readtimescale();
        Boy.Continue();
        bgSound.Play();

    }

    //public void startgame() {
    //    Debug.Log("ss");
    //    //trackscore.readtimescale();
    //    //Boy.Continue();
    //    //bgSound.Play();
    //}


}
