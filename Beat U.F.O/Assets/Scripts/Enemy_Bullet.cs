using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public GameObject Laser_1;
    public float timer = 0;
    public float initialx = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialx = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(initialx - timer, transform.position.y, transform.position.z);

        if (transform.position.x <= -0.8)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "shield")
        {
            GameObject copiaLaser_1 = Instantiate(Laser_1, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collider.transform.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
