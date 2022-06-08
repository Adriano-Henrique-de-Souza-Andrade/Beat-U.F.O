using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_count : MonoBehaviour
{
    public Sprite no_bullet;
    public Sprite have_bullet;
    public bool acao = false;
    public float bpm = 0.5f;
    public int bullets = 1;
    public int direcao = 0;
    public float t = 0.01f;
    public Transform Position1;
    public Transform Position2;
    public Transform Position3;
    public GameObject Laser_1;
    public GameObject Shield_1;
    public float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (acao == true)
        {
            if ((Input.GetKeyDown(KeyCode.UpArrow) || direcao == 2))
            {
                bullets += 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || direcao == 4))
            {
                bullets += 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || direcao == 1) && (bullets > 0))
            {
                bullets -= 1;
                acao = false;
            }
        }

        if (bullets > 1)
        {
            bullets = 1;
        }

        if (bullets >= 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = have_bullet;
        } 
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = no_bullet;
        }

        if (timer >= bpm)
        {
            timer -= bpm;
        }

        if (timer <= bpm - 0.1 && timer >= bpm - 0.15)
        {
            acao = true;
        }
    }
}
