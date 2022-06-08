using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_right : MonoBehaviour
{
    public float bpm = 0.5f;
    public float timer = 0;
    public float t = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, (new Vector2(1, 1)), t);
        if (timer >= bpm)
        {
            transform.localScale = new Vector2(1.5f, 1.5f);
            timer -= bpm;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(gameObject);
        }
    }
}
