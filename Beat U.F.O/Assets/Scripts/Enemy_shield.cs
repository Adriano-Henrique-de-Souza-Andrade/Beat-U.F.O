using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.4f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
    }
}
