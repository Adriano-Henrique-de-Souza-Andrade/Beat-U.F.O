using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool acao = false;
    public bool morreu = false;
    public float bpm = 0.5f;
    public int posicao = 1;
    public int bullets = 1;
    public int shield = 1;
    public int direcao = 0;
    public float t = 0.01f;
    public Transform Position1;
    public Transform Position2;
    public Transform Position3;
    public GameObject Laser_2;
    public GameObject Shield_2;
    public float timer = 0;
    public int select = 0;
    public int randomy = 0;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        select = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 a = transform.position;
        transform.localScale = Vector3.Lerp(transform.localScale, (new Vector2(1, 1)), t);
        switch (posicao)
        {
            case 0:
                Vector3 b = Position1.position;
                transform.position = Vector3.Lerp(a, b, t);
                break;
            case 1:
                Vector3 c = Position2.position;
                transform.position = Vector3.Lerp(a, c, t);
                break;
            case 2:
                Vector3 d = Position3.position;
                transform.position = Vector3.Lerp(a, d, t);
                break;
        }

        if (acao == true)
        {
            select = Random.Range(1, 5);
            if ((select == 1) && (posicao >= 1))
            {
                bullets += 1;
                shield += 1;
                posicao -= 1;
                acao = false;
            }
            else if ((select == 2) && (posicao <= 1))
            {
                bullets += 1;
                shield += 1;
                posicao += 1;
                acao = false;
            }
            else if ((select == 3) && (bullets == 1) && (morreu == true))
            {
                GameObject copiaLaser_1 = Instantiate(Laser_2, transform.position, transform.rotation);
                bullets -= 1;
                acao = false;
            }
            else if ((select == 4)  && (shield == 1))
            {
                GameObject copiashield_1 = Instantiate(Shield_2, new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z), transform.rotation);
                shield -= 1;
                acao = false;
            }
        }

        if (bullets > 1)
        {
            bullets = 1;
        }
        if (shield > 1)
        {
            shield = 1;
        }

        if (timer >= bpm)
        {
            if (transform.position.x > 0.51)
            {
                acao = false;
                posicao = randomy;
            }
            else
            {
                transform.localScale = new Vector2(1.5f, 1.5f);
                acao = true;
                select = Random.Range(1, 5);
                timer -= bpm;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "laser")
        {
            morreu = true;
            audioSource.Play();
            acao = false;
            randomy = Random.Range(0, 3);
            posicao = 4;
            transform.position = new Vector3(0.9f, 0.0f, 0.0f);
        }
    }
}
