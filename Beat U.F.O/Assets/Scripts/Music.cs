using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public float BPM = 0.5f;
    public float timer = 0;
    public bool isPlaying;
    public AudioSource audioSource;
    public float t = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.localScale = Vector3.Lerp(transform.localScale, (new Vector2(1, 1)), t);
        if (timer >= 0.4f && isPlaying == false)
        {
            isPlaying = true;
            audioSource.Play();
        }
        if (timer >= BPM)
        {
            transform.localScale = new Vector2(1.5f, 1.5f);
            timer -= BPM;
        }
    }
}
