using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public float BPM = 0.5f;
    public float timer = 0;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(BPM*direction + timer*(-direction), transform.position.y, transform.position.z);
        if (timer >= BPM)
        {
            timer -= BPM;
        }
    }
}
