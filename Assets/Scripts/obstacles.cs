using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class obstacles : MonoBehaviour
{
    float maxTime;
    float timer;

    public GameObject Canvas;
    public GameObject trackscoreobj;
    public GameObject route;
    public GameObject rock;
    public GameObject tree;
    public GameObject wood;
    public GameObject woodseat;
    public score trackscore;

    public GameObject slow;
    public GameObject fast;

    int chooseObstacle;
    int chooseObstaclespeed;
    int chmaxTime;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = 1.2f;
        Canvas = GameObject.Find("Canvas");
        trackscoreobj = Canvas.transform.Find("trackscore").gameObject;

        trackscore = trackscoreobj.GetComponent<score>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(timer >= maxTime){
            if (maxTime == 3f)
            {
                trackscore.trackscores();
            }
            GenerateObstacle();
            chmaxtime();

            timer = 0;
        }
    }
    void chmaxtime()
    {
        chmaxTime = Random.Range(1, 8);
        if (chmaxTime == 1) { maxTime = 1.2f; }
        if (chmaxTime == 2) { maxTime = 1.6f; }
        if (chmaxTime == 3) { maxTime = 1.2f; }
        if (chmaxTime == 4) { maxTime = 1.8f; }
        if (chmaxTime == 5) { maxTime = 3f; }
        if (chmaxTime == 6) { maxTime = 1.6f; }
        if (chmaxTime == 7) { maxTime = 2f; }

    }

    void GenerateObstacle() {
        chooseObstacle = Random.Range(1, 6);
        if (chooseObstacle == 1) { GameObject newObstacle = Instantiate(route); }
        if (chooseObstacle == 2) { GameObject newObstacle = Instantiate(rock); }
        if (chooseObstacle == 3) { GameObject newObstacle = Instantiate(tree); }
        if (chooseObstacle == 4) { GameObject newObstacle = Instantiate(wood); }
        if (chooseObstacle == 5) { GameObject newObstacle = Instantiate(woodseat); }
    }

    public void slowtimescale()
    {
        chooseObstaclespeed = Random.Range(1, 4);
        if (chooseObstaclespeed == 1) { GameObject newObstacle = Instantiate(fast); }
        if (chooseObstaclespeed == 2) { GameObject newObstacle = Instantiate(slow); }
        if (chooseObstaclespeed == 3) { GameObject newObstacle = Instantiate(fast); }
    }
}
