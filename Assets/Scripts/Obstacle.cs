using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // atribut untuk Obstacle
    private SpriteRenderer sprite;
   private BoxCollider2D boxCollider2D;
    private CircleCollider2D circleCollider;

    
    private float min_size = 0.2f;
    private float max_size = 1.0f;
   
    void RandomShape()
    {
        sprite = GetComponent<SpriteRenderer>();
       boxCollider2D = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        float w = Random.Range(min_size, max_size);
        float h = Random.Range(min_size, max_size);
       
        sprite.size = new Vector2(w, h);
       boxCollider2D.size = new Vector2(w, h);
        circleCollider.offset = new Vector2(w, h);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.Instance.InScore();
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        RandomShape();
    }
}
