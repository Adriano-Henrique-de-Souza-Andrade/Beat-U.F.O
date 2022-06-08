using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float select = 0.0f;
    public float randompos = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        select = Random.Range(0.1f, 0.6f);
        randompos = Random.Range(-0.4f, 0.4f);
        transform.position = new Vector3(transform.position.x, randompos, 0.0f);
        transform.localScale = new Vector2(select, select);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(select, select);
        transform.position = new Vector3(transform.position.x - select/500, transform.position.y, transform.position.z);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + 0.1f);

        if (transform.position.x <= -0.8f)
        {
            select = Random.Range(0.1f, 1.5f);
            randompos = Random.Range(-0.4f, 0.4f);
            transform.position = new Vector3(0.8f, randompos, 0.0f);
        }
    }
}
