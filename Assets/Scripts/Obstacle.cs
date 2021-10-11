using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // atribut untuk Obstacle
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;

    private float min_size = 0.3f;
    private float max_size = 2.0f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        // memanggil methode untuk random shape atau obstacle
        RandomShape();
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

}
