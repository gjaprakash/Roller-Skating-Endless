using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sea : MonoBehaviour
{
    public float speed;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * speed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

    }
}
