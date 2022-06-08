using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Laser_2;
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
        transform.position = new Vector3(initialx + timer, transform.position.y, transform.position.z);

        if (transform.position.x >= 0.8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "shield_2")
        {
            GameObject copiaLaser_2 = Instantiate(Laser_2, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collider.transform.tag == "enemy")
        {
            ScoreManager.instance.AddPoint();
            Destroy(gameObject);
        }
    }
}
