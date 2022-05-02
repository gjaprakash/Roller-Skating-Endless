using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eating : MonoBehaviour
{
    private Animator eat;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        eat = GetComponent<Animator>();
        eat.enabled = true;
    }

}
