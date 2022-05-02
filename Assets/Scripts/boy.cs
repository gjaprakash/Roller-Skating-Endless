using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boy : MonoBehaviour
{
    //public GameObject stand;
    //public GameObject crouch;
    public Sprite fall;
    public Sprite fallbg;
    public Sprite run;
    // public Sprite boy3;
    private Animator anim;
    public GameManager gameManager;
    Rigidbody2D rb;
    bool isJumping;
    bool showadBtn;

    public ParticleSystem co2;
    public GameObject GOPanel;
    public GameObject Canvas;
    public GameObject adBtn;

    public GameObject fast;
    public GameObject slow;

    public AudioClip jumpS;
    public AudioClip balloon;
    public AudioClip goS;
    public AudioClip fallBg;

    public GameObject trackscoreobj;
    public score trackscore;

    //AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
       showadBtn = true;
       Canvas = GameObject.Find("Canvas");
       GOPanel = Canvas.transform.Find("GO panel").gameObject;
       adBtn = GOPanel.transform.Find("adbtn").gameObject;
       trackscoreobj = Canvas.transform.Find("trackscore").gameObject;
       trackscore = trackscoreobj.GetComponent<score>();

        anim = GetComponent<Animator>();
       rb = GetComponent<Rigidbody2D>();
       isJumping = false;
       //this.gameObject.GetComponent<SpriteRenderer>().sprite = run;
       //jumpSound = GetComponent<AudioSource>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!GOPanel.activeSelf) {
            //Input.GetKey("space") && isJumping == false || 
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began &&  isJumping == false)
            {
                rb.velocity = new Vector3(0, 15, 0);
                isJumping = true;
                anim.SetTrigger("jump");
                //jumpSound.Play();
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(jumpS);
                co2.Play();
                //stand.SetActive(false);
                //crouch.SetActive(true);
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
        co2.Stop();
        //stand.SetActive(true);
        //crouch.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacle") {
            anim.enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = fall;
            this.transform.position = new Vector3(-2, -3, 0);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(goS);
            audio.PlayOneShot(fallBg);
            gameManager.GameOver();

            if (showadBtn == true)
            {
                adBtn.SetActive(true);
                showadBtn = false;
            } else if (showadBtn == false)
            {
                adBtn.SetActive(false);
            }
        }
        if (collision.tag == "slow")
        {
            trackscore.slowdown();
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(balloon);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "fast")
        {
            trackscore.speedup();
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(balloon);
            Destroy(collision.gameObject);
        }
    }

    public void Continue()
    {
        GameObject.Find("boy").GetComponent<Animator>().enabled = true;
    }
}
