using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_count : MonoBehaviour
{
    public Sprite no_shield;
    public Sprite have_shield;
    public bool acao = false;
    public float bpm = 0.5f;
    public int shield = 1;
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
                shield += 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.DownArrow) || direcao == 4))
            {
                shield += 1;
                acao = false;
            }
            else if ((Input.GetKeyDown(KeyCode.LeftArrow) || direcao == 1) && (shield > 0))
            {
                shield -= 1;
                acao = false;
            }
        }

        if (shield > 1)
        {
            shield = 1;
        }

        if (shield >= 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = have_shield;
        } 
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = no_shield;
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
