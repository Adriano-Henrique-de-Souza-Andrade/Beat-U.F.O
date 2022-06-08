using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool acao = false;
    public float bpm = 0.5f;
    public int posicao = 1;
    public int bullets = 1;
    public int shield = 1;
    public int direcao = 0;
    public float t = 0.01f;
    public Transform Position1;
    public Transform Position2;
    public Transform Position3;
    public GameObject Laser_1;
    public GameObject Shield_1;
    public float timer = 0;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        timer += Time.deltaTime;
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
            if ((Input.GetKeyDown(KeyCode.UpArrow) || direcao == 2) && (posicao >= 1))
            {
                bullets += 1;
                shield += 1;
                posicao -= 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || direcao == 4) && (posicao <= 1))
            {
                bullets += 1;
                shield += 1;
                posicao += 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || direcao == 1) && (bullets > 0))
            {
                GameObject copiaLaser_1 = Instantiate(Laser_1, transform.position, transform.rotation);
                bullets -= 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || direcao == 3) && (shield > 0))
            {
                GameObject copiashield_1 = Instantiate(Shield_1, new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z), transform.rotation);
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
            transform.localScale = new Vector2(1.5f , 1.5f);
            timer -= bpm;
        }
        
        if (timer <= bpm - 0.1 && timer >= bpm - 0.15){
            acao = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "enemy_laser")
        {
            ScoreManager.instance.GameOverAppear();
            audioSource.Play();
            Destroy(gameObject, 0.5f);
        }
    }
}
