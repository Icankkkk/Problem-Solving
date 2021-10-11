﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // atribut untuk Obstacle
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;

    private float min_size = 0.2f;
    private float max_size = 1.0f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void RandomShape()
    { 
        float w = Random.Range(min_size, max_size);
        float h = Random.Range(min_size, max_size);
        /*
         * w = width
         * h = heigth
         */
        sprite.size = new Vector2(w, h);
        boxCollider2D.size = new Vector2(w, h);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.InScore();
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 1);
        }
    }

}
